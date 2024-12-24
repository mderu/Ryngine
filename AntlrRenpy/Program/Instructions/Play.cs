using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public record class Play(
        string ChannelName,
        IExpression WhatToPlay,
        ConstantNumber? FadeIn,
        ConstantNumber? FadeOut) : IInstruction
    {
    }
}
