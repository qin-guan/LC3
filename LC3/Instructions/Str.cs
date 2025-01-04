namespace LC3.Instructions;

public class Str(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[(ushort)(machine[(Register)R1] + Offset)] = machine[(Register)R0];
    }
}