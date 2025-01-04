using LC3.Instructions;

namespace LC3;

public class Machine
{
    private readonly ushort[] _registers = new ushort[(int)Register.RCount];
    private readonly ushort[] _memory = new ushort[ushort.MaxValue];

    public ushort this[Register register]
    {
        get => _registers[(int)register];
        set => _registers[(int)register] = value;
    }

    public ushort this[Mmr mmr]
    {
        get
        {
            if (mmr is Mmr.MrKbsr)
            {
                if (Console.KeyAvailable)
                {
                    _memory[(ushort)Mmr.MrKbsr] = 1 << 15;
                    _memory[(ushort)Mmr.MrKbdr] = Console.ReadLine()?.First() ?? throw new Exception("Invalid key");
                }
                else
                {
                    _memory[(ushort)Mmr.MrKbsr] = 0;
                }
            }

            return _memory[(ushort)mmr];
        }

        set => _memory[(ushort)mmr] = value;
    }

    public ushort this[ushort address]
    {
        get => _memory[address];
        set => _memory[address] = value;
    }

    public Machine(string path)
    {
        var s = new FileStream(path, FileMode.Open, FileAccess.Read);
        var reader = new BinaryReader(s);
        var origin = reader.ReadUInt16().Swap();

        var maxRead = ushort.MaxValue - origin;

        for (var i = 0; i < maxRead; i++)
        {
            if (reader.BaseStream.Position == reader.BaseStream.Length)
                break;
            this[(ushort)(i + origin)] = reader.ReadUInt16().Swap();
        }

        this[Register.RPc] = origin;
    }

    public void Start()
    {
        this[Register.RCond] = (ushort)Flag.FlZro;
        this[Register.RPc] = 0x3000;

        while (true)
        {
            var instr = this[this[Register.RPc]];
            this[Register.RPc]++;

            var op = instr >> 12;
            
            Console.WriteLine("{0:b8}", instr);
            
            Instruction i = (((OpCode)op) switch
            {
                OpCode.OpBr => new Br(instr),
                OpCode.OpAdd => new Add(instr),
                OpCode.OpLd => new Ld(instr),
                OpCode.OpSt => new St(instr),
                OpCode.OpJsr => new Jsr(instr),
                OpCode.OpAnd => new And(instr),
                OpCode.OpLdr => new Ldr(instr),
                OpCode.OpStr => new Str(instr),
                OpCode.OpRti => new Rti(instr),
                OpCode.OpNot => new Not(instr),
                OpCode.OpLdi => new Ldi(instr),
                OpCode.OpSti => new Sti(instr),
                OpCode.OpJmp => new Jmp(instr),
                OpCode.OpRes => new Res(instr),
                OpCode.OpLea => new Lea(instr),
                OpCode.OpTrap => new Instructions.Trap(instr),
                _ => throw new ArgumentOutOfRangeException()
            });

            i.Call(this);
        }
    }

    public void UpdateFlags(Register r)
    {
        if (this[r] == 0)
        {
            this[Register.RCond] = (ushort)Flag.FlZro;
        }
        else if (this[r] >> 15 == 1) /* a 1 in the left-most bit indicates negative */
        {
            this[Register.RCond] = (ushort)Flag.FlNeg;
        }
        else
        {
            this[Register.RCond] = (ushort)Flag.FlPos;
        }
    }
}