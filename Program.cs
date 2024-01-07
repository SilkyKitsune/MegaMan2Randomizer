using System;
using C = System.Console;
using E = System.Environment;
using F = System.IO.File;
using P = System.IO.Path;

namespace MM2Randomizer;

public static class Program
{
    //Never item 2 on heat man
    //add ips option

    private const byte FillSpeed = 0x01, MenuTime = 0x01;

    private const int RomSize = 262160;

    private const string FileName = "MM2R_", FileExt = ".nes", SpoilerName = "_Spoiler.txt", SpoilerHeader = "--- MM2R Spoiler Log ---\n";

    private static void Main()
    {
        C.WriteLine("Specify rom path...");
        string path = C.ReadLine();
        switch (ReadROMFile(out byte[] data, path))
        {
            case 0:
                C.WriteLine("Invalid path!");
                break;
            case -1:
                C.WriteLine("Invalid ROM!");
                break;
            case 1:
                {
                    MM2.ChangeBooBeamCrashWalls(data);
                    MM2.SetBarFillSpeed(data, FillSpeed);
                    data[(int)Address.MaxETanks] = 0x08;
                    MM2.SetMenuSpeed(data, MenuTime);
                    data[(int)Address.LevelCheckRoutine2MemAddress] = 0x99;//will this work?
                    
                    C.WriteLine("Enter seed (leave blank for auto)");
                    bool useCustomSeed = int.TryParse(C.ReadLine(), out int seed);

                    if (!useCustomSeed)
                    {
                        DateTime now = DateTime.Now;
                        seed = ((now.Year * 10000) + (now.Month * 100) + now.Day) ^ E.TickCount;
                    }

                    Random r = new(seed);
                    string spoiler = SpoilerHeader + $"Seed: {seed}\n-\n" + MM2.ShuffleWeapons(data, r) + MM2.ShuffleItems(data, r);

                    C.WriteLine("Shuffle levels? 'y' or 'n'");
                    if (C.ReadLine() == "y") spoiler += MM2.ShuffleStages(data, r);

                    switch (WriteROMFile(path, seed, data, spoiler))
                    {
                        case 0:
                            C.WriteLine("Invalid path!");
                            break;
                        case -1:
                            C.WriteLine("Invalid ROM!");
                            break;
                    }
                    C.WriteLine(spoiler);
                    break;
                }
        }
    }

    [Obsolete] private static void old()
    {
        C.WriteLine("Specify rom path...");
        string path = C.ReadLine();
        if (!string.IsNullOrEmpty(path) && F.Exists(path))
        {
            byte[] data = F.ReadAllBytes(path);
            C.WriteLine($"Size of file: {data.Length}");
            if (data.Length != RomSize)
            {
                C.WriteLine("Invalid ROM!");
                return;
            }

            MM2.ChangeBooBeamCrashWalls(data);
            MM2.SetBarFillSpeed(data, FillSpeed);
            data[(int)Address.MaxETanks] = 0x08;
            MM2.SetMenuSpeed(data, MenuTime);
            data[(int)Address.LevelCheckRoutine2MemAddress] = 0x99;//will this work?

            int seed = E.TickCount;
            Random r = new(seed);
            string spoiler = $"Seed: {seed}\n-\n";

            spoiler += MM2.ShuffleWeapons(data, r);
            spoiler += MM2.ShuffleItems(data, r);

            C.WriteLine("Shuffle levels? 'y' or 'n'");
            string s = C.ReadLine();
            if (s == "y") spoiler += MM2.ShuffleStages(data, r);

            string outPath = P.Combine(P.GetDirectoryName(path), FileName + seed);
            F.WriteAllBytes(outPath + FileExt, data);
            F.WriteAllText(outPath + SpoilerName, spoiler);

            C.WriteLine("--- Spoiler ---\n");
            C.WriteLine(spoiler);
            C.WriteLine("-----\n");
        }
        else C.WriteLine("Invalid path!");
    }

    private static int ReadROMFile(out byte[] data, string filePath)
    {
        data = null;
        if (string.IsNullOrEmpty(filePath) || !F.Exists(filePath)) return 0;

        data = F.ReadAllBytes(filePath);
        if (data.Length != RomSize) return -1;

        //other validation?

        return 1;
    }

    private static int WriteROMFile(string directory, int seed, byte[] data, string spoiler = null)
    {
        if (data == null || data.Length == 0) return -1;

        string dir = P.GetDirectoryName(directory);
        if (string.IsNullOrEmpty(dir)) return 0;

        string outPath = P.Combine(dir, FileName + seed);
        F.WriteAllBytes(outPath + FileExt, data);
        if (!string.IsNullOrEmpty(spoiler)) F.WriteAllText(outPath + SpoilerName, spoiler);

        return 1;
    }
}