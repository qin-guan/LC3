namespace LC3;

public enum Trap : ushort
{
    TrapGetc = 0x20, /* get character from keyboard, not echoed onto the terminal */
    TrapOut = 0x21, /* output a character */
    TrapPuts = 0x22, /* output a word string */
    TrapIn = 0x23, /* get character from keyboard, echoed onto the terminal */
    TrapPutsp = 0x24, /* output a byte string */
    TrapHalt = 0x25 /* halt the program */
}