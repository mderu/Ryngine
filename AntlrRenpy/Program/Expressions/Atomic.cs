using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public enum AtomicType
{
    Null,
    Int,
    Float,
    String,
    Dict,
    List,

    // Weird atomics, still trying to figure out what to do with these.
    Arguments,
}

public static class AtomicTypes
{
    public static string GetName(this AtomicType type)
    {
        return type switch
        {
            AtomicType.Null => "NoneType",
            AtomicType.Int => "int",
            AtomicType.Float => "float",
            AtomicType.String => "str",
            AtomicType.Dict => "dict",
            AtomicType.List => "list",
            _ => throw new NotImplementedException($"AtomicType {type} does not have a string representation.")
        };
    }
}

public abstract record class Atomic(object? InnerValue) : IAtomic
{
    public abstract AtomicType Type { get; }

    public IAtomic EvaluateValue()
    {
        return this;
    }

    public Atomic Add(Atomic other)
    {
        if (this is Null)
        {
            string otherType = other.Type.GetName();
            throw new Exception($"TypeError: unsupported operand type(s) for +: 'NoneType' and '{otherType}'");
        }
        else if (this is AtomicNumber thisNumber)
        {
            if (other is AtomicNumber otherNumber)
            {
                // TODO: Implement real python math.
                return new AtomicNumber($"{decimal.Parse(thisNumber.Value) + decimal.Parse(otherNumber.Value)}");
            }
            else
            {
                string otherType = other.Type.GetName();
                throw new Exception($"TypeError: unsupported operand type(s) for +: 'int' and '{otherType}'");
            }
        }
        else if (this is Atomic<string> thisString)
        {
            if (other is Atomic<string> otherString)
            {
                return new Atomic<string>(thisString.Value + otherString.Value);
            }
            else
            {
                string otherType = other.Type.GetName();
                throw new Exception($"TypeError: can only concatenate str (not \"{otherType}\") to str");
            }
        }
        else
        {
            throw new NotImplementedException($"Need to implement the Add operator for {Type.GetName()}.");
        }
    }

    public bool IsTruthy()
    {
        if (this is Null)
        {
            return false;
        }
        else if (this is AtomicNumber thisNumber)
        {
            // TODO: Implement real python number checking.
            return decimal.Parse(thisNumber.Value) is not 0;
        }
        else if (this is Atomic<string> thisString)
        {
            return !string.IsNullOrEmpty(thisString.Value);
        }
        else
        {
            throw new InvalidOperationException($"Unable to determine IsTruthy for {Type.GetName()}.");
        }
    }
}

public record class Atomic<T>(T Value) : Atomic(Value)
{
    public override AtomicType Type => 
        Value is null
            ? AtomicType.Null :
        Value is string 
            ? AtomicType.String :
        throw new Exception($"Unexpected scalar type {typeof(T)}");
}
