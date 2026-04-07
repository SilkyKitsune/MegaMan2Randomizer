using System;

namespace MM2Randomizer;

public static class Util
{
    public static int GetSeed()
    {
        int ms = Environment.TickCount;
        DateTime now = DateTime.Now;
        return ms ^ ((now.Year * 10000) + (now.Month * 100) + now.Day);
    }

    public static byte[] Rearrange(byte[][] data)
    {
        byte[] newData = new byte[data.Length * data[0].Length];

        for (int i = 0, k = 0, l = data[0].Length; i < l; i++)
            for (int j = 0; j < data.Length; j++)
                newData[k++] = data[j][i];

        return newData;
    }

    public static int[] RepeatedSNESAddress(int address) => new int[0xF]
    {
        0x00_0000 + address, 0x00_8000 + address,
        0x01_0000 + address, 0x01_8000 + address,
        0x02_0000 + address, 0x02_8000 + address,
        0x03_0000 + address, 0x03_8000 + address,
        0x04_0000 + address, 0x04_8000 + address,
        0x05_0000 + address, 0x05_8000 + address,
        0x06_0000 + address,
        0x07_0000 + address, 0x07_8000 + address,
    };
}