namespace LC3.Instructions;

public class Rti(ushort raw): Instruction(raw)
{
    public override void Call(Machine machine)
    {
        throw new NotImplementedException();
    }
}