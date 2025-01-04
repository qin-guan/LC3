namespace LC3.Instructions;

public class Ldi(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        var memLoc = machine[(ushort)(machine[Register.RPc] + PcOffset)];
        machine[(Register)R0] = machine[memLoc];

        machine.UpdateFlags((Register)R0);
    }
}