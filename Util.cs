using System;
using ProjectFox.CoreEngine.Collections;

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

    public static byte[][] ShuffleWeaknesses(out string spoiler, Random r = null, int shuffleMode = 0, int shuffleCount = 8, byte[][] weaknessSets = null)
    {
        if (weaknessSets == null || weaknessSets.Length == 0)
        {
            spoiler = null;
            return null;
        }

        r ??= new(GetSeed());

        shuffleCount = Math.Clamp(shuffleCount, 0, weaknessSets.Length);

        byte[][] newWeaknessSets = new byte[weaknessSets.Length][];
        switch (shuffleMode)
        {
            default:
                {
                    spoiler = "- \"Vanilla\" Weaknesses -";
                    for (int i = 0; i < shuffleCount; i++)
                    {
                        byte[] weaknessSet = weaknessSets[i], newWeaknessSet = newWeaknessSets[i] = new byte[weaknessSet.Length];
                        weaknessSet.CopyTo(newWeaknessSet, 0);
                    }
                    break;
                }
            case 1:
                {
                    spoiler = "- Boss Sets Weakness Shuffle -";
                    AutoSizedArray<byte[]> weaknessSetsPool = new(weaknessSets[..shuffleCount], shuffleCount);
                    for (int i = 0; weaknessSetsPool.Length > 0; i++)
                    {
                        int n = r.Next(weaknessSetsPool.Length);
                        byte[] weaknessSet = weaknessSetsPool[n];

                        newWeaknessSets[i] = new byte[weaknessSet.Length];
                        weaknessSet.CopyTo(newWeaknessSets[i], 0);

                        weaknessSetsPool.RemoveAt(n);
                    }
                    break;
                }
            case 2:
                {
                    spoiler = "- Per Boss Weakness Shuffle -";
                    for (int i = 0; i < shuffleCount; i++)
                    {
                        byte[] weaknessSet = weaknessSets[i], newWeaknessSet = newWeaknessSets[i] = new byte[weaknessSet.Length];
                        AutoSizedArray<byte> weaknessPool = new(weaknessSet, weaknessSet.Length);
                        for (int j = 0; weaknessPool.Length > 0; j++)
                        {
                            int n = r.Next(weaknessPool.Length);
                            byte weakness = weaknessPool[n];

                            newWeaknessSet[j] = weakness;
                            weaknessPool.RemoveAt(n);
                        }
                    }
                    break;
                }
            case 3:
                {
                    spoiler = "- Random Balanced Weaknesses -";
                    for (int i = 0; i < shuffleCount; i++)
                    {
                        byte[] newWeaknessSet = newWeaknessSets[i] = new byte[weaknessSets[i].Length];
                        for (int j = 0; j < newWeaknessSet.Length; j++)
                            newWeaknessSet[j] = randomWeaknessPool[r.Next(randomWeaknessPool.Length)];
                    }
                    break;
                }
            case 4:
                {
                    spoiler = "- Random Random Weaknesses -";
                    for (int i = 0; i < shuffleCount; i++)
                    {
                        byte[] newWeaknessSet = newWeaknessSets[i] = new byte[weaknessSets[i].Length];
                        for (int j = 0; j < newWeaknessSet.Length; j++)
                            newWeaknessSet[j] = (byte)(sbyte)(r.Next(0x1E) - 1);
                    }
                    break;
                }
        }

        for (int i = shuffleCount; i < weaknessSets.Length; i++)
        {
            byte[] weaknessSet = weaknessSets[i], newWeaknessSet = newWeaknessSets[i] = new byte[weaknessSet.Length];
            weaknessSet.CopyTo(newWeaknessSet, 0);
        }

        foreach (byte[] newWeaknessSet in newWeaknessSets)
        {
            bool immuneToAllWeapons = true;
            foreach (byte newWeakness in newWeaknessSet)
                if (newWeakness != 0x00 && newWeakness != 0xFF)
                {
                    immuneToAllWeapons = false;
                    break;
                }
            if (immuneToAllWeapons) newWeaknessSet[0] = 4;
        }

        bool allImmuneToBuster = true;
        for (int i = 0; i < shuffleCount; i++)
        {
            byte newWeakness = newWeaknessSets[i][0];
            if (newWeakness != 0x00 && newWeakness != 0xFF)
            {
                allImmuneToBuster = false;
                break;
            }
        }
        if (allImmuneToBuster) newWeaknessSets[r.Next(shuffleCount)][0] = 4;

        return newWeaknessSets;
    }

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