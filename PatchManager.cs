using System.IO;
using ProjectFox.CoreEngine.Collections;
using IPSLib;

namespace MM2Randomizer;

public static class PatchManager
{
    public enum GameID : int
    {
        MM1,
        MM2,

        Count
    }

    public enum VersionID : ushort
    {
        None = '\0',
        Japan = 'J',
        NorthAmerica = 'N',
    }

    public enum PatchID : int
    {
        AtomicFireFix,
        BooBeamNerf,
        FastCrashBomber,
        HalloweenMode1,
        HalloweenMode2,
        IncreaseBarSpeed,
        IncreaseMenuSpeed,
        Item1Buff,
        Item2Buff,
        Item3Buff,
        KeepETanks,
        MetalBladeNerf,
        MM2RTitle,
        MysteryStageSelect,
        QuickBoomerangNerf,
        ReEnterLevelsMM2,
        SplitWeaponFlagsMM2,
        WoodManRoomFix,

        Count
    }

    private readonly struct CompoundID
    {
        public CompoundID(GameID game, VersionID version, PatchID patch)
        {
            this.game = game;
            this.version = version;
            this.patch = patch;
        }

        public readonly GameID game;
        public readonly VersionID version;
        public readonly PatchID patch;

        public override bool Equals(object obj) => obj is CompoundID id && Equals(id);

        public bool Equals(CompoundID id) => game == id.game && version == id.version && patch == id.patch;

        public override string ToString() => $"{game} ({version}) - {patch}";
    }

    private static readonly AutoSizedArray<PatchID> optional = new(new PatchID[]
    {
        PatchID.HalloweenMode1,
        PatchID.HalloweenMode2,
        PatchID.MysteryStageSelect,
    });

    private static readonly AutoSizedArray<CompoundID> dontExist = new(new CompoundID[]
    {
        new(GameID.MM2, VersionID.NorthAmerica, PatchID.MM2RTitle)
    });

    private static readonly LookupTable<CompoundID, IPS> patchTable = new(0x80);

    private static string ValidatePatches(GameID game, PatchID first, PatchID last, params VersionID[] versions)
    {
        string errors = "";
        for (; first < last; first++)
            foreach (VersionID version in versions)
            {
                CompoundID id = new(game, version, first);
                if (!dontExist.Contains(id) && !patchTable.ContainsCode(id)) errors += $"Patch not found \"{id}\"\n";
            }
        return errors;
    }

    internal static void AddPatch(PatchCollection patchCollection, MergeMode mergeMode, GameID game, VersionID version, PatchID patch)
    {
        int index = patchTable.IndexOfCode(new(game, version, patch));
        if (index >= 0) patchCollection.Add(patchTable.Get(index), mergeMode);
    }

    internal static void AddPatches(PatchCollection patchCollection, MergeMode mergeMode, GameID game, VersionID version, bool excludeOptional = true)
    {
        CompoundID[] ids = patchTable.GetCodes();
        IPS[] patches = patchTable.GetValues();
        for (int i = 0; i < ids.Length; i++)
        {
            CompoundID id = ids[i];
            if (id.game == game && id.version == version && (!excludeOptional || !optional.Contains(id.patch)))
                patchCollection.Add(patches[i], mergeMode);
        }
    }

    internal static bool LoadPatches(out string errors)
    {
        errors = "";

        LookupTable<PatchID, string> patchNames = new((int)PatchID.Count);
        for (PatchID patchIndex = 0, patchCount = PatchID.Count; patchIndex < patchCount; patchIndex++)
            patchNames.Add(patchIndex, patchIndex.ToString());

        for (GameID game = 0; game < GameID.Count; game++)
        {
            string gameFolder = Path.Combine("Patches", game.ToString());
            if (!Directory.Exists(gameFolder))
            {
                errors += $"Patch folder \"{game}\" doesn't exist\n";
                continue;
            }

            foreach (string patchFolder in Directory.GetDirectories(gameFolder))
                foreach (string filePath in Directory.GetFiles(patchFolder))
                {
                    string[] fileName = Path.GetFileNameWithoutExtension(filePath).Split('_');
                    if (fileName.Length >= 1 && patchNames.TryGetCode(fileName[0], out PatchID patch) && IPS.TryRead(out IPS ips, filePath))
                    {
                        if (fileName.Length == 2) foreach (char c in fileName[1])
                            {
                                CompoundID id = new(game, (VersionID)c, patch);
                                if (patchTable.ContainsCode(id)) errors += $"Duplicate patch of {id} was found\n";
                                else patchTable.Add(id, ips);
                            }
                        else
                        {
                            CompoundID id = new(game, VersionID.None, patch);
                            if (patchTable.ContainsCode(id)) errors += $"Duplicate patch of {id} was found\n";
                            else patchTable.Add(id, ips);
                        }
                    }
                }
        }

        errors +=
            ValidatePatches(GameID.MM2, PatchID.AtomicFireFix, PatchID.Count, VersionID.Japan, VersionID.NorthAmerica);

        return errors.Length > 0;
    }
}