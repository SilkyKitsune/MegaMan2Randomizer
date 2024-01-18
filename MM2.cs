using System;
using System.Collections.Generic;

namespace MM2Randomizer;

public static class MM2
{
    public const int RomSize = 0x40010;

    public static void ChangeBooBeamCrashWalls(byte[] data)
    {
        data[(int)Address.BoomBeamCrashWall0] = (byte)Pickups.BigWeapon;
        data[(int)Address.BoomBeamCrashWall1] = (byte)Pickups.BigWeapon;
        data[(int)Address.BoomBeamCrashWall2] = (byte)Pickups.BigWeapon;
        data[(int)Address.BoomBeamCrashWall3] = (byte)Pickups.ETank;
        data[(int)Address.BoomBeamCrashWall4] = (byte)Pickups.OneUp;
    }

    public static void SetBarFillSpeed(byte[] data, byte fillSpeed)
    {
        data[(int)Address.RobotHealthFillSpeed] = fillSpeed;
        data[(int)Address.CastleHealthFillSpeed] = fillSpeed;
        data[(int)Address.PlayerHealthFillSpeedPaused] = fillSpeed;
        data[(int)Address.PlayerHealthFillSpeed] = fillSpeed;
        data[(int)Address.PlayerWeaponFillSpeed] = fillSpeed;
    }

    public static void SetMenuSpeed(byte[] data, byte menuTime)
    {
        data[(int)Address.WilyMapTime] = menuTime;
        data[(int)Address.WeaponGetTime] = menuTime;
        data[(int)Address.MenuFlashTime] = menuTime;
        data[(int)Address.ItemGetTime] = menuTime;
        data[(int)Address.TextPrintSpeed] = 0x03;//change this one?
        data[(int)Address.PausePrintTime] = menuTime;
    }

    public static string ShuffleWeapons(byte[] data, Random r)
    {
        string spoiler = "";
        List<Equipment> equips = new(new Equipment[]
                {
                    Equipment.AtomicFire,
                    Equipment.AirShooter,
                    Equipment.LeafShield,
                    Equipment.BubbleLead,
                    Equipment.QuickBoomerang,
                    Equipment.FlashStopper,
                    Equipment.MetalBlade,
                    Equipment.CrashBomber,
                });
        int address = (int)Address.HeatStageWeapon;
        while (equips.Count > 0)
        {
            int i = r.Next(equips.Count);
            Equipment e = equips[i];
            spoiler += $"{(Address)address} => {e}\n";
            data[address++] = (byte)e;
            equips.RemoveAt(i);
        }
        return spoiler;
    }

    public static string ShuffleItems(byte[] data, Random r)
    {
        string spoiler = "\n";
        List<Equipment> equips = new(new Equipment[]
                {
                    Equipment.Item1,
                    Equipment.Item2,
                    Equipment.Item3,
                    Equipment.None,
                    Equipment.None,
                    Equipment.None,
                    Equipment.None,
                    Equipment.None,
                });
        int address = (int)Address.HeatStageItem;
        while (equips.Count > 0)
        {
            int i = r.Next(equips.Count);
            Equipment e = equips[i];
            spoiler += $"{(Address)address} => {e}\n";
            data[address++] = (byte)e;
            equips.RemoveAt(i);
        }
        return spoiler;
    }

    public static string ShuffleStages(byte[] data, Random r)
    {
        string spoiler = "\n";
        List<StageIndex> stages = new(new StageIndex[]
                {
                    StageIndex.HeatStage,
                    StageIndex.AirStage,
                    StageIndex.WoodStage,
                    StageIndex.BubbleStage,
                    StageIndex.QuickStage,
                    StageIndex.FlashStage,
                    StageIndex.MetalStage,
                    StageIndex.CrashStage
                });
        int address = (int)Address.BubbleStagePtr;
        while (stages.Count > 0)
        {
            int i = r.Next(stages.Count);
            StageIndex si = stages[i];
            spoiler += $"{(Address)address} => {si}\n";
            data[address++] = (byte)si;
            stages.RemoveAt(i);
        }
        return spoiler;
    }
}
