using AntlrRenpy.Program;
using static RenpyParser;
using System.Diagnostics.CodeAnalysis;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Listener;

public partial class RenpyListener : RenpyParserBaseListener
{
    private readonly Queue<Parameter> parameterQueue = [];

    public override void ExitParam_no_default([NotNull] Param_no_defaultContext context)
    {
        string parameterName = context.param().NAME().GetText();
        parameterQueue.Enqueue(new Parameter(parameterName));
    }

    public override void ExitParam_with_default([NotNull] Param_with_defaultContext context)
    {
        string parameterName = context.param().NAME().GetText();
        IExpression defaultValue = expressionStack.Pop();
        parameterQueue.Enqueue(new Parameter(parameterName, defaultValue));
    }

    public override void EnterParameters([NotNull] ParametersContext context)
    {
        if (parameterQueue.Count > 0)
        {
            throw new InvalidOperationException("Began parameters with items still in the parameter queue.");
        }
    }

    public override void ExitParameters([NotNull] ParametersContext context)
    {
        List<string> paramNames = [];
        Dictionary<string, IExpression> defaultValues = [];

        while (parameterQueue.Count > 0)
        {
            Parameter curParam = parameterQueue.Dequeue();
            paramNames.Add(curParam.Name);

            if (curParam.DefaultValue is not null)
            {
                defaultValues[curParam.Name] = curParam.DefaultValue;
            }
        }

        int numPositionalParameters = 0;
        int numNameOnlyParameters = 0;
        for (int i = 0; i < context.ChildCount; i++)
        {
            if (context.children[i] == context.SLASH())
            {
                numPositionalParameters = i - 1;
            }
            else if (context.children[i] == context.STAR())
            {
                numNameOnlyParameters = context.ChildCount - i - 1;

                // Subtract the non-parameters ('/' ',') if they were present.
                if (numPositionalParameters > 0)
                {
                    numNameOnlyParameters -= 2;
                }
            }
        }

        expressionStack.Push(new Parameters(paramNames, defaultValues, numPositionalParameters, numNameOnlyParameters));
    }
}
