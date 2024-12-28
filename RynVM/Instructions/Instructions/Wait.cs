using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RynVM.Instructions.Statements
{
    /// <summary>
    /// An instruction that waits until the user has clicked or tapped through the dialog.
    /// 
    /// Note that not all clicks/taps are intercepted by a Wait; e.g., dialog boxes have the {w} tag that consumes a
    /// click/tap.
    /// </summary>
    public record struct Wait : IInstruction
    {
    }
}
