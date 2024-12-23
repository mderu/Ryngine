﻿using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.ControlFlows
{
    public record class While(Block Block, IExpression Condition, Else? ElseStatement) : IInstruction
    {
    }
}
