using System;
using ProjectFox.CoreEngine.Collections;
using IPSLib;

namespace MM2Randomizer;

public static class MM2
{
    public const int BossCount = 0x0E, WeaponCount = 0x08;

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

        MegaBusterBossDamage =     0x02_E933,
        AtomicFireBossDamage =     0x02_E941,
        AirShooterBossDamage =     0x02_E94F,
        LeafShieldBossDamage =     0x02_E95D,
        BubbleLeadBossDamage =     0x02_E96B,
        QuickBoomerangBossDamage = 0x02_E979,
        CrashBomberBossDamage =    0x02_E987,
        MetalBladeBossDamage =     0x02_E995,

        CenterStagePtr = 0x03_40E3,

        TopLeftStagePtr =     0x03_4670,
        TopStagePtr =         0x03_4671,
        TopRightStagePtr =    0x03_4672,
        RightStagePtr =       0x03_4673,
        BottomRightStagePtr = 0x03_4674,
        BottomStagePtr =      0x03_4675,
        BottomLeftStagePtr =  0x03_4676,
        LeftStagePtr =        0x03_4677,

        BossBitFlags =   0x03_C289,
        ItemBitFlags =   0x03_C291,

        MegaBusterEnemyDamage =     0x03_E986,
        AtomicFireEnemyDamage =     0x03_EA02,
        AirShooterEnemyDamage =     0x03_EA7A,
        LeafShieldEnemyDamage =     0x03_EAF2,
        BubbleLeadEnemyDamage =     0x03_EB6A,
        QuickBoomerangEnemyDamage = 0x03_EBE2,
        CrashBomberEnemyDamage =    0x03_EC5A,
        MetalBladeEnemyDamage =     0x03_ECD2,

        NewWeaponBitFlags = 0x03_F2F8,
        NewBossIndices =    0x03_F320,
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

    public enum ObjectType : byte
    {
        Picopicokuns = 0x6A,
        BoobeamTraps = 0x6D,
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

    private static readonly byte[][]
        weaknessSets = new byte[BossCount][]
    {
        //                        P     H     A     W     B     Q     C     M
        new byte[WeaponCount] { 0x02, 0x00, 0x02, 0x00, 0x06, 0x02, 0x00, 0x01 }, //Heat Man
        new byte[WeaponCount] { 0x02, 0x06, 0x00, 0x08, 0x00, 0x02, 0x00, 0x00 }, //Air Man
        new byte[WeaponCount] { 0x01, 0x0E, 0x04, 0x00, 0x00, 0x00, 0x02, 0x02 }, //Wood Man
        new byte[WeaponCount] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x04 }, //Bubble Man
        new byte[WeaponCount] { 0x02, 0x0A, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00 }, //Quick Man
        new byte[WeaponCount] { 0x02, 0x06, 0x00, 0x00, 0x02, 0x00, 0x03, 0x04 }, //Flash Man
        new byte[WeaponCount] { 0x01, 0x04, 0x00, 0x00, 0x00, 0x04, 0x00, 0x0E }, //Metal Man
        new byte[WeaponCount] { 0x01, 0x06, 0x0A, 0x00, 0x01, 0x01, 0x00, 0x00 }, //Crash Man
        new byte[WeaponCount] { 0x01, 0x08, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00 }, //Mecha Dragon W1
        new byte[WeaponCount] { 0x07, 0x14, 0x00, 0x00, 0x14, 0x07, 0x00, 0x07 }, //Picopicokun W2
        new byte[WeaponCount] { 0x01, 0x08, 0x00, 0x00, 0x01, 0x02, 0x01, 0x00 }, //Guts Tank W3
        new byte[WeaponCount] { 0x02, 0x14, 0x00, 0x0A, 0x00, 0x02, 0x14, 0x00 }, //Boobeam Trap W4
        new byte[WeaponCount] { 0x01, 0x0E, 0x01, 0x00, 0x00, 0x01, 0x04, 0x01 }, //Wily Machine W5
        new byte[WeaponCount] { 0x01, 0x08, 0x02, 0x04, 0x04, 0x01, 0x00, 0x00 }  //Wily Alien W6
    },
        weaknessSetsVanilla = new byte[BossCount][]
    {
        //                        P     H     A     W     B     Q     C     M
        new byte[WeaponCount] { 0x02, 0xFF, 0x02, 0x00, 0x06, 0x02, 0xFF, 0x01 }, //Heat Man
        new byte[WeaponCount] { 0x02, 0x06, 0x00, 0x08, 0x00, 0x02, 0x00, 0x00 }, //Air Man
        new byte[WeaponCount] { 0x01, 0x0E, 0x04, 0xFF, 0x00, 0x00, 0x02, 0x02 }, //Wood Man
        new byte[WeaponCount] { 0x01, 0x00, 0x00, 0x00, 0xFF, 0x02, 0x02, 0x04 }, //Bubble Man
        new byte[WeaponCount] { 0x02, 0x0A, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00 }, //Quick Man
        new byte[WeaponCount] { 0x02, 0x06, 0x00, 0x00, 0x02, 0x00, 0x03, 0x04 }, //Flash Man
        new byte[WeaponCount] { 0x01, 0x04, 0x00, 0x00, 0x00, 0x04, 0x00, 0x0E }, //Metal Man
        new byte[WeaponCount] { 0x01, 0x06, 0x0A, 0x00, 0x01, 0x01, 0x00, 0x00 }, //Crash Man
        new byte[WeaponCount] { 0x01, 0x08, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00 }, //Mecha Dragon W1
        new byte[WeaponCount] { 0x07, 0x14, 0x00, 0x00, 0x14, 0x07, 0x00, 0x07 }, //Picopicokun W2
        new byte[WeaponCount] { 0x01, 0x08, 0x00, 0x00, 0x01, 0x02, 0x01, 0x00 }, //Guts Tank W3
        new byte[WeaponCount] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00 }, //Boobeam Trap W4
        new byte[WeaponCount] { 0x01, 0x0E, 0x01, 0x00, 0x00, 0x01, 0x04, 0x01 }, //Wily Machine W5
        new byte[WeaponCount] { 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0xFF, 0xFF, 0xFF }  //Wily Alien W6
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

    private static readonly Address[]
        bossGraphicsPtrAddresses =
    {
        Address.HeatManGraphicsPtrs,
        Address.AirManGraphicsPtrs,
        Address.WoodManGraphicsPtrs,
        Address.BubbleManGraphicsPtrs,
        Address.QuickManGraphicsPtrs,
        Address.FlashManGraphicsPtrs,
        Address.MetalManGraphicsPtrs,
        Address.CrashManGraphicsPtrs,
    },
        enemyDamageAddresses = new Address[WeaponCount]
    {
        Address.MegaBusterEnemyDamage,
        Address.AtomicFireEnemyDamage,
        Address.AirShooterEnemyDamage,
        Address.LeafShieldEnemyDamage,
        Address.BubbleLeadEnemyDamage,
        Address.QuickBoomerangEnemyDamage,
        Address.CrashBomberEnemyDamage,
        Address.MetalBladeEnemyDamage,
    };

    private static int ConvertAddressToNA(Address address) => address switch
    {
        Address.MegaBusterBossDamage =>      0x02_E952,
        Address.AtomicFireBossDamage =>      0x02_E960,
        Address.AirShooterBossDamage =>      0x02_E96E,
        Address.LeafShieldBossDamage =>      0x02_E97C,
        Address.BubbleLeadBossDamage =>      0x02_E98A,
        Address.QuickBoomerangBossDamage =>  0x02_E998,
        Address.CrashBomberBossDamage =>     0x02_E9A6,
        Address.MetalBladeBossDamage =>      0x02_E9B4,

        Address.MegaBusterEnemyDamage =>     0x03_E9A8,
        Address.AtomicFireEnemyDamage =>     0x03_EA24,
        Address.AirShooterEnemyDamage =>     0x03_EA9C,
        Address.LeafShieldEnemyDamage =>     0x03_EB14,
        Address.BubbleLeadEnemyDamage =>     0x03_EB8C,
        Address.QuickBoomerangEnemyDamage => 0x03_EC04,
        Address.CrashBomberEnemyDamage =>    0x03_EC7C,
        Address.MetalBladeEnemyDamage =>     0x03_ECF4,

        _ => (int)address
    };

    private static int[] ConvertAddressToSNES(Address address) => address switch
    {
        Address.HeatManGraphicsPtrs =>   new int[1] { 0x00_B496 },
        Address.AirManGraphicsPtrs =>    new int[1] { 0x01_3496 },
        Address.WoodManGraphicsPtrs =>   new int[1] { 0x01_B4CC },
        Address.BubbleManGraphicsPtrs => new int[1] { 0x02_3496 },
        Address.QuickManGraphicsPtrs =>  new int[1] { 0x02_B4A8 },
        Address.FlashManGraphicsPtrs =>  new int[1] { 0x03_3496 },
        Address.MetalManGraphicsPtrs =>  new int[1] { 0x03_B484 },
        Address.CrashManGraphicsPtrs =>  new int[1] { 0x04_34CC },

        Address.MegaBusterBossDamage =>     new int[1] { 0x06_2942 },
        Address.AtomicFireBossDamage =>     new int[1] { 0x06_2950 },
        Address.AirShooterBossDamage =>     new int[1] { 0x06_295E },
        Address.LeafShieldBossDamage =>     new int[1] { 0x06_296C },
        Address.BubbleLeadBossDamage =>     new int[1] { 0x06_297A },
        Address.QuickBoomerangBossDamage => new int[1] { 0x06_2988 },
        Address.CrashBomberBossDamage =>    new int[1] { 0x06_2996 },
        Address.MetalBladeBossDamage =>     new int[1] { 0x06_29A4 },

        Address.TopLeftStagePtr =>     new int[1] { 0x07_0660 },
        Address.TopStagePtr =>         new int[1] { 0x07_0661 },
        Address.TopRightStagePtr =>    new int[1] { 0x07_0662 },
        Address.RightStagePtr =>       new int[1] { 0x07_0663 },
        Address.BottomRightStagePtr => new int[1] { 0x07_0664 },
        Address.BottomStagePtr =>      new int[1] { 0x07_0665 },
        Address.BottomLeftStagePtr =>  new int[1] { 0x07_0666 },
        Address.LeftStagePtr =>        new int[1] { 0x07_0667 },

        Address.BossBitFlags => Util.RepeatedSNESAddress(0x00_4279),
        Address.ItemBitFlags => Util.RepeatedSNESAddress(0x00_4281),

        Address.MegaBusterEnemyDamage =>     Util.RepeatedSNESAddress(0x00_6998),
        Address.AtomicFireEnemyDamage =>     Util.RepeatedSNESAddress(0x00_6A14),
        Address.AirShooterEnemyDamage =>     Util.RepeatedSNESAddress(0x00_6A8C),
        Address.LeafShieldEnemyDamage =>     Util.RepeatedSNESAddress(0x00_6B04),
        Address.BubbleLeadEnemyDamage =>     Util.RepeatedSNESAddress(0x00_6B7C),
        Address.QuickBoomerangEnemyDamage => Util.RepeatedSNESAddress(0x00_6BF4),
        Address.CrashBomberEnemyDamage =>    Util.RepeatedSNESAddress(0x00_6C6C),
        Address.MetalBladeEnemyDamage =>     Util.RepeatedSNESAddress(0x00_6CE4),

        Address.NewWeaponBitFlags => Util.RepeatedSNESAddress(0x00_72E8),
        Address.NewBossIndices =>    Util.RepeatedSNESAddress(0x00_7310),

        _ => new int[1] { (int)address }
    };

    private static string GetName(Equipment equip, bool item) => equip switch
    {
        Equipment.Item1 => item ? nameof(Equipment.Item1) : nameof(Equipment.AtomicFire),
        Equipment.Item2 => item ? nameof(Equipment.Item2) : nameof(Equipment.AirShooter),
        Equipment.Item3 => item ? nameof(Equipment.Item3) : nameof(Equipment.LeafShield),
        _ => equip.ToString()
    };

    private static void ShuffleEquipmentPatch(out PatchCollection jpna, out PatchCollection snes, out string spoiler, Random r = null, bool shuffleTogether = false, bool heatManNoItem2 = false)
    {
        r ??= new(Util.GetSeed());

        byte[] weaponData = new byte[weapons.Length], itemData = new byte[items.Length];

        if (shuffleTogether)
        {
            spoiler = "- Weapons & Items -\n";
             
            AutoSizedArray<ushort> equips = new(weapons.Length + items.Length);
            foreach (Equipment weapon in weapons) equips.Add((byte)weapon);
            foreach (Equipment item in items) equips.Add((ushort)(0x0100 | (byte)item));
             
            for (int i = 0; equips.Length > 0; i++)
            {
                int h = heatManNoItem2 && i == 0 ? 1 : 0;
                
                int n = r.Next(equips.Length - h);
                ushort weapon = equips[n];
                equips.RemoveAt(n);
                
                n = r.Next(equips.Length - h);
                ushort item = equips[n];
                equips.RemoveAt(n);
                
                spoiler += $"{bossNamesWithSpacesShort[i]} => ";
                
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
        }
        else
        {
            spoiler = "- Weapons -\n";
            AutoSizedArray<Equipment> equips = new(weapons, weapons.Length);
            for (int i = 0; equips.Length > 0; i++)
            {
                int n = r.Next(equips.Length);
                Equipment e = equips[n];
                spoiler += $"{bossNamesWithSpacesShort[i]} => {GetName(e, false)}\n";
                weaponData[i] = (byte)e;
                equips.RemoveAt(n);
            }
            
            spoiler += "\n- Items -\n";
            equips = new(items, items.Length);
            for (int i = 0; equips.Length > 0; i++)
            {
                int n = r.Next(equips.Length - (heatManNoItem2 && i == 0 ? 1 : 0));
                Equipment e = equips[n];
                spoiler += $"{bossNamesWithSpacesShort[i]} => {GetName(e, true)}\n";
                itemData[i] = (byte)e;
                equips.RemoveAt(n);
            }
        }

        jpna = new IPS();
        jpna.Add(new Patch((int)Address.NewWeaponBitFlags, weaponData), MergeMode.None);
        jpna.Add(new Patch((int)Address.ItemBitFlags, itemData), MergeMode.None);

        snes = new IPS();
        foreach (int address in ConvertAddressToSNES(Address.NewWeaponBitFlags)) snes.Add(new Patch(address, weaponData), MergeMode.None);
        foreach (int address in ConvertAddressToSNES(Address.ItemBitFlags)) snes.Add(new Patch(address, itemData), MergeMode.None);
    }

    [Obsolete] private static Patch ShuffleItemsPatch(out string spoiler, Random r = null, bool heatManNoItem2 = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Items -\n";

        AutoSizedArray<Equipment> equips = new(items, items.Length);
        byte[] data = new byte[equips.Length];
        
        for (int i = 0; equips.Length > 0; i++)
        {
            int n = r.Next(equips.Length - (heatManNoItem2 && i == 0 ? 1 : 0));
            Equipment e = equips[n];
            spoiler += $"{bossNamesWithSpacesShort[i]} => {GetName(e, true)}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        return new((int)Address.ItemBitFlags, data);
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

        jp = new((int)Address.MegaBusterBossDamage, data);
        na = new(ConvertAddressToNA(Address.MegaBusterBossDamage), data);
    }

    private static void ShuffleRobotMastersPatch(out PatchCollection jpna, out PatchCollection snes, out string spoiler, Random r = null, bool shuffle = true, bool single = false)
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Robot Master Shuffle -\n";

        jpna = new IPS();
        snes = new IPS();

        AutoSizedArray<StageIndex> robots = new(stages, stages.Length);
        byte[] robotIndices = new byte[robots.Length];
        jpna.Add(new Patch((int)Address.NewBossIndices, robotIndices), MergeMode.None);
        foreach (int address in ConvertAddressToSNES(Address.NewBossIndices)) snes.Add(new Patch(address, robotIndices), MergeMode.None);

        if (single)
        {
            int n = r.Next(robots.Length);
            StageIndex robot = robots[n];
            spoiler += $"All Robot Masters => {bossNames[(int)robot]}\n";
            byte[] bossGraphicsPtrs = robotMasterGraphicsPtrs[(int)robot];
            for (int i = 0; i < robotIndices.Length; i++)
            {
                robotIndices[i] = (byte)robot;

                Address bossGraphicsPtrAddress = bossGraphicsPtrAddresses[i];
                jpna.Add(new Patch((int)bossGraphicsPtrAddress, bossGraphicsPtrs), MergeMode.None);
                snes.Add(new Patch(ConvertAddressToSNES(bossGraphicsPtrAddress)[0], bossGraphicsPtrs), MergeMode.None);
            }
        }
        else for (int i = 0; shuffle ? (robots.Length > 0) : (i < robotIndices.Length); i++)
            {
                int n = r.Next(robots.Length);
                StageIndex robot = robots[n];
                spoiler += $"{bossNamesWithSpacesShort[i]} => {bossNames[(int)robot]}\n";
                robotIndices[i] = (byte)robot;

                Address bossGraphicsPtrAddress = bossGraphicsPtrAddresses[i];
                byte[] bossGraphicsPtrs = robotMasterGraphicsPtrs[(int)robot];
                jpna.Add(new Patch((int)bossGraphicsPtrAddress, bossGraphicsPtrs), MergeMode.None);
                snes.Add(new Patch(ConvertAddressToSNES(bossGraphicsPtrAddress)[0], bossGraphicsPtrs), MergeMode.None);

                if (shuffle) robots.RemoveAt(n);
            }
    }
    
    private static void ShuffleStagesPatch(out Patch jpna, out Patch snes, out string spoiler, Random r = null)
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

        jpna = new((int)Address.TopLeftStagePtr, data);
        snes = new(ConvertAddressToSNES(Address.TopLeftStagePtr)[0], data);
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

        jp = new((int)Address.MegaBusterBossDamage, rearrangedData);
        na = new(ConvertAddressToNA(Address.MegaBusterBossDamage), rearrangedData);
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

        jp = new((int)Address.MegaBusterBossDamage, rearrangedData);
        na = new(ConvertAddressToNA(Address.MegaBusterBossDamage), rearrangedData);
    }

    private static void ShuffleWeaknessesPatch(out PatchCollection jp, out PatchCollection na, out PatchCollection snes, out string spoiler, Random r = null, int shuffleMode = 0, bool robotsOnly = false, bool shuffleBusterInvulnerability = false)
    {
        r ??= new(Util.GetSeed());

        jp = new IPS();
        na = new IPS();
        snes = new IPS();
        spoiler = "";

        int setCount = robotsOnly ? 8 : BossCount;
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

                        data[i] = new byte[weaknessSet.Length];
                        weaknessSet.CopyTo(data[i], 0);

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
                        AutoSizedArray<byte> weaknessSet = new(weaknessSets[i], WeaponCount);
                        byte[] data_ = data[i] = new byte[WeaponCount];
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

        for (int i = setCount; i < BossCount; i++)
        {
            byte[] weaknessSet = weaknessSets[i], data_ = data[i] = new byte[weaknessSet.Length];
            weaknessSet.CopyTo(data_, 0);
        }

        byte[] picopicokunWeaknesses = data[(int)StageIndex.PicopicokunW2], boobeamtrapWeaknesses = data[(int)StageIndex.BoobeamTrapW4];
        if (shuffleBusterInvulnerability)
        {
            spoiler += "\nInvulnerable to Mega Buster: ";

            AutoSizedArray<StageIndex> robots = new(stages, stages.Length);
            for (int i = 0; i < 4; i++)
            {
                int n = r.Next(robots.Length);
                int robot = (int)robots[n];
                spoiler += i < 3 ? bossNames[robot] + ", " : bossNames[robot];
                if (data[robot][0] != 0xFF) data[robot][0] = 0;
                robots.RemoveAt(n);
            }

            if (data[(int)StageIndex.MechaDragonW1][0] != 0xFF)    data[(int)StageIndex.MechaDragonW1][0] = 0;
            if (picopicokunWeaknesses[0] != 0xFF)                  picopicokunWeaknesses[0] = 0;
            if (data[(int)StageIndex.GutsTankW3][0] != 0xFF)       data[(int)StageIndex.GutsTankW3][0] = 0;
            if (boobeamtrapWeaknesses[0] != 0xFF)                  boobeamtrapWeaknesses[0] = 0;
            if (data[(int)StageIndex.TeleporterRoomW5][0] != 0xFF) data[(int)StageIndex.TeleporterRoomW5][0] = 0;
            if (data[(int)StageIndex.WilyAlienW6][0] != 0xFF)      data[(int)StageIndex.WilyAlienW6][0] = 0;
        }

        for (int i = 0; i < WeaponCount; i++)
        {
            byte[] picopicokun = new byte[1] { picopicokunWeaknesses[i] }, boobeamtrap = new byte[1] { boobeamtrapWeaknesses[i] };

            Address addressJP = enemyDamageAddresses[i];
            jp.Add(new Patch((int)addressJP + (int)ObjectType.Picopicokuns, picopicokun), MergeMode.None);
            jp.Add(new Patch((int)addressJP + (int)ObjectType.BoobeamTraps, boobeamtrap), MergeMode.None);

            int addressNA = ConvertAddressToNA(addressJP);
            na.Add(new Patch(addressNA + (int)ObjectType.Picopicokuns, picopicokun), MergeMode.None);
            na.Add(new Patch(addressNA + (int)ObjectType.BoobeamTraps, boobeamtrap), MergeMode.None);

            foreach (int addressSNES in ConvertAddressToSNES(addressJP))
            {
                snes.Add(new Patch(addressSNES + (int)ObjectType.Picopicokuns, picopicokun), MergeMode.None);
                snes.Add(new Patch(addressSNES + (int)ObjectType.BoobeamTraps, boobeamtrap), MergeMode.None);
            }
        }

        byte[] rearrangedData = Util.Rearrange(data);

        jp.Add(new Patch((int)Address.MegaBusterBossDamage, rearrangedData), MergeMode.None);
        na.Add(new Patch(ConvertAddressToNA(Address.MegaBusterBossDamage), rearrangedData), MergeMode.None);
        snes.Add(new Patch(ConvertAddressToSNES(Address.MegaBusterBossDamage)[0], rearrangedData), MergeMode.None);
    }

    [Obsolete] private static Patch ShuffleWeaponsPatch(out string spoiler, Random r = null)
    {
        r ??= new(Util.GetSeed());
        spoiler = "- Weapons -\n";

        AutoSizedArray<Equipment> equips = new(weapons, weapons.Length);
        byte[] data = new byte[equips.Length];

        for (int i = 0; equips.Length > 0; i++)
        {
            int n = r.Next(equips.Length);
            Equipment e = equips[n];
            spoiler += $"{bossNamesWithSpacesShort[i]} => {GetName(e, false)}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        return new((int)Address.NewWeaponBitFlags, data);
    }
    
    public static void Generate(ref int seed, out IPS jp, out IPS na, out string spoiler,
        bool shuffleAllEquipment = false, bool heatManNoItem2 = false,
        bool shuffleLevels = false,
        int robotMasterShuffle = 0,
        int weaknessShuffle = 0, bool robotsOnly = false, bool nerfBuster = false)
    {
        if (seed < 0) seed = Util.GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM2R Spoiler Log ---\nSeed: {seed}\n\n";
        jp = new();
        na = new();

        ShuffleEquipmentPatch(out PatchCollection equipmentJPNA, out PatchCollection equipmentSNES, out string equipmentSpoiler, r, shuffleAllEquipment, heatManNoItem2);

        jp.Add(equipmentJPNA, MergeMode.None);
        na.Add(equipmentJPNA, MergeMode.None);

        spoiler += equipmentSpoiler;

        if (shuffleLevels)
        {
            ShuffleStagesPatch(out Patch stagesJPNA, out Patch stagesSNES, out string s, r);

            jp.Add(stagesJPNA, MergeMode.None);
            na.Add(stagesJPNA, MergeMode.None);

            spoiler += '\n' + s;
        }

        if (robotMasterShuffle != 0)
        {
            ShuffleRobotMastersPatch(out PatchCollection robotsJPNA, out PatchCollection robotsSNES, out string s, r, robotMasterShuffle == 1, robotMasterShuffle == 3);

            jp.Add(robotsJPNA, MergeMode.None);
            na.Add(robotsJPNA, MergeMode.None);

            spoiler += '\n' + s;
        }

        ShuffleWeaknessesPatch(out PatchCollection weaknessesJP, out PatchCollection weaknessesNA, out PatchCollection weaknessesSNES, out string weaknessesSpoiler, r, weaknessShuffle, robotsOnly, nerfBuster);

        jp.Add(weaknessesJP, MergeMode.None);
        na.Add(weaknessesNA, MergeMode.None);

        spoiler += '\n' + weaknessesSpoiler;
    }
}