namespace LC3.Instructions;

public class Not(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[(Register)R0] = (ushort)~machine[(Register)R1];
        machine.UpdateFlags((Register)R0);
    }
}