namespace LC3.Instructions;

public class Ld(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[(Register)R0] = machine[(ushort)(machine[Register.RPc] + PcOffset)];

        machine.UpdateFlags((Register)R0);
    }
}