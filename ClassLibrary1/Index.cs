namespace System;

using System.Runtime.CompilerServices;

readonly struct Index : IEquatable<Index>
{
    readonly int _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Index(int value, bool fromEnd = false)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        if (fromEnd)
        {
            _value = ~value;
        }
        else
        {
            _value = value;
        }
    }

    Index(int value) =>
        _value = value;

    public static Index Start => new(0);

    public static Index End => new(~0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromStart(int value)
    {
        if (value < 0)
        {
            throw new IndexOutOfRangeException(nameof(value));
        }

        return new(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromEnd(int value)
    {
        if (value < 0)
        {
            throw new IndexOutOfRangeException(nameof(value));
        }

        return new(~value);
    }

    public int Value
    {
        get
        {
            if (_value < 0)
            {
                return ~_value;
            }

            return _value;
        }
    }

    public bool IsFromEnd => _value < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetOffset(int length)
    {
        var offset = _value;
        if (IsFromEnd)
        {
            offset += length + 1;
        }

        return offset;
    }

    public override bool Equals(object value) => value is Index index && _value == index._value;

    public bool Equals(Index other) => _value == other._value;

    public override int GetHashCode() => _value;

    public static implicit operator Index(int value) => FromStart(value);

    public override string ToString()
    {
        if (IsFromEnd)
        {
            return ToStringFromEnd();
        }

        return ((uint)Value).ToString();
    }

    string ToStringFromEnd() =>
        '^' + Value.ToString();
}