namespace LC3.Instructions;

public class Sti(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[machine[(ushort)(machine[Register.RPc] + PcOffset)]] = machine[(Register)R0];
    }
}