namespace LC3;

public static class Extensions
{
    public static ushort SignExtend(this int x, int bitCount)
    {
        return ((ushort)x).SignExtend(bitCount);
    }

    public static ushort SignExtend(this ushort x, int bitCount)
    {
        if ((x >> (bitCount - 1) & 1) != 0)
        {
            x |= (ushort)(0xFFFF << bitCount);
        }

        return x;
    }

    public static ushort Swap(this ushort x)
    {
        return (ushort)((x << 8) | (x >> 8));
    }
}