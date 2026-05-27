using System;

namespace MM2Randomizer;

public static class Util
{
    private static readonly byte[] randomWeaknessPool = new byte[MM2.BossCount * MM2.WeaponCount]
    {
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, // 46/112
        0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, // 18/112
        0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, // 16/112
        0x03, 0x03, 0x03, 0x03, //  4/112
        0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, //  9/112
        0x06, 0x06, 0x06, 0x06, 0x06, //  5/112
        0x07, 0x07, 0x07, 0x07, 0x07, //  5/112
        0x0A, 0x0A, 0x0A, 0x0A, //  4/112
        0x0E, 0x0E, 0x0E, 0x0E, //  4/112
        0x1C, //  1/112
    };

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

    public static int[] RepeatedSNESAddressMM1(int address) => new int[0x07]
    {
        0x00_0000 + address,
        0x01_0000 + address,
        0x02_0000 + address,
        0x03_0000 + address,
        0x04_0000 + address,
        0x05_0000 + address,
        0x06_0000 + address,
    };

    public static int[] RepeatedSNESAddressMM2(int address) => new int[0xF]
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

    public static string[] TableToStrings<T>(T[][] arrays)
    {
        if (arrays == null || arrays.Length == 0) return null;

        string[] strings = new string[arrays.Length];

        int i = 0;
        foreach (T[] array in arrays)
        {
            if (array == null || array.Length == 0) continue;

            string s = "";
            foreach (T value in array) if (value != null)
                {
                    string valueString = value.ToString();
                    s += valueString.Length switch
                    {
                        1 => "    ",
                        2 => "   ",
                        3 => "  ",
                        4 => " ",
                        _ => string.Empty
                    } + valueString;
                }

            strings[i++] = s;
        }

        return i == strings.Length ? strings : strings[..i];
    }
}