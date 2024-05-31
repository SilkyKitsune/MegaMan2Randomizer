using System;
using ProjectFox.CoreEngine.Collections;
using IPSLib;

namespace MM2Randomizer;

public static class MM2
{
    private static readonly Equipment[]
        weapons =
    {
        Equipment.AtomicFire,
        Equipment.AirShooter,
        Equipment.LeafShield,
        Equipment.BubbleLead,
        Equipment.QuickBoomerang,
        Equipment.FlashStopper,
        Equipment.MetalBlade,
        Equipment.CrashBomber
    },
        items =
    {
        Equipment.Item1,
        Equipment.Item3,
        Equipment.None,
        Equipment.None,
        Equipment.None,
        Equipment.None,
        Equipment.None,
        Equipment.Item2,
    };

    private static readonly StageIndex[] stages =
    {
        StageIndex.HeatStage,
        StageIndex.AirStage,
        StageIndex.WoodStage,
        StageIndex.BubbleStage,
        StageIndex.QuickStage,
        StageIndex.FlashStage,
        StageIndex.MetalStage,
        StageIndex.CrashStage
    };
    
    private static int GetSeed()
    {
        int ms = Environment.TickCount;
        DateTime now = DateTime.Now;
        return ms ^ ((now.Year * 10000) + (now.Month * 100) + now.Day);
    }

    private static IPS ShuffleItemsPatch(ref string spoiler, Random r = null, bool heatManNoItem2 = false)
    {
        r ??= new(GetSeed());

        spoiler += "\n";
        
        AutoSizedArray<Equipment> equips = new(items);

        byte[] data = new byte[equips.Length];
        
        Address address = Address.HeatStageItem;

        for (int i = 0; equips.Length > 0; i++, address++)
        {
            int n = r.Next(equips.Length - (heatManNoItem2 && i == 0 ? 1 : 0));
            Equipment e = equips[n];
            spoiler += $"{address} => {e}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        IPS ips = new();
        ips.Add(false, (int)Address.HeatStageItem, data);
        return ips;
    }
    
    private static IPS ShuffleStagesPatch(ref string spoiler, Random r = null)
    {
        r ??= new(GetSeed());

        spoiler += "\n";

        AutoSizedArray<StageIndex> stages = new(MM2.stages);

        byte[] data = new byte[stages.Length];

        Address address = Address.BubbleStagePtr;
        for (int i = 0; stages.Length > 0; i++, address++)
        {
            int n = r.Next(stages.Length);
            StageIndex si = stages[n];
            spoiler += $"{address} => {si}\n";
            data[i] = (byte)si;
            stages.RemoveAt(n);
        }

        IPS ips = new();
        ips.Add(false, (int)Address.BubbleStagePtr, data);
        return ips;
    }

    private static IPS ShuffleWeaponsPatch(ref string spoiler, Random r = null)
    {
        r ??= new(GetSeed());

        AutoSizedArray<Equipment> equips = new(weapons);

        byte[] data = new byte[equips.Length];

        Address address = Address.HeatStageWeapon;
        for (int i = 0; equips.Length > 0; i++, address++)
        {
            int n = r.Next(equips.Length);
            Equipment e = equips[n];
            spoiler += $"{address} => {e}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        IPS ips = new();
        ips.Add(false, (int)Address.WeaponBitMasks, data);
        return ips;
    }

    public static void Generate(ref IPS ips, ref int seed, out string spoiler, bool heatManNoItem2 = false, bool shuffleLevels = false)
    {
        if (seed == 0) seed = GetSeed();
        ips ??= new();
        spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n\n";
        Random r = new(seed);

        ips.Add(ShuffleWeaponsPatch(ref spoiler, r), false);
        ips.Add(ShuffleItemsPatch(ref spoiler, r, heatManNoItem2), false);
        if (shuffleLevels) ips.Add(ShuffleStagesPatch(ref spoiler, r), false);
    }
}