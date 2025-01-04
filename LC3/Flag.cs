namespace LC3;

public enum Flag : ushort
{
    FlPos = 1 << 0, /* P */
    FlZro = 1 << 1, /* Z */
    FlNeg = 1 << 2, /* N */
};