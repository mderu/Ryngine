parser grammar RenpyParser;
options {
    tokenVocab=RenpyLexer;
    superClass=RenpyParserBase;
}

entire_tree: statements? NEWLINE* EOF;

statements
    : statement (NEWLINE+ statement)*
    ;

statement
    : simple_statements
    ;

block
    : NEWLINE INDENT statements DEDENT
    | simple_statements
    ;

simple_statements
    : pass_statement
    | jump
    | label
    | call
    | return
    | say
    ;

pass_statement
    : PASS
    ;

label
    // https://www.renpy.org/doc/html/label.html
    : label_constant
    ;

label_constant
    : LABEL label_name (COLON | COLON block)? // Yes, blocks aren't actually required.
    ;

label_name
    : DOT? NAME
    ;

jump
    : jump_constant
    ;

jump_constant
    : JUMP label_name
    ;

call
    : call_constant
    ;

call_constant
    : CALL label_name
    ;

return
    : return_simple
    ;

return_simple
    : RETURN
    ;

say
    : NAME STRING
    | STRING
    ;