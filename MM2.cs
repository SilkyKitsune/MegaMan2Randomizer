using System;
using ProjectFox.CoreEngine.Collections;
using IPSLib;

namespace MM2Randomizer;

public static class MM2
{
    public enum Address : int
    {
        HeatManGraphicsPtrs =   0x00_34A6,
        AirManGraphicsPtrs =    0x00_74A6,
        WoodManGraphicsPtrs =   0x00_B4DC,
        BubbleManGraphicsPtrs = 0x00_F4A6,
        QuickManGraphicsPtrs =  0x01_34B8,
        FlashManGraphicsPtrs =  0x01_74A6,
        MetalManGraphicsPtrs =  0x01_B494,
        CrashManGraphicsPtrs =  0x01_F4DC,

        BossWeaponDamageJP = 0x02_E933,
        BossWeaponDamageNA = 0x02_E952,

        CenterStagePtr = 0x03_40E3,

        TopLeftStagePtr =     0x03_4670,
        TopStagePtr =         0x03_4671,
        TopRightStagePtr =    0x03_4672,
        RightStagePtr =       0x03_4673,
        BottomRightStagePtr = 0x03_4674,
        BottomStagePtr =      0x03_4675,
        BottomLeftStagePtr =  0x03_4676,
        LeftStagePtr =        0x03_4677,

        HeatStageWeapon =   0x03_C289,
        AirStageWeapon =    0x03_C28A,
        WoodStageWeapon =   0x03_C28B,
        BubbleStageWeapon = 0x03_C28C,
        QuickStageWeapon =  0x03_C28D,
        FlashStageWeapon =  0x03_C28E,
        MetalStageWeapon =  0x03_C28F,
        CrashStageWeapon =  0x03_C290,

        HeatStageItem =   0x03_C291,
        AirStageItem =    0x03_C292,
        WoodStageItem =   0x03_C293,
        BubbleStageItem = 0x03_C294,
        QuickStageItem =  0x03_C295,
        FlashStageItem =  0x03_C296,
        MetalStageItem =  0x03_C297,
        CrashStageItem =  0x03_C298,

        WeaponBitMasks = 0x03_F2F8,
    }

    public enum Equipment : byte
    {
        None = 0x00,

        AtomicFire =     0x01,
        AirShooter =     0x02,
        LeafShield =     0x04,
        BubbleLead =     0x08,
        QuickBoomerang = 0x10,
        FlashStopper =   0x20,
        MetalBlade =     0x40,
        CrashBomber =    0x80,

        Item1 = AtomicFire,
        Item2 = AirShooter,
        Item3 = LeafShield
    }

    public enum Pickups : byte
    {
        BigWeapon = 0x78,
        ETank = 0x7A,
        OneUp = 0x7E
    }

    public enum StageIndex : byte
    {
        HeatMan =   0x00,
        AirMan =    0x01,
        WoodMan =   0x02,
        BubbleMan = 0x03,
        QuickMan =  0x04,
        FlashMan =  0x05,
        MetalMan =  0x06,
        CrashMan =  0x07,

        MechaDragonW1 =    0x08,
        PicopicokunW2 =    0x09,
        GutsTankW3 =       0x0A,
        BoobeamTrapW4 =    0x0B,
        TeleporterRoomW5 = 0x0C,
        WilyAlienW6 =      0x0D,
    }

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
        "Heat Man    ",
        "Air Man     ",
        "Wood Man    ",
        "Bubble Man  ",
        "Quick Man   ",
        "Flash Man   ",
        "Metal Man   ",
        "Crash Man   ",
        "Mecha Dragon",
        "Picopicokun ",
        "Guts Tank   ",
        "Boobeam Trap",
        "Wily Machine",
        "Wily Alien  "
    },
        bossNamesWithSpacesShort =
    {
        "Heat Man  ",
        "Air Man   ",
        "Wood Man  ",
        "Bubble Man",
        "Quick Man ",
        "Flash Man ",
        "Metal Man ",
        "Crash Man "
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
    },
        robotMasterGraphicsPtrs =
    {
        new byte[] { 0x98, 0x06,  0x99, 0x06,  0x9A, 0x06,  0x9B, 0x06,  0x9C, 0x06,  0x9D, 0x06,  0x0F, 0x28, 0x15,  0x0F, 0x28, 0x15 }, //Heat Man
        new byte[] { 0xAB, 0x05,  0xAC, 0x05,  0xAD, 0x05,  0xAA, 0x06,  0xAB, 0x06,  0xAC, 0x06,  0x0F, 0x30, 0x11,  0x0F, 0x28, 0x11 }, //Air Man
        new byte[] { 0xAC, 0x06,  0xAD, 0x06,  0xAE, 0x06,  0xAF, 0x06,  0xB0, 0x06,  0xB1, 0x06,  0x0F, 0x30, 0x29,  0x0F, 0x36, 0x17 }, //Wood Man
        new byte[] { 0x98, 0x07,  0x99, 0x07,  0x9A, 0x07,  0x9B, 0x07,  0x9C, 0x07,  0x9D, 0x07,  0x0F, 0x30, 0x19,  0x0F, 0x30, 0x19 }, //Bubble Man
        new byte[] { 0x90, 0x07,  0x91, 0x07,  0x92, 0x07,  0x93, 0x07,  0x94, 0x07,  0x95, 0x07,  0x0F, 0x30, 0x28,  0x0F, 0x28, 0x15 }, //Quick Man
        new byte[] { 0x9E, 0x06,  0x9F, 0x06,  0x96, 0x07,  0x97, 0x07,  0x9E, 0x07,  0x9F, 0x07,  0x30, 0x30, 0x28,  0x0F, 0x30, 0x12 }, //Flash Man
        new byte[] { 0xB0, 0x03,  0xB1, 0x03,  0xB2, 0x03,  0xB3, 0x03,  0xAA, 0x05,  0xAB, 0x05,  0x0F, 0x30, 0x15,  0x0F, 0x28, 0x15 }, //Metal Man
        new byte[] { 0xAE, 0x05,  0xAF, 0x05,  0xB0, 0x05,  0xB1, 0x05,  0xB2, 0x05,  0xB3, 0x05,  0x0F, 0x30, 0x30,  0x0F, 0x30, 0x16 }, //Crash Man
    };

    private static string GetName(Equipment equip, bool item) => equip switch
    {
        Equipment.Item1 => item ? nameof(Equipment.Item1) : nameof(Equipment.AtomicFire),
        Equipment.Item2 => item ? nameof(Equipment.Item2) : nameof(Equipment.AirShooter),
        Equipment.Item3 => item ? nameof(Equipment.Item3) : nameof(Equipment.LeafShield),
        _ => equip.ToString()
    };

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

    [Obsolete] private static void ShuffleBusterInvulnerabilityPatch(out Patch jp, out Patch na, out string spoiler, Random r = null)
    {
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

        return new((int)Address.TopLeftStagePtr, data);
    }

    [Obsolete] private static void ShuffleWeaknessesPerBossPatch(out Patch jp, out Patch na, out string spoiler, Random r = null, bool robotsOnly = false)
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
    
    [Obsolete] private static void ShuffleWeaknessSetsPatch(out Patch jp, out Patch na, out string spoiler, Random r = null, bool robotsOnly = false)
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

    private static void ShuffleWeaknessesPatch(out Patch jp, out Patch na, out string spoiler, Random r = null, int shuffleMode = 0, bool robotsOnly = false, bool shuffleBusterInvulnerability = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "";

        int setCount = robotsOnly ? 8 : weaknessSets.Length, weaponCount = weaknessSets[0].Length;
        byte[][] data = new byte[weaknessSets.Length][];

        switch (shuffleMode)
        {
            default: //"vanilla"
                {
                    for (int i = 0; i < setCount; i++)
                    {
                        byte[] weaknessSet = weaknessSets[i], data_ = data[i] = new byte[weaknessSet.Length];
                        weaknessSet.CopyTo(data_, 0);
                    }
                    break;
                }
            case 1: //boss sets
                {
                    spoiler += "- Boss Sets Weakness Shuffle -\n";

                    AutoSizedArray<byte[]> weaknessSets = new(MM2.weaknessSets[..setCount], setCount);
                    AutoSizedArray<string> bossNames = new(MM2.bossNames[..setCount], setCount);

                    for (int i = 0; weaknessSets.Length > 0; i++)
                    {
                        int n = r.Next(weaknessSets.Length);
                        byte[] weaknessSet = weaknessSets[n];

                        spoiler += $"{bossNamesWithSpaces[i]} => {bossNames[n]}\n";

                        data[i] = weaknessSet;

                        weaknessSets.RemoveAt(n);
                        bossNames.RemoveAt(n);
                    }
                    break;
                }
            case 2: //per boss
                {
                    spoiler += "- Per Boss Weakness Shuffle -\n" +
                        "                P    H    A    W    B    Q    C    M\n";

                    for (int i = 0; i < setCount; i++)
                    {
                        AutoSizedArray<byte> weaknessSet = new(weaknessSets[i], weaponCount);
                        byte[] data_ = data[i] = new byte[weaponCount];
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
                    break;
                }
            /*case 3: //random balanced
                {
                    break;
                }*/
            /*case 4: //random random
                {
                    break;
                }*/
        }

        for (int i = setCount; i < weaknessSets.Length; i++)
        {
            byte[] weaknessSet = weaknessSets[i], data_ = data[i] = new byte[weaknessSet.Length];
            weaknessSet.CopyTo(data_, 0);
        }

        byte[] rearrangedData = Util.Rearrange(data);

        if (shuffleBusterInvulnerability)
        {
            spoiler += "\nInvulnerable to Mega Buster: ";

            AutoSizedArray<StageIndex> robots = new(stages, stages.Length);
            for (int i = 0; i < 4; i++)
            {
                int n = r.Next(robots.Length);
                int robot = (int)robots[n];
                spoiler += i < 3 ? bossNames[robot] + ", " : bossNames[robot];
                rearrangedData[robot] = 0;
                robots.RemoveAt(n);
            }

            rearrangedData[(int)StageIndex.MechaDragonW1] = 0;
            rearrangedData[(int)StageIndex.PicopicokunW2] = 0;
            rearrangedData[(int)StageIndex.GutsTankW3] = 0;
            rearrangedData[(int)StageIndex.BoobeamTrapW4] = 0;
            rearrangedData[(int)StageIndex.TeleporterRoomW5] = 0;
            rearrangedData[(int)StageIndex.WilyAlienW6] = 0;
        }

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
    
    public static void Generate(ref int seed, out IPS jp, out IPS na, out string spoiler,
        bool shuffleAllEquipment = false, bool heatManNoItem2 = false,
        bool shuffleLevels = false,
        int weaknessShuffle = 0, bool robotsOnly = false,
        bool nerfBuster = false)
    {
        if (seed == 0) seed = Util.GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n\n";
        jp = new();
        na = new();

        if (shuffleAllEquipment)
        {
            ShuffleEquipmentPatch(out Patch weapons, out Patch items, out string s, r, heatManNoItem2);

            jp.Add(weapons, MergeMode.None);
            jp.Add(items, MergeMode.None);

            na.Add(weapons, MergeMode.None);
            na.Add(items, MergeMode.None);

            spoiler += s;
        }
        else
        {
            Patch weapons = ShuffleWeaponsPatch(out string s, r), items = ShuffleItemsPatch(out string s_, r, heatManNoItem2);

            jp.Add(weapons, MergeMode.None);
            jp.Add(items, MergeMode.None);

            na.Add(weapons, MergeMode.None);
            na.Add(items, MergeMode.None);

            spoiler += s + '\n' + s_;
        }

        if (shuffleLevels)
        {
            Patch stages = ShuffleStagesPatch(out string s, r);

            jp.Add(stages, MergeMode.None);
            na.Add(stages, MergeMode.None);

            spoiler += '\n' + s;
        }

        ShuffleWeaknessesPatch(out Patch weaknessesJP, out Patch weaknessesNA, out string weaknessesSpoiler, r, weaknessShuffle, robotsOnly, nerfBuster);

        jp.Add(weaknessesJP, MergeMode.None);
        na.Add(weaknessesNA, MergeMode.None);

        spoiler += '\n' + weaknessesSpoiler;
    }
}