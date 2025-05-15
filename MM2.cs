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
        StageIndex.HeatMan,
        StageIndex.AirMan,
        StageIndex.WoodMan,
        StageIndex.BubbleMan,
        StageIndex.QuickMan,
        StageIndex.FlashMan,
        StageIndex.MetalMan,
        StageIndex.CrashMan
    };
    
    private static int GetSeed()
    {
        int ms = Environment.TickCount;
        DateTime now = DateTime.Now;
        return ms ^ ((now.Year * 10000) + (now.Month * 100) + now.Day);
    }

    private static string GetName(Equipment equip, bool item) => equip switch
    {
        Equipment.Item1 => item ? nameof(Equipment.Item1) : nameof(Equipment.AtomicFire),
        Equipment.Item2 => item ? nameof(Equipment.Item2) : nameof(Equipment.AirShooter),
        Equipment.Item3 => item ? nameof(Equipment.Item3) : nameof(Equipment.LeafShield),
        _ => equip.ToString()
    };

    private static void ShuffleEquipmentPatch(out IPS weaponsPatch, out IPS itemsPatch, out string spoiler, Random r = null, bool heatManNoItem2 = false)
    {
        r ??= new(GetSeed());
        spoiler = "";

        AutoSizedArray<ushort> equips = new(weapons.Length + items.Length);
        foreach (Equipment weapon in weapons) equips.Add((byte)weapon);
        foreach (Equipment item in items) equips.Add((ushort)(0x0100 | (byte)item));

        byte[] weaponData = new byte[weapons.Length], itemData = new byte[items.Length];

        for (int i = 0; equips.Length > 0; i++)
        {
            int h = heatManNoItem2 && i == 0 ? 1 : 0;

            int n = r.Next(equips.Length - h);
            ushort weapon = equips[n];
            equips.RemoveAt(n);
            
            n = r.Next(equips.Length - h);
            ushort item = equips[n];
            equips.RemoveAt(n);

            spoiler += $"{(StageIndex)i} => ";

            byte weaponByte = 0, itemByte = 0, tempByte;

            bool weaponIsItem = weapon > byte.MaxValue, itemIsItem = item > byte.MaxValue;
            if (weaponIsItem)
            {
                tempByte = (byte)(weapon & byte.MaxValue);
                itemByte |= tempByte;
            }
            else
            {
                tempByte = (byte)weapon;
                weaponByte |= tempByte;
            }
            spoiler += GetName((Equipment)tempByte, weaponIsItem) + ',' + ' ';

            if (itemIsItem)
            {
                tempByte = (byte)(item & byte.MaxValue);
                itemByte |= tempByte;
            }
            else
            {
                tempByte = (byte)item;
                weaponByte |= tempByte;
            }
            spoiler += GetName((Equipment)tempByte, itemIsItem) + '\n';

            weaponData[i] = weaponByte;
            itemData[i] = itemByte;
        }

        weaponsPatch = new();
        weaponsPatch.Add(false, (int)Address.WeaponBitMasks, weaponData);

        itemsPatch = new();
        itemsPatch.Add(false, (int)Address.HeatStageItem, itemData);
    }

    private static IPS ShuffleItemsPatch(out string spoiler, Random r = null, bool heatManNoItem2 = false)
    {
        r ??= new(GetSeed());
        spoiler = "";

        AutoSizedArray<Equipment> equips = new(items);
        byte[] data = new byte[equips.Length];
        
        Address address = Address.HeatStageItem;

        for (int i = 0; equips.Length > 0; i++, address++)
        {
            int n = r.Next(equips.Length - (heatManNoItem2 && i == 0 ? 1 : 0));
            Equipment e = equips[n];
            spoiler += $"{address} => {GetName(e, true)}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        IPS ips = new();
        ips.Add(false, (int)Address.HeatStageItem, data);
        return ips;
    }
    
    private static IPS ShuffleStagesPatch(out string spoiler, Random r = null)
    {
        r ??= new(GetSeed());
        spoiler = "";

        AutoSizedArray<StageIndex> stages = new(MM2.stages);
        byte[] data = new byte[stages.Length];

        for (int i = 0; stages.Length > 0; i++)
        {
            int n = r.Next(stages.Length);
            StageIndex si = stages[n];
            spoiler += $"{(StagePosition)i} => {si}\n";
            data[i] = (byte)si;
            stages.RemoveAt(n);
        }

        IPS ips = new();
        ips.Add(false, (int)Address.BubbleStagePtr, data);
        return ips;
    }

    private static IPS ShuffleWeaponsPatch(out string spoiler, Random r = null)
    {
        r ??= new(GetSeed());
        spoiler = "";

        AutoSizedArray<Equipment> equips = new(weapons);
        byte[] data = new byte[equips.Length];

        Address address = Address.HeatStageWeapon;
        for (int i = 0; equips.Length > 0; i++, address++)
        {
            int n = r.Next(equips.Length);
            Equipment e = equips[n];
            spoiler += $"{address} => {GetName(e, false)}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        IPS ips = new();
        ips.Add(false, (int)Address.WeaponBitMasks, data);
        return ips;
    }
    
    public static IPS Generate(ref int seed, out string spoiler, bool heatManNoItem2 = false, bool shuffleAllEquipment = false, bool shuffleLevels = false)
    {
        if (seed == 0) seed = GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n\n";
        IPS ips = new();

        if (shuffleAllEquipment)
        {
            ips.Add(ShuffleEquipmentPatch(out string s, r, heatManNoItem2), MergeMode.Combine);
            spoiler += s;
        }
        else
        {
            ips.Add(ShuffleWeaponsPatch(out string s, r), MergeMode.Combine);
            spoiler += s + '\n';
            ips.Add(ShuffleItemsPatch(out s, r, heatManNoItem2), MergeMode.Combine);
            spoiler += s;
        }
        if (shuffleLevels)
        {
            ips.Add(ShuffleStagesPatch(out string s, r), MergeMode.Combine);
            spoiler += '\n' + s;
        }

        return ips;
    }
}