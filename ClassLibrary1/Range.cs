using System.Runtime.CompilerServices;

namespace System;

record Range(Index Start, Index End)
{
    public override string ToString() =>
        $"{Start}..{End}";

    public static Range StartAt(Index start) => new(start, Index.End);

    public static Range EndAt(Index end) => new(Index.Start, end);

    public static Range All => new(Index.Start, Index.End);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public (int Offset, int Length) GetOffsetAndLength(int length)
    {
        int start;
        var startIndex = Start;
        if (startIndex.IsFromEnd)
        {
            start = length - startIndex.Value;
        }
        else
        {
            start = startIndex.Value;
        }

        int end;
        var endIndex = End;
        if (endIndex.IsFromEnd)
        {
            end = length - endIndex.Value;
        }
        else
        {
            end = endIndex.Value;
        }

        if ((uint)end > (uint)length || (uint)start > (uint)end)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        return (start, end - start);
    }
}