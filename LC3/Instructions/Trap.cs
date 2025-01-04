namespace LC3.Instructions;

public class Trap(ushort raw) : Instruction(raw)
{
    public override void Call(Machine machine)
    {
        machine[Register.Rr7] = machine[Register.RPc];

        switch (Trap)
        {
            case LC3.Trap.TrapGetc:
            {
                machine[Register.Rr0] = Console.ReadKey().KeyChar;
                machine.UpdateFlags(Register.Rr0);

                break;
            }
            case LC3.Trap.TrapOut:
            {
                Console.Write(machine[Register.Rr0]);
                
                break;
            }
            case LC3.Trap.TrapPuts:
            {
                var pc = machine[machine[Register.RPc]];
                machine[Register.Rr7] = pc;

                var i = machine[Register.Rr0];
                while (true)
                {
                    var output = machine[i++];
                    if (output == 0)
                        break;

                    Console.Write((char)output);
                }

                Console.Out.Flush();

                break;
            }
            case LC3.Trap.TrapIn:
            {
                Console.Write("Enter a character: ");
                machine[Register.Rr0] = Console.ReadKey().KeyChar;
                machine.UpdateFlags(Register.Rr0);

                break;
            }
            case LC3.Trap.TrapPutsp:
            {
                machine[Register.Rr7] = machine[Register.RPc];
                var i = machine[Register.Rr0];
                
                while (true)
                {
                    var output = machine[i++];
                    if (output == 0)
                        break;
                    
                    Console.Write((ushort)(output & 0xFF));
                    output >>= 8;
                    
                    if (output == 0)
                        continue;
                    
                    Console.Write(output);
                }

                break;
            }
            case LC3.Trap.TrapHalt:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}