using Antlr4.Runtime;

namespace AntlrRenpy.Parser;

public abstract class RenpyLexerBase : Lexer
{
    // A stack that keeps track of the indentation lengths
    private Stack<int> indentLengthStack = [];
    // A list where tokens are waiting to be loaded into the token stream
    private LinkedList<IToken> pendingTokens = [];

    // last pending token types
    private int previousPendingTokenType = 0;
    private int lastPendingTokenTypeFromDefaultChannel = 0;

    // The amount of opened parentheses, square brackets, or curly braces
    private int opened = 0;
    //  The amount of opened parentheses and square brackets in the current lexer mode
    private Stack<int> paren_or_bracket_openedStack = [];

    private bool wasSpaceIndentation = false;
    private bool wasTabIndentation = false;
    private bool wasIndentationMixedWithSpacesAndTabs = false;

    private IToken curToken = null!; // current (under processing) token
    private IToken ffgToken = null!; // following (look ahead) token

    private const int INVALID_LENGTH = -1;
    private const string ERR_TXT = " ERROR: ";

    protected RenpyLexerBase(ICharStream input) : base(input)
    {
        Init();
    }

    protected RenpyLexerBase(ICharStream input, TextWriter output, TextWriter errorOutput) : base(input, output, errorOutput)
    {
        Init();
    }

    public override IToken NextToken() // reading the input stream until a return EOF
    {
        CheckNextToken();
        IToken firstPendingToken = pendingTokens.First.Value;

        pendingTokens.RemoveFirst();
        return firstPendingToken; // add the queued token to the token stream
    }

    public override void Reset()
    {
        Init();
        base.Reset();
    }

    private void Init()
    {
        indentLengthStack = [];
        pendingTokens = [];
        previousPendingTokenType = 0;
        lastPendingTokenTypeFromDefaultChannel = 0;
        opened = 0;
        paren_or_bracket_openedStack = [];
        wasSpaceIndentation = false;
        wasTabIndentation = false;
        wasIndentationMixedWithSpacesAndTabs = false;
        curToken = null!;
        ffgToken = null!;
    }

    private void CheckNextToken()
    {
        if (previousPendingTokenType != TokenConstants.EOF)
        {
            SetCurrentAndFollowingTokens();
            if (indentLengthStack.Count == 0) // We're at the first token
            {
                HandleStartOfInput();
            }

            switch (curToken.Type)
            {
                case RenpyLexer.LPAR:
                case RenpyLexer.LSQB:
                case RenpyLexer.LBRACE:
                    opened++;
                    AddPendingToken(curToken);
                    break;
                case RenpyLexer.RPAR:
                case RenpyLexer.RSQB:
                case RenpyLexer.RBRACE:
                    opened--;
                    AddPendingToken(curToken);
                    break;
                case RenpyLexer.NEWLINE:
                    HandleNEWLINEtoken();
                    break;
                case RenpyLexer.ERRORTOKEN:
                    ReportLexerError("token recognition error at: '" + curToken.Text + "'");
                    AddPendingToken(curToken);
                    break;
                case TokenConstants.EOF:
                    HandleEOFtoken();
                    break;
                default:
                    AddPendingToken(curToken);
                    break;
            }
        }
    }

    private void SetCurrentAndFollowingTokens()
    {
        curToken = ffgToken ?? base.NextToken();

        ffgToken = curToken.Type == TokenConstants.EOF
            ? curToken
            : base.NextToken();
    }

    // initialize the _indentLengths
    // hide the leading NEWLINE token(s)
    // if exists, find the first statement (not NEWLINE, not EOF token) that comes from the default channel
    // insert a leading INDENT token if necessary
    private void HandleStartOfInput()
    {
        // initialize the stack with a default 0 indentation length
        indentLengthStack.Push(0); // this will never be popped off
        while (curToken.Type != TokenConstants.EOF)
        {
            if (curToken.Channel == TokenConstants.DefaultChannel)
            {
                if (curToken.Type == RenpyLexer.NEWLINE)
                {
                    // all the NEWLINE tokens must be ignored before the first statement
                    HideAndAddPendingToken(curToken);
                }
                else
                { // We're at the first statement
                    InsertLeadingIndentToken();
                    return; // continue the processing of the current token with CheckNextToken()
                }
            }
            else
            {
                AddPendingToken(curToken); // it can be WS, EXPLICIT_LINE_JOINING, or COMMENT token
            }
            SetCurrentAndFollowingTokens();
        } // continue the processing of the EOF token with CheckNextToken()
    }

    private void InsertLeadingIndentToken()
    {
        if (previousPendingTokenType == RenpyLexer.WS)
        {
            var prevToken = pendingTokens.Last.Value;
            if (GetIndentationLength(prevToken.Text) != 0) // there is an "indentation" before the first statement
            {
                const string errMsg = "first statement indented";
                ReportLexerError(errMsg);
                // insert an INDENT token before the first statement to raise an 'unexpected indent' error later by the parser
                CreateAndAddPendingToken(RenpyLexer.INDENT, TokenConstants.DefaultChannel, ERR_TXT + errMsg, curToken);
            }
        }
    }

    private void HandleNEWLINEtoken()
    {
        if (opened > 0)
        {
            // We're in an implicit line joining, ignore the current NEWLINE token
            HideAndAddPendingToken(curToken);
        }
        else
        {
            IToken nlToken = new CommonToken(curToken); // save the current NEWLINE token
            bool isLookingAhead = ffgToken.Type == RenpyLexer.WS;
            if (isLookingAhead)
            {
                SetCurrentAndFollowingTokens(); // set the next two tokens
            }

            switch (ffgToken.Type)
            {
                case RenpyLexer.NEWLINE: // We're before a blank line
                case RenpyLexer.COMMENT: // We're before a comment
                    HideAndAddPendingToken(nlToken);
                    if (isLookingAhead)
                    {
                        AddPendingToken(curToken); // WS token
                    }
                    break;
                default:
                    AddPendingToken(nlToken);
                    if (isLookingAhead)
                    { // We're on whitespace(s) followed by a statement
                        int indentationLength = ffgToken.Type == TokenConstants.EOF
                            ? 0
                            : GetIndentationLength(curToken.Text);

                        if (indentationLength == INVALID_LENGTH)
                        {
                            ReportError("inconsistent use of tabs and spaces in indentation");
                        }
                        else
                        {
                            AddPendingToken(curToken);  // WS token
                            InsertIndentOrDedentToken(indentationLength); // may insert INDENT token or DEDENT token(s)                            
                        }
                    }
                    else
                    {
                        // We're at a newline followed by a statement (there is no whitespace before the statement)
                        InsertIndentOrDedentToken(0); // may insert DEDENT token(s)
                    }
                    break;
            }
        }
    }

    private void InsertIndentOrDedentToken(int indentLength)
    {
        int prevIndentLength = indentLengthStack.Peek();
        if (indentLength > prevIndentLength)
        {
            CreateAndAddPendingToken(RenpyLexer.INDENT, TokenConstants.DefaultChannel, null, ffgToken);
            indentLengthStack.Push(indentLength);
        }
        else
        {
            while (indentLength < prevIndentLength)
            { // more than 1 DEDENT token may be inserted into the token stream
                indentLengthStack.Pop();
                prevIndentLength = indentLengthStack.Peek();
                if (indentLength <= prevIndentLength)
                {
                    CreateAndAddPendingToken(RenpyLexer.DEDENT, TokenConstants.DefaultChannel, null, ffgToken);
                }
                else
                {
                    ReportError("inconsistent dedent");
                }
            }
        }
    }

    private void HandleFStringLexerModes()  // https://peps.python.org/pep-0498/#specification
    {
        if (ModeStack.Count > 0)
        {
            switch (curToken.Type)
            {
                case RenpyLexer.LBRACE:
                    PushMode(DEFAULT_MODE);
                    paren_or_bracket_openedStack.Push(0);
                    break;
                case RenpyLexer.LPAR:
                case RenpyLexer.LSQB:
                    // https://peps.python.org/pep-0498/#lambdas-inside-expressions
                    paren_or_bracket_openedStack.Push(paren_or_bracket_openedStack.Pop() + 1); // increment the last element
                    break;
                case RenpyLexer.RPAR:
                case RenpyLexer.RSQB:
                    paren_or_bracket_openedStack.Push(paren_or_bracket_openedStack.Pop() - 1); // decrement the last element
                    break;
                case RenpyLexer.COLON: // colon can only come from DEFAULT_MODE
                    break;
                case RenpyLexer.RBRACE:
                    switch (CurrentMode)
                    {
                        case DEFAULT_MODE:
                            PopMode();
                            paren_or_bracket_openedStack.Pop();
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
    }

    private void InsertTrailingTokens()
    {
        switch (lastPendingTokenTypeFromDefaultChannel)
        {
            case RenpyLexer.NEWLINE:
            case RenpyLexer.DEDENT:
                break; // no trailing NEWLINE token is needed
            default:
                // insert an extra trailing NEWLINE token that serves as the end of the last statement
                CreateAndAddPendingToken(RenpyLexer.NEWLINE, TokenConstants.DefaultChannel, null, ffgToken); // ffgToken is EOF
                break;
        }
        InsertIndentOrDedentToken(0); // Now insert as many trailing DEDENT tokens as needed
    }

    private void HandleEOFtoken()
    {
        if (lastPendingTokenTypeFromDefaultChannel > 0)
        { // there was a statement in the input (leading NEWLINE tokens are hidden)
            InsertTrailingTokens();
        }
        AddPendingToken(curToken);
    }

    private void HideAndAddPendingToken(IToken tkn)
    {
        CommonToken ctkn = new(tkn)
        {
            Channel = TokenConstants.HiddenChannel
        };
        AddPendingToken(ctkn);
    }

    private void CreateAndAddPendingToken(int ttype, int channel, string text, IToken sampleToken)
    {
        CommonToken ctkn = new(sampleToken)
        {
            Type = ttype,
            Channel = channel,
            StopIndex = sampleToken.StartIndex - 1,

            Text = text ?? "<" + Vocabulary.GetSymbolicName(ttype) + ">"
        };

        AddPendingToken(ctkn);
    }

    private void AddPendingToken(IToken tkn)
    {
        // save the last pending token type because the pendingTokens linked list can be empty by the nextToken()
        previousPendingTokenType = tkn.Type;
        if (tkn.Channel == TokenConstants.DefaultChannel)
        {
            lastPendingTokenTypeFromDefaultChannel = previousPendingTokenType;
        }
        pendingTokens.AddLast(tkn);
    }

    private int GetIndentationLength(string indentText) // the indentText may contain spaces, tabs or form feeds
    {
        const int TAB_LENGTH = 8; // the standard number of spaces to replace a tab with spaces
        int length = 0;
        foreach (char ch in indentText)
        {
            switch (ch)
            {
                case ' ':
                    wasSpaceIndentation = true;
                    length += 1;
                    break;
                case '\t':
                    wasTabIndentation = true;
                    length += TAB_LENGTH - length % TAB_LENGTH;
                    break;
                case '\f': // form feed
                    length = 0;
                    break;
            }
        }

        if (wasTabIndentation && wasSpaceIndentation)
        {
            if (!wasIndentationMixedWithSpacesAndTabs)
            {
                wasIndentationMixedWithSpacesAndTabs = true;
                length = INVALID_LENGTH; // only for the first inconsistent indent
            }
        }
        return length;
    }

    private void ReportLexerError(string errMsg)
    {
        ErrorListenerDispatch.SyntaxError(
            output: ErrorOutput,
            recognizer: this,
            offendingSymbol: curToken.Type,
            line: curToken.Line,
            charPositionInLine: curToken.Column,
            msg: " LEXER" + ERR_TXT + errMsg,
            e: null);
    }

    private void ReportError(string errMsg)
    {
        ReportLexerError(errMsg);

        // the ERRORTOKEN will raise an error in the parser
        CreateAndAddPendingToken(RenpyLexer.ERRORTOKEN, TokenConstants.DefaultChannel, ERR_TXT + errMsg, ffgToken);
    }
}