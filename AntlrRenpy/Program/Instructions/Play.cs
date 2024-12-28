

using AntlrRenpy.Program.Expressions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class Play(
    string ChannelName,
    IExpression WhatToPlay,
    AtomicNumber? FadeIn,
    AtomicNumber? FadeOut) : IInstruction
{
}
