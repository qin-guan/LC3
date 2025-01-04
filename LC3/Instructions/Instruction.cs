namespace LC3.Instructions;

public abstract class Instruction(ushort raw)
{
    public ushort Raw => raw;
    public ushort Op => (ushort)(raw >> 12);
    public ushort R0 => (ushort)((raw >> 9) >> 7);
    public ushort R1 => (ushort)((raw >> 6) >> 7);
    public ushort R2 => (ushort)(raw >> 7);
    public ushort ImmFlag => (ushort)((raw >> 5) & 0x1);
    public ushort Imm5 => (raw & 0x1F).SignExtend(5);
    public ushort PcOffset => (Op & 0x1FF).SignExtend(9);
    public ushort LongFlag => (ushort)((raw >> 11) & 1);
    public ushort LongPcOffset => (raw & 0x7FF).SignExtend(11);
    public ushort Offset => (raw & 0x3F).SignExtend(6);
    public LC3.Trap Trap => (LC3.Trap)(raw & 0xFF);


    public abstract void Call(Machine machine);
}