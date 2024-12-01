using System;

namespace Ryngine.Utils
{
    public class RequiredFieldException(string functionName) : Exception
    {
        public override string Message => $"Function {functionName} must be called before building.";
    }
}
