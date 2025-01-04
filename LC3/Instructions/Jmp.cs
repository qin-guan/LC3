namespace LC3.Instructions;

public class Jmp(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[Register.RPc] = machine[(Register)R1];
    }
}