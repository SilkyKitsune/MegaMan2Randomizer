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
    //change to winforms?

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
                    MM2.SetBarFillSpeed(data, 0x01);
                    data[(int)Address.MaxETanks] = 0x08;
                    MM2.SetMenuSpeed(data, 0x01);
                    data[(int)Address.LevelCheckRoutine2MemAddress] = 0x99;//will this work?
                    
                    C.WriteLine("Enter seed (leave blank for auto)");
                    bool useCustomSeed = int.TryParse(C.ReadLine(), out int seed);

                    if (!useCustomSeed)
                    {
                        DateTime now = DateTime.Now;
                        seed = ((now.Year * 10000) + (now.Month * 100) + now.Day) ^ E.TickCount;
                    }

                    Random r = new(seed);
                    string spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n-\n" + MM2.ShuffleWeapons(data, r) + MM2.ShuffleItems(data, r);

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

    private static int ReadROMFile(out byte[] data, string filePath)
    {
        data = null;
        if (string.IsNullOrEmpty(filePath) || !F.Exists(filePath)) return 0;

        data = F.ReadAllBytes(filePath);
        if (data.Length != MM2.RomSize) return -1;

        //other validation?

        return 1;
    }

    private static int WriteROMFile(string directory, int seed, byte[] data, string spoiler = null)
    {
        if (data == null || data.Length == 0) return -1;

        string dir = P.GetDirectoryName(directory);
        if (string.IsNullOrEmpty(dir)) return 0;

        string outPath = P.Combine(dir, "MM2R_" + seed);
        F.WriteAllBytes(outPath + ".nes", data);
        if (!string.IsNullOrEmpty(spoiler)) F.WriteAllText(outPath + "_Spoiler.txt", spoiler);

        return 1;
    }
}