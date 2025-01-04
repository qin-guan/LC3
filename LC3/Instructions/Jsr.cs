namespace LC3.Instructions;

public class Jsr(ushort raw): Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[Register.Rr7] = machine[Register.RPc];
        if (LongFlag == 1)
        {
            machine[Register.RPc] += LongPcOffset; /* JSR */
        }
        else
        {
            machine[Register.RPc] = machine[(Register)R1]; /* JSRR */
        }
    }
}