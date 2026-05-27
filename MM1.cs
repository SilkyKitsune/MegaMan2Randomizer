using System;
using ProjectFox.CoreEngine.Collections;
using IPSLib;

namespace MM2Randomizer;

public static class MM1
{
    public const int BossCount = 0x0B, WeaponCount = 0x08;

    public enum Address : int
    {
        BossBitFlags =      0x01_C158,
        MagnetBeamBitFlag = 0x01_C884,

        CutManWeaponDamage =        0x01_FE32, //$FE22
        IceManWeaponDamage =        0x01_FE3A,
        BombManWeaponDamage =       0x01_FE42,
        FireManWeaponDamage =       0x01_FE4A,
        ElecManWeaponDamage =       0x01_FE52,
        GutsManWeaponDamage =       0x01_FE5A,
        YellowDevilWeaponDamage =   0x01_FE62,
        CopyRobotWeaponDamage =     0x01_FE6A,
        CWU01PWeaponDamage =        0x01_FE72,
        WilyMachineV1WeaponDamage = 0x01_FE7A,
        WilyMachineV2WeaponDamage = 0x01_FE82,

        NewWeaponBitFlags =    0x01_FF10,
        NewMagnetBeamBitFlag = 0x01_FF24,
    }

    public enum Equipment : byte
    {
        None =   0x00,
        Unused = 0x01,

        HyperBomb =     0x02,
        ThunderBeam =   0x04,
        SuperArm =      0x08,
        IceSlasher =    0x10,
        RollingCutter = 0x20,
        FireStorm =     0x40,
        MagnetBeam =    0x80,
    }

    public enum StageIndex : byte
    {
        CutMan =  0x00,
        IceMan =  0x01,
        BombMan = 0x02,
        FireMan = 0x03,
        ElecMan = 0x04,
        GutsMan = 0x05,

        YellowDevilW1 = 0x06,
        CopyRobotW2 =   0x07,
        CWU01P_W3 =     0x08,
        WilyMachineW4 = 0x09,
    }

    private static readonly Equipment[] equipment =
    {
        Equipment.HyperBomb,
        Equipment.ThunderBeam,
        Equipment.SuperArm,
        Equipment.IceSlasher,
        Equipment.RollingCutter,
        Equipment.FireStorm,
        Equipment.MagnetBeam
    };

    private static readonly StageIndex[]
        robotStages =
    {
        StageIndex.CutMan,
        StageIndex.IceMan,
        StageIndex.BombMan,
        StageIndex.FireMan,
        StageIndex.ElecMan,
        StageIndex.GutsMan,
    },
        castleStages =
    {
        StageIndex.YellowDevilW1,
        StageIndex.CopyRobotW2,
        StageIndex.CWU01P_W3,
        StageIndex.WilyMachineW4,
    },
        allStages =
    {
        StageIndex.CutMan,
        StageIndex.IceMan,
        StageIndex.BombMan,
        StageIndex.FireMan,
        StageIndex.ElecMan,
        StageIndex.GutsMan,

        StageIndex.YellowDevilW1,
        StageIndex.CopyRobotW2,
        StageIndex.CWU01P_W3,
        StageIndex.WilyMachineW4,
    };

    private static readonly string[]
        bossNames =
    {
        "Cut Man",
        "Ice Man",
        "Bomb Man",
        "Fire Man",
        "Elec Man",
        "Guts Man",
        "Yellow Devil",
        "Copy Robot",
        "CWU-01P",
        "Wily Machine V1",
        "Wily Machine V2",
    },
        bossNamesWithSpaces =
    {
        "Cut Man        ",
        "Ice Man        ",
        "Bomb Man       ",
        "Fire Man       ",
        "Elec Man       ",
        "Guts Man       ",
        "Yellow Devil   ",
        "Copy Robot     ",
        "CWU-01P        ",
        "Wily Machine V1",
        "Wily Machine V2",
    },
        bossNamesWithSpacesShort =
    {
        "Cut Man    ",
        "Ice Man    ",
        "Bomb Man   ",
        "Fire Man   ",
        "Elec Man   ",
        "Guts Man   ",
    };

    private static readonly byte[][]
        weaknessSets = new byte[BossCount][]
    {
        //                        P     C     I     B     F     E     G     M
        new byte[WeaponCount] { 0x03, 0x01, 0x00, 0x02, 0x03, 0x01, 0x0E, 0x00 }, //Cut Man
        new byte[WeaponCount] { 0x01, 0x02, 0x00, 0x04, 0x01, 0x0A, 0x00, 0x00 }, //Ice Man
        new byte[WeaponCount] { 0x02, 0x02, 0x00, 0x01, 0x04, 0x02, 0x00, 0x00 }, //Bomb Man
        new byte[WeaponCount] { 0x02, 0x02, 0x04, 0x01, 0x01, 0x01, 0x00, 0x00 }, //Fire Man
        new byte[WeaponCount] { 0x01, 0x0A, 0x00, 0x02, 0x01, 0x01, 0x04, 0x00 }, //Elec Man (g seems wrong)
        new byte[WeaponCount] { 0x02, 0x01, 0x00, 0x0A, 0x02, 0x01, 0x01, 0x00 }, //Guts Man
        new byte[WeaponCount] { 0x02, 0x04, 0x00, 0x00, 0x04, 0x07, 0x00, 0x00 }, //Yellow Devil W1
        new byte[WeaponCount] { 0x02, 0x02, 0x00, 0x0A, 0x04, 0x04, 0x00, 0x01 }, //Copy Robot W2 (temp magnet beam value)
        new byte[WeaponCount] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //CWU-01P W3
        new byte[WeaponCount] { 0x01, 0x01, 0x01, 0x01, 0x04, 0x01, 0x01, 0x00 }, //Wily Machine Phase 1 W4
        new byte[WeaponCount] { 0x01, 0x01, 0x00, 0x01, 0x01, 0x01, 0x01, 0x00 }, //Wily Machine Phase 2 W4
    },
        weaknessSetsVanilla = new byte[BossCount][]
    {
        //                        P     C     I     B     F     E     G     M
        new byte[WeaponCount] { 0x03, 0x01, 0x00, 0x02, 0x03, 0x01, 0x0E, 0x00 }, //Cut Man
        new byte[WeaponCount] { 0x01, 0x02, 0x00, 0x04, 0x01, 0x0A, 0x00, 0x00 }, //Ice Man
        new byte[WeaponCount] { 0x02, 0x02, 0x00, 0x01, 0x04, 0x02, 0x00, 0x00 }, //Bomb Man
        new byte[WeaponCount] { 0x02, 0x02, 0x04, 0x01, 0x01, 0x01, 0x00, 0x00 }, //Fire Man
        new byte[WeaponCount] { 0x01, 0x0A, 0x00, 0x02, 0x01, 0x01, 0x04, 0x00 }, //Elec Man (g seems wrong)
        new byte[WeaponCount] { 0x02, 0x01, 0x00, 0x0A, 0x02, 0x01, 0x01, 0x00 }, //Guts Man
        new byte[WeaponCount] { 0x02, 0x02, 0x00, 0x00, 0x02, 0x04, 0x00, 0x00 }, //Yellow Devil W1
        new byte[WeaponCount] { 0x01, 0x01, 0x00, 0x02, 0x02, 0x02, 0x00, 0x00 }, //Copy Robot W2
        new byte[WeaponCount] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //CWU-01P W3
        new byte[WeaponCount] { 0x01, 0x01, 0x01, 0x01, 0x04, 0x01, 0x01, 0x00 }, //Wily Machine Phase 1 W4
        new byte[WeaponCount] { 0x01, 0x01, 0x00, 0x01, 0x01, 0x01, 0x01, 0x00 }, //Wily Machine Phase 2 W4

    };

    private static int ConvertAddressToNA(Address address) => address switch
    {
        Address.CutManWeaponDamage =>        0x01_FDFE,
        Address.IceManWeaponDamage =>        0x01_FE06,
        Address.BombManWeaponDamage =>       0x01_FE0E,
        Address.FireManWeaponDamage =>       0x01_FE16,
        Address.ElecManWeaponDamage =>       0x01_FE1E,
        Address.GutsManWeaponDamage =>       0x01_FE26,
        Address.YellowDevilWeaponDamage =>   0x01_FE2E,
        Address.CopyRobotWeaponDamage =>     0x01_FE36,
        Address.CWU01PWeaponDamage =>        0x01_FE3E,
        Address.WilyMachineV1WeaponDamage => 0x01_FE46,
        Address.WilyMachineV2WeaponDamage => 0x01_FE4E,

        _ => (int)address
    };

    private static int[] ConvertAddressToSNES(Address address) => address switch
    {
        Address.BossBitFlags =>      Util.RepeatedSNESAddressMM1(0x21_C148),
        Address.MagnetBeamBitFlag => Util.RepeatedSNESAddressMM1(0x21_C874),

        Address.CutManWeaponDamage =>        Util.RepeatedSNESAddressMM1(0x21_FDEE),
        Address.IceManWeaponDamage =>        Util.RepeatedSNESAddressMM1(0x21_FDF6),
        Address.BombManWeaponDamage =>       Util.RepeatedSNESAddressMM1(0x21_FDFE),
        Address.FireManWeaponDamage =>       Util.RepeatedSNESAddressMM1(0x21_FE06),
        Address.ElecManWeaponDamage =>       Util.RepeatedSNESAddressMM1(0x21_FE0E),
        Address.GutsManWeaponDamage =>       Util.RepeatedSNESAddressMM1(0x21_FE16),
        Address.YellowDevilWeaponDamage =>   Util.RepeatedSNESAddressMM1(0x21_FE1E),
        Address.CopyRobotWeaponDamage =>     Util.RepeatedSNESAddressMM1(0x21_FE26),
        Address.CWU01PWeaponDamage =>        Util.RepeatedSNESAddressMM1(0x21_FE2E),
        Address.WilyMachineV1WeaponDamage => Util.RepeatedSNESAddressMM1(0x21_FE36),
        Address.WilyMachineV2WeaponDamage => Util.RepeatedSNESAddressMM1(0x21_FE3E),

        Address.NewWeaponBitFlags =>    new int[1] { 0x3F_8000 },
        Address.NewMagnetBeamBitFlag => new int[1] { 0x3F_8015 },

        _ => new int[1] { (int)address }
    };

    private static void ShuffleEquipmentPatch(out PatchCollection jpna, out PatchCollection snes, out string spoiler, Random r = null)
    {
        r ??= new(Util.GetSeed());
        spoiler = "";

        AutoSizedArray<Equipment> equips = new(equipment, equipment.Length);
        byte[] data = new byte[equips.Length - 1];

        for (int i = 0; equips.Length > 1; i++)
        {
            int n = r.Next(equips.Length);
            Equipment e = equips[n];
            spoiler += $"{bossNamesWithSpacesShort[i]} => {e}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }

        Equipment e_ = equips[0];
        spoiler += $"Magnet Beam => {e_}\n";
        byte[] data_ = new byte[1] { (byte)e_ };

        jpna = new IPS();
        jpna.Add(new Patch((int)Address.NewWeaponBitFlags, data), MergeMode.None);
        jpna.Add(new Patch((int)Address.NewMagnetBeamBitFlag, data_), MergeMode.None);

        snes = new IPS();
        foreach (int address in ConvertAddressToSNES(Address.NewWeaponBitFlags)) snes.Add(new Patch(address, data), MergeMode.None);
        foreach (int address in ConvertAddressToSNES(Address.NewMagnetBeamBitFlag)) snes.Add(new Patch(address, data_), MergeMode.None);
    }

    public static void Generate(ref int seed, out IPS jp, out IPS na, out IPS snes, out string spoiler)
    {
        if (seed < 0) seed = Util.GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM1R Spoiler Log ---\nSeed: {seed}\n";
        jp = new();
        na = new();
        snes = new();

        ShuffleEquipmentPatch(out PatchCollection equipmentJPNA, out PatchCollection equipmentSNES, out string s, r);

        jp.Add(equipmentJPNA, MergeMode.None);
        na.Add(equipmentJPNA, MergeMode.None);
        snes.Add(equipmentSNES, MergeMode.None);

        spoiler += '\n' + s;

        AutoSizedArray<byte> ws = new(BossCount * WeaponCount);
        ws.AddConcat(weaknessSets);
        byte[] ws_ = ws.ToArray();

        jp.Add(new Patch((int)Address.CutManWeaponDamage, ws_), MergeMode.None);
        na.Add(new Patch(ConvertAddressToNA(Address.CutManWeaponDamage), ws_), MergeMode.None);
        foreach (int address in ConvertAddressToSNES(Address.CutManWeaponDamage)) snes.Add(new Patch(address, ws_), MergeMode.None);
    }
}