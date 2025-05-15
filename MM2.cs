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

    private static readonly byte[][] weaknessSets =
    {//need logic to ensure no boss becomes invulnerable
        //             P     H     A     W     B     Q     C     M
        new byte[] { 0x02, 0x00, 0x02, 0x00, 0x06, 0x02, 0x00, 0x01 }, //Heat Man
        new byte[] { 0x02, 0x06, 0x00, 0x08, 0x00, 0x02, 0x00, 0x00 }, //Air Man
        new byte[] { 0x01, 0x0E, 0x04, 0x00, 0x00, 0x00, 0x02, 0x02 }, //Wood Man
        new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x04 }, //Bubble Man
        new byte[] { 0x02, 0x0A, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00 }, //Quick Man
        new byte[] { 0x02, 0x06, 0x00, 0x00, 0x02, 0x00, 0x03, 0x04 }, //Flash Man
        new byte[] { 0x01, 0x04, 0x00, 0x00, 0x00, 0x04, 0x00, 0x0E }, //Metal Man
        new byte[] { 0x01, 0x06, 0x0A, 0x00, 0x01, 0x01, 0x00, 0x00 }, //Crash Man
        new byte[] { 0x01, 0x08, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00 }, //Mecha Dragon W1
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //Picopicokun W2, this one can't be all zero
        new byte[] { 0x01, 0x08, 0x00, 0x00, 0x01, 0x02, 0x01, 0x00 }, //Guts Tank W3
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00 }, //Boobeam Trap W4, should other weapons work?
        new byte[] { 0x01, 0x0E, 0x01, 0x00, 0x00, 0x01, 0x04, 0x01 }, //Wily Machine W5 (these might only be phase 2)
        new byte[] { 0x01, 0x08, 0x02, 0x04, 0x04, 0x01, 0x00, 0x00 }  //Wily Alien W6
    },
        weaknessSetsVanilla =
    {
        //             P     H     A     W     B     Q     C     M
        new byte[] { 0x02, 0xFF, 0x02, 0x00, 0x06, 0x02, 0xFF, 0x01 }, //Heat Man
        new byte[] { 0x02, 0x06, 0x00, 0x08, 0x00, 0x02, 0x00, 0x00 }, //Air Man
        new byte[] { 0x01, 0x0E, 0x04, 0xFF, 0x00, 0x00, 0x02, 0x02 }, //Wood Man
        new byte[] { 0x01, 0x00, 0x00, 0x00, 0xFF, 0x02, 0x02, 0x04 }, //Bubble Man
        new byte[] { 0x02, 0x0A, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00 }, //Quick Man
        new byte[] { 0x02, 0x06, 0x00, 0x00, 0x02, 0x00, 0x03, 0x04 }, //Flash Man
        new byte[] { 0x01, 0x04, 0x00, 0x00, 0x00, 0x04, 0x00, 0x0E }, //Metal Man
        new byte[] { 0x01, 0x06, 0x0A, 0x00, 0x01, 0x01, 0x00, 0x00 }, //Crash Man
        new byte[] { 0x01, 0x08, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00 }, //Mecha Dragon W1
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //Picopicokun W2
        new byte[] { 0x01, 0x08, 0x00, 0x00, 0x01, 0x02, 0x01, 0x00 }, //Guts Tank W3
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //Boobeam Trap W4
        new byte[] { 0x01, 0x0E, 0x01, 0x00, 0x00, 0x01, 0x04, 0x01 }, //Wily Machine W5
        new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0xFF, 0xFF, 0xFF }  //Wily Alien W6
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

    private static byte[] Rearrange(byte[][] data)
    {
        byte[] newData = new byte[data.Length * data[0].Length];

        for (int i = 0, k = 0, l = data[0].Length; i < l; i++)
            for (int j = 0; j < data.Length; j++)
                newData[k++] = data[j][i];

        return newData;
    }

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
    
    public static void Generate(ref int seed, out IPS jp, out IPS na, out string spoiler,
        bool shuffleAllEquipment = false, bool heatManNoItem2 = false,
        bool shuffleLevels = false,
        int weaknessShuffle = 0, bool robotsOnly = false,
        bool nerfBuster = false)
    {
        if (seed == 0) seed = GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n\n";
        jp = new();
        na = new();

        if (shuffleAllEquipment)
        {
            ShuffleEquipmentPatch(out IPS weapons, out IPS items, out string s, r, heatManNoItem2);

            jp.Add(weapons, MergeMode.Combine);
            jp.Add(items, MergeMode.Combine);

            na.Add(weapons, MergeMode.Combine);
            na.Add(items, MergeMode.Combine);

            spoiler += s;
        }
        else
        {
            IPS weaons = ShuffleWeaponsPatch(out string s, r), items = ShuffleItemsPatch(out string s_, r, heatManNoItem2);

            jp.Add(weaons, MergeMode.Combine);
            jp.Add(items, MergeMode.Combine);

            na.Add(weaons, MergeMode.Combine);
            na.Add(items, MergeMode.Combine);

            spoiler += s + '\n' + s_;
        }

        if (shuffleLevels)
        {
            IPS stages = ShuffleStagesPatch(out string s, r);

            jp.Add(stages, MergeMode.Combine);
            na.Add(stages, MergeMode.Combine);

            spoiler += '\n' + s;
        }

        return ips;
    }
}