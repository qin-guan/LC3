namespace LC3.Instructions;

public class Br(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        var condFlag = (Op >> 9) & 0x7;

        if ((condFlag & machine[Register.RCond]) == 1)
        {
            machine[Register.RPc] += PcOffset;
        }
    }
}