#if DEBUG
using System;
using ProjectFox.CoreEngine.Collections;
using IPSLib;

namespace MM2Randomizer;

public static class MM1
{
    internal enum Address : int
    {
        RobotBitMasks = 0x01_C158,
        MagnetBeamBitMask_Original = 0x01_C884,
        BossWeaknesses = 0x01_FE32, //$FE22
        WeaponBitMasks = 0x01_FF10,
        MagnetBeamBitMask_New = 0x01_FF24,
    }

    internal enum Equipment : byte
    {
        None = 0x00,
        Unused = 0x01,

        HyperBomb = 0x02,
        ThunderBeam = 0x04,
        SuperArm = 0x08,
        IceSlasher = 0x10,
        RollingCutter = 0x20,
        FireStorm = 0x40,
        MagnetBeam = 0x80
    }

    internal enum StageIndex : byte
    {
        CutMan = 0x00,
        IceMan = 0x01,
        BombMan = 0x02,
        FireMan = 0x03,
        ElecMan = 0x04,
        GutsMan = 0x05,

        //YellowDevilW1 = ?,
        //CopyRobotW2 = ?,
        //CWU01P_W3 = ?,
        //W4 = ?
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

    private static readonly StageIndex[] stages =
    {
        StageIndex.CutMan,
        StageIndex.IceMan,
        StageIndex.BombMan,
        StageIndex.FireMan,
        StageIndex.ElecMan,
        StageIndex.GutsMan
    };

    private static readonly string[] bossNames =
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
        "Wily Machine",
    };

    private static readonly byte[][] weaknessSets =
    {
        //             P     C     I     B     F     E     G     M
        new byte[] { 0x03, 0x01, 0x00, 0x02, 0x03, 0x01, 0x0E, 0x00 }, //Cut Man
        new byte[] { 0x01, 0x02, 0x00, 0x04, 0x01, 0x0A, 0x00, 0x00 }, //Ice Man
        new byte[] { 0x02, 0x02, 0x00, 0x01, 0x04, 0x02, 0x00, 0x00 }, //Bomb Man
        new byte[] { 0x02, 0x02, 0x04, 0x01, 0x01, 0x01, 0x00, 0x00 }, //Fire Man
        new byte[] { 0x01, 0x0A, 0x00, 0x02, 0x01, 0x01, 0x00, 0x00 }, //Elec Man (g seems wrong)
        new byte[] { 0x02, 0x01, 0x00, 0x0A, 0x02, 0x01, 0x01, 0x00 }, //Guts Man
        new byte[] { 0x02, 0x04, 0x00, 0x00, 0x04, 0x07, 0x00, 0x00 }, //Yellow Devil W1
        new byte[] { 0x02, 0x02, 0x00, 0x0A, 0x04, 0x04, 0x00, 0x01 }, //Copy Robot W2 (temp magnet beam value)
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //CWU-01P W3
        new byte[] { 0x01, 0x01, 0x01, 0x01, 0x04, 0x01, 0x01, 0x00 }, //Wily Machine W4 (might only be phase 1)
    },
        weaknessSetsVanilla =
    {
        //             P     C     I     B     F     E     G     M
        new byte[] { 0x03, 0x01, 0x00, 0x02, 0x03, 0x01, 0x0E, 0x00 }, //Cut Man
        new byte[] { 0x01, 0x02, 0x00, 0x04, 0x01, 0x0A, 0x00, 0x00 }, //Ice Man
        new byte[] { 0x02, 0x02, 0x00, 0x01, 0x04, 0x02, 0x00, 0x00 }, //Bomb Man
        new byte[] { 0x02, 0x02, 0x04, 0x01, 0x01, 0x01, 0x00, 0x00 }, //Fire Man
        new byte[] { 0x01, 0x0A, 0x00, 0x02, 0x01, 0x01, 0x00, 0x00 }, //Elec Man (g seems wrong)
        new byte[] { 0x02, 0x01, 0x00, 0x0A, 0x02, 0x01, 0x01, 0x00 }, //Guts Man
        new byte[] { 0x02, 0x02, 0x00, 0x00, 0x02, 0x04, 0x00, 0x00 }, //Yellow Devil W1
        new byte[] { 0x01, 0x01, 0x00, 0x02, 0x02, 0x02, 0x00, 0x00 }, //Copy Robot W2
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, //CWU-01P W3
        new byte[] { 0x01, 0x01, 0x01, 0x01, 0x04, 0x01, 0x01, 0x00 }, //Wily Machine W4 (might only be phase 1)
    };

    private static void ShuffleEquipmentPatch(out string spoiler, out Patch weaponsPatch, out Patch magnetBeamPatch, Random r = null)
    {
        r ??= new(Util.GetSeed());
        spoiler = "";

        AutoSizedArray<Equipment> equips = new(equipment, equipment.Length);
        byte[] data = new byte[equips.Length - 1];

        //Address address = Address.RobotBitMasks;
        for (int i = 0; equips.Length > 1; i++/*, address++*/)//update mm2 spoiler to be like this
        {
            int n = r.Next(equips.Length);
            Equipment e = equips[n];
            spoiler += $"{bossNames[i]/*address*/} => {e}\n";
            data[i] = (byte)e;
            equips.RemoveAt(n);
        }
        weaponsPatch = new((int)Address.WeaponBitMasks, data);

        Equipment e_ = equips[0];
        spoiler += $"{Equipment.MagnetBeam} => {e_}\n";
        magnetBeamPatch = new((int)Address.MagnetBeamBitMask_New, new byte[1] { (byte)e_ });
    }

    public static void Generate(ref int seed, out IPS jp, /*out IPS na,*/ out string spoiler)
    {
        if (seed == 0) seed = Util.GetSeed();
        Random r = new(seed);

        spoiler = $"--- MM1R Spoiler Log ---\nSeed: {seed}\n\n";
        jp = new();
        //na = new();

        ShuffleEquipmentPatch(out string s, out Patch weaponsPatch, out Patch magnetBeamPatch, r);
        jp.Add(weaponsPatch, MergeMode.CombineOver);
        jp.Add(magnetBeamPatch, MergeMode.CombineOver);
        spoiler += s;

        AutoSizedArray<byte> ws = new(weaknessSets.Length * weaknessSets[0].Length);
        ws.AddConcat(weaknessSets);
        jp.Add(new Patch((int)Address.BossWeaknesses, ws.ToArray()), MergeMode.CombineOver);
    }
}
#endif