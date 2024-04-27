namespace System.Runtime.CompilerServices;

static class RuntimeHelpers
{
    /// <summary>
    /// Slices the specified array using the specified range.
    /// </summary>
    public static T[] GetSubArray<T>(T[] array, Range range)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        var (offset, length) = range.GetOffsetAndLength(array.Length);

        if (length == 0)
        {
            return [];
        }

        var dest = new T[length];

        Array.Copy(array, offset, dest, 0, length);

        return dest;
    }
}