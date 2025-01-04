namespace LC3.Instructions;

public class Ldr(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[(Register)R0] = machine[(ushort)(machine[(Register)R1] + Offset)];
        
        machine.UpdateFlags((Register)R0);
    }
}