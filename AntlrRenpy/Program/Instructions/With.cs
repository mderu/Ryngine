using AntlrRenpy.Program.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrRenpy.Program.Instructions
{
    public record class With(IExpression expression) : IInstruction
    {
    }
}
