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

    private static readonly string[] bossNames =
    {
        "Heat Man",
        "Air Man",
        "Wood Man",
        "Bubble Man",
        "Quick Man",
        "Flash Man",
        "Metal Man",
        "Crash Man",
        "Mecha Dragon",
        "Picopicokun",
        "Guts Tank",
        "Boobeam Trap",
        "Wily Machine",
        "Wily Alien"
    },
        bossNamesWithSpaces =
    {
        "Heat Man     ",
        "Air Man      ",
        "Wood Man     ",
        "Bubble Man   ",
        "Quick Man    ",
        "Flash Man    ",
        "Metal Man    ",
        "Crash Man    ",
        "Mecha Dragon ",
        "Picopicokun  ",
        "Guts Tank    ",
        "Boobeam Trap ",
        "Wily Machine ",
        "Wily Alien   "
    };

    private static readonly byte[] randomWeaknessPool =
    {
        //curved set of values ranging from 0 to 1C
    };

    private static readonly int[] randomWeaknessIndices =
    {
        //used for limiting randomWeaknessPool to a min/max
        0,
        randomWeaknessPool.Length//temp
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
        new byte[] { 0x01, 0x03, 0x00, 0x00, 0x03, 0x01, 0x00, 0x01 }, //Picopicokun W2, these are taken from mmkb
        new byte[] { 0x01, 0x08, 0x00, 0x00, 0x01, 0x02, 0x01, 0x00 }, //Guts Tank W3
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00 }, //Boobeam Trap W4, should other weapons work?
        new byte[] { 0x01, 0x0E, 0x01, 0x00, 0x00, 0x01, 0x04, 0x01 }, //Wily Machine W5 (these might only be phase 2)
        //wily machine values taken from mmkb
        //phase 1    0x01, 0x0E, 0x01, 0x00, 0x00, 0x00, 0x04, 0x01
        //phase 2    0x01, 0x00, 0x01, 0x00, 0x00, 0x01, 0x04, 0x01
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

    private static string GetName(Equipment equip, bool item) => equip switch
    {
        Equipment.Item1 => item ? nameof(Equipment.Item1) : nameof(Equipment.AtomicFire),
        Equipment.Item2 => item ? nameof(Equipment.Item2) : nameof(Equipment.AirShooter),
        Equipment.Item3 => item ? nameof(Equipment.Item3) : nameof(Equipment.LeafShield),
        _ => equip.ToString()
    };

    private static void RandomWeaknessesPatch(out Patch jp, out Patch na, out string spoiler, Random r = null, bool robotsOnly = false)//min max args
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Random Weaknesses -\n" +
            "                 P    H    A    W    B    Q    C    M\n";

        byte[] randomWeaknessPool = MM2.randomWeaknessPool[randomWeaknessIndices[0/*min*/]..randomWeaknessIndices[^1/*max*/]];
        byte[][] data = new byte[weaknessSets.Length][];

        for (int i = 0, l = robotsOnly ? 8 : data.Length, l_ = weaknessSets[0].Length; i < l; i++)
        {
            byte[] data_ = data[i] = new byte[l_];
            spoiler += bossNamesWithSpaces[i];

            for (int j = 0; j < data_.Length; j++)
            {
                byte weakness = 0;//randomWeaknessPool[r.Next(randomWeaknessPool.Length)];
                data_[j] = weakness;

                string weaknessStr = weakness.ToString();
                spoiler += weaknessStr.Length switch
                {
                    1 => "    ",
                    2 => "   ",
                    3 => "  ",
                    4 => " ",
                    _ => string.Empty
                } + weaknessStr;
            }
            spoiler += '\n';
        }

        if (robotsOnly) for (int i = 8; i < data.Length; i++) data[i] = weaknessSets[i];

        byte[] rearrangedData = Util.Rearrange(data);

        jp = new((int)Address.BossWeaponDamageJP, rearrangedData);
        na = new((int)Address.BossWeaponDamageNA, rearrangedData);
    }

    private static void ShuffleEquipmentPatch(out Patch weaponsPatch, out Patch itemsPatch, out string spoiler, Random r = null, bool heatManNoItem2 = false)
    {
        r ??= new(Util.GetSeed());
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

        weaponsPatch = new((int)Address.WeaponBitMasks, weaponData);

        itemsPatch = new((int)Address.HeatStageItem, itemData);
    }

    private static Patch ShuffleItemsPatch(out string spoiler, Random r = null, bool heatManNoItem2 = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "";

        AutoSizedArray<Equipment> equips = new(items, items.Length);
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

        return new((int)Address.HeatStageItem, data);
    }

    private static void ShuffleBusterInvulnerabilityPatch(out Patch jp, out Patch na, out string spoiler, Random r = null)
    {//this overwrites any modified damage values from weakness shuffle
        r ??= new(Util.GetSeed());
        spoiler = "Invulnerable to Mega Buster: ";

        byte[] data = new byte[weaknessSets.Length];
        for (int i = 0; i < 8; i++) data[i] = weaknessSets[i][0];
        for (int i = 8; i < data.Length; i++) data[i] = 0;

        AutoSizedArray<StageIndex> robots = new(stages, stages.Length);

        for (int i = 0; i < 4; i++)
        {
            int n = r.Next(robots.Length);
            StageIndex robot = robots[n];
            spoiler += i < 3 ? robot + ", " : robot;
            data[(int)robot] = 0;
            robots.RemoveAt(n);
        }

        jp = new((int)Address.BossWeaponDamageJP, data);

        na = new((int)Address.BossWeaponDamageNA, data);
    }

    private static Patch ShuffleRobotMastersPatch(out string spoiler, Random r = null, bool shuffle = true, bool single = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Robot Master Shuffle -\n";

        AutoSizedArray<StageIndex> robots = new(stages, stages.Length);
        byte[] data = new byte[robots.Length];

        if (single)
        {
            int n = r.Next(robots.Length);
            StageIndex robot = robots[n];
            spoiler += $"All Robot Masters => {robot}\n";
            for (int i = 0; i < data.Length; i++) data[i] = (byte)robot;
        }
        else for (int i = 0; shuffle ? (robots.Length > 0) : (i < data.Length); i++)
            {
                int n = r.Next(robots.Length);
                StageIndex robot = robots[n];
                spoiler += $"{stages[i]} => {robot}\n";
                data[i] = (byte)robot;
                if (shuffle) robots.RemoveAt(n);
            }

        return new((int)Address.BossIndices, data);
    }

    private static Patch ShuffleStagesPatch(out string spoiler, Random r = null)
    {
        r ??= new(Util.GetSeed());
        spoiler = "";

        AutoSizedArray<StageIndex> stages = new(MM2.stages, MM2.stages.Length);
        byte[] data = new byte[stages.Length];

        for (int i = 0; stages.Length > 0; i++)
        {
            int n = r.Next(stages.Length);
            StageIndex si = stages[n];
            spoiler += $"{(StagePosition)i} => {si}\n";
            data[i] = (byte)si;
            stages.RemoveAt(n);
        }

        return new((int)Address.BubbleStagePtr, data);
    }

    private static void ShuffleWeaknessesPerBossPatch(out Patch jp, out Patch na, out string spoiler, Random r = null, bool robotsOnly = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Per Boss Weakness Shuffle -\n" +
            "                 P    H    A    W    B    Q    C    M\n";

        byte[][] data = new byte[weaknessSets.Length][];

        for (int i = 0, l = robotsOnly ? 8 : data.Length, l_ = weaknessSets[0].Length; i < l; i++)
        {
            AutoSizedArray<byte> weaknessSet = new(weaknessSets[i], l_);
            byte[] data_ = data[i] = new byte[l_];
            spoiler += bossNamesWithSpaces[i];

            for (int j = 0; weaknessSet.Length > 0; j++)
            {
                int n = r.Next(weaknessSet.Length);
                byte weakness = weaknessSet[n];

                data_[j] = weakness;
                weaknessSet.RemoveAt(n);

                string weaknessStr = ((sbyte)weakness).ToString();
                spoiler += weaknessStr.Length switch
                {
                    1 => "    ",
                    2 => "   ",
                    3 => "  ",
                    4 => ' ',
                    _ => string.Empty
                } + weaknessStr;
            }
            spoiler += '\n';
        }

        if (robotsOnly) for (int i = 8; i < data.Length; i++) data[i] = weaknessSets[i];

        byte[] rearrangedData = Util.Rearrange(data);

        jp = new((int)Address.BossWeaponDamageJP, rearrangedData);

        na = new((int)Address.BossWeaponDamageNA, rearrangedData);
    }
    
    private static void ShuffleWeaknessSetsPatch(out Patch jp, out Patch na, out string spoiler, Random r = null, bool robotsOnly = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Boss Sets Weakness Shuffle -\n";
        
        byte[][] weaknessSets_ = robotsOnly ? MM2.weaknessSets[..8] : MM2.weaknessSets;
        string[] bossNames_ = robotsOnly ? MM2.bossNames[..8] : MM2.bossNames;

        AutoSizedArray<byte[]> weaknessSets = new(weaknessSets_, weaknessSets_.Length), data = new(MM2.weaknessSets.Length);
        AutoSizedArray<string> bossNames = new(bossNames_, bossNames_.Length);

        for (int i = 0; weaknessSets.Length > 0; i++)
        {
            int n = r.Next(weaknessSets.Length);
            byte[] weaknessSet = weaknessSets[n];

            spoiler += $"{MM2.bossNames[i]} => {bossNames[n]}\n";

            data.Add(weaknessSet);

            weaknessSets.RemoveAt(n);
            bossNames.RemoveAt(n);
        }

        if (robotsOnly) data.Add(MM2.weaknessSets[8..]);

        byte[] rearrangedData = Util.Rearrange(data.ToArray());

        jp = new((int)Address.BossWeaponDamageJP, rearrangedData);

        na = new((int)Address.BossWeaponDamageNA, rearrangedData);
    }

    private static Patch ShuffleWeaponsPatch(out string spoiler, Random r = null)
    {
        r ??= new(Util.GetSeed());
        spoiler = "";

        AutoSizedArray<Equipment> equips = new(weapons, weapons.Length);
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

        return new((int)Address.WeaponBitMasks, data);
    }
    //remove the out modifiers from the patches?
    public static void Generate(ref int seed, out IPS jp, out IPS na, out string spoiler,
        bool shuffleAllEquipment = false, bool heatManNoItem2 = false,
        bool shuffleLevels = false,
        int weaknessShuffle = 0, bool robotsOnly = false,
        bool nerfBuster = false)
    {
        if (seed == 0) seed = Util.GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n\n";//add pumpkin to this too?
        jp = new();
        na = new();

        if (shuffleAllEquipment)
        {
            ShuffleEquipmentPatch(out Patch weapons, out Patch items, out string s, r, heatManNoItem2);

            jp.Add(weapons, MergeMode.CombineOver);
            jp.Add(items, MergeMode.CombineOver);

            na.Add(weapons, MergeMode.CombineOver);
            na.Add(items, MergeMode.CombineOver);

            spoiler += s;
        }
        else
        {
            Patch weapons = ShuffleWeaponsPatch(out string s, r), items = ShuffleItemsPatch(out string s_, r, heatManNoItem2);

            jp.Add(weapons, MergeMode.CombineOver);
            jp.Add(items, MergeMode.CombineOver);

            na.Add(weapons, MergeMode.CombineOver);
            na.Add(items, MergeMode.CombineOver);

            spoiler += s + '\n' + s_;
        }

        if (shuffleLevels)
        {
            Patch stages = ShuffleStagesPatch(out string s, r);

            jp.Add(stages, MergeMode.CombineOver);
            na.Add(stages, MergeMode.CombineOver);

            spoiler += '\n' + s;
        }

        //add condition later
        {
            Patch robots = ShuffleRobotMastersPatch(out string s, r, true, false);//temp

            jp.Add(robots, MergeMode.CombineOver);
            na.Add(robots, MergeMode.CombineOver);

            spoiler += '\n' + s;
        }

        switch (weaknessShuffle)
        {
            default:
                {
                    byte[] ws = Util.Rearrange(weaknessSets);

                    jp.Add(new Patch((int)Address.BossWeaponDamageJP, ws), MergeMode.CombineOver);
                    na.Add(new Patch((int)Address.BossWeaponDamageNA, ws), MergeMode.CombineOver);

                    break;
                }
            case 1:
                {
                    ShuffleWeaknessSetsPatch(out Patch weaknessesJP, out Patch weaknessesNA, out string s, r, robotsOnly);

                    jp.Add(weaknessesJP, MergeMode.CombineOver);
                    na.Add(weaknessesNA, MergeMode.CombineOver);

                    spoiler += '\n' + s;
                    break;
                }
            case 2:
                {
                    ShuffleWeaknessesPerBossPatch(out Patch weaknessesJP, out Patch weaknessesNA, out string s, r, robotsOnly);

                    jp.Add(weaknessesJP, MergeMode.CombineOver);
                    na.Add(weaknessesNA, MergeMode.CombineOver);

                    spoiler += '\n' + s;
                    break;
                }
            case 3:
                {
                    RandomWeaknessesPatch(out Patch weaknessesJP, out Patch weaknessesNA, out string s, r, robotsOnly);

                    jp.Add(weaknessesJP, MergeMode.CombineOver);
                    na.Add(weaknessesNA, MergeMode.CombineOver);

                    spoiler += '\n' + s;
                    break;
                }
        }

        if (nerfBuster)
        {
            ShuffleBusterInvulnerabilityPatch(out Patch nerfBusterJP, out Patch nerfBusterNA, out string s, r);

            jp.Add(nerfBusterJP, MergeMode.CombineOver);
            na.Add(nerfBusterNA, MergeMode.CombineOver);

            spoiler += '\n' + s;
        }
    }
}