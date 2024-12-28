using AntlrRenpy.Program.Expressions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Clauses;

// https://www.renpy.org/doc/html/transitions.html
public record class Transition(IExpression Expression)
{

}
