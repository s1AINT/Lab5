using System;

class Program
{
    static void Main()
    {
        byte result1 = Mul02(0xD4);
        byte result2 = Mul03(0xBF);

        Console.WriteLine("D4 * 02 = " + result1.ToString("X2"));
        Console.WriteLine("BF * 03 = " + result2.ToString("X2"));
    }

    // Множення на 02
    static byte Mul02(byte value)
    {
        if ((value & 0x80) != 0)
        {
            // Якщо найважливіший біт 1, то відбувається переповнення
            value = (byte)(value << 1);
            value ^= 0x1B; // Додавання x в полі Галуа
        }
        else
        {
            value = (byte)(value << 1);
        }
        return value;
    }

    // Множення на 03
    static byte Mul03(byte value)
    {
        return (byte)(Mul02(value) ^ value);
    }
}
