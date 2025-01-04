namespace LC3.Instructions;

public class And(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        if (ImmFlag == 1)
        {
            machine[(Register)R0] = (ushort)(machine[(Register)R1] & Imm5);
        }
        else
        {
            machine[(Register)R0] = (ushort)(machine[(Register)R1] & machine[(Register)R2]);
        }

        machine.UpdateFlags((Register)R0);
    }
}