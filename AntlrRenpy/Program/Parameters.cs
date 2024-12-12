using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program
{
    public class Parameters(
        IEnumerable<string> paramNames,
        Dictionary<string, IExpression> defaultValues,
        int numPositionalOnlyParams,
        int numNameOnlyParams) : IExpression
    {
        /// <summary>
        /// The list of parameter names in the order they appear in the function signature.
        /// </summary>
        public IEnumerable<string> ParamNames { get; } = paramNames;

        /// <summary>
        /// The expressions corresponding to the given parameter names.
        /// </summary>
        public Dictionary<string, IExpression> DefaultValues { get; } = defaultValues;

        /// <summary>
        /// The number of positional-only arguments. The first <see cref="NumPositionalOnlyParams"/> in
        /// <see cref="ParamNames"/> are the names of the positional-only parameters.
        /// </summary>
        public int NumPositionalOnlyParams { get; } = numPositionalOnlyParams;

        /// <summary>
        /// The number of name-only arguments. The last <see cref="NumNameOnlyParams"/> in
        /// <see cref="ParamNames"/> are be the names of the name-only parameters.
        /// </summary>
        public int NumNameOnlyParams { get; } = numNameOnlyParams;
    }
}
