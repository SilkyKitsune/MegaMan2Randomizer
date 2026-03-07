using System;
using System.IO;
using System.Windows.Forms;
using IPSLib;

namespace MM2Randomizer;

public partial class MainWindow : Form
{
    private const string InvalidPath = "INVALID PATH", FileName = "MM2R_", MysteryStageSelectPath = "MysteryStageSelect.ips",
        HalloweenModePath = "HalloweenMode.ips", HalloweenModeJPPath = "HalloweenMode_JP.ips", HalloweenModeNAPath = "HalloweenMode_NA.ips";

    private static readonly string[]
        Paths =
    {
        "BooBeamNerf.ips",
        "IncreaseBarSpeed.ips",
        "KeepETanks.ips",
        "ReEnterLevels.ips",
        "SplitWeaponFlags.ips",//rename?
    },
        PathsJP =
    {
        "AtomicFireFix_JP.ips",
        "FastCrashBomber_JP.ips",
        "IncreaseMenuSpeed_JP.ips",
        "Item1Buff_JP.ips",
        "Item2Buff_JP.ips",
        "Item3Buff_JP.ips",
        "MetalBladeNerf_JP.ips",
        "QuickBoomerangNerf_JP.ips",
    },
        PathsNA =
    {
        "AtomicFireFix_NA.ips",
        "FastCrashBomber_NA.ips",
        "IncreaseMenuSpeed_NA.ips",
        "Item1Buff_NA.ips",
        "Item2Buff_NA.ips",
        "Item3Buff_NA.ips",
        "MetalBladeNerf_NA.ips",
        "QuickBoomerangNerf_NA.ips",
    };

    public MainWindow()
    {
        InitializeComponent();
        weaknessComboBox.SelectedIndex = 0;
        robotsOnlyCheckBox.Enabled = true;//temp, idk why winforms isn't setting this true

        if (PatchManager.LoadPatches(out string errors))
        {
            outputTextBox.Enabled = false;
            outputButton.Enabled = false;
            seedTextBox.Enabled = false;
            weaknessComboBox.Enabled = false;
            robotsOnlyCheckBox.Enabled = false;
            nerfBusterCheckBox.Enabled = false;
            shuffleEquipmentCheckBox.Enabled = false;
            heatManCheckBox.Enabled = false;
            shuffleLevelsCheckBox.Enabled = false;
            generateButton.Enabled = false;
            seedTextBox.Text = outputTextBox.Text = "INVALID PATCHES";//temp
            MessageBox.Show("Errors loading patches:\n" + errors, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        october = DateTime.Now.Month == 10;

        if (october) Text += " 🎃";
    }

    private readonly bool october;

    private void generateButton_Click(object sender, EventArgs e) => GenerateButton();

    private void outputButton_Click(object sender, EventArgs e) => OutputFolderButton();

    private void weaknessComboBox_SelectedIndexChanged(object sender, EventArgs e) => WeaknessShuffleIndex();

    private void GenerateButton()
    {
        bool shuffleAllEquipment = shuffleEquipmentCheckBox.Checked, heatManNoItem2 = heatManCheckBox.Checked, shuffleLevels = shuffleLevelsCheckBox.Checked,
            robotsOnly = !robotsOnlyCheckBox.Checked, nerfBuster = nerfBusterCheckBox.Checked;
        int weaknessShuffle = weaknessComboBox.SelectedIndex;
        string folderPath = outputTextBox.Text, seedText = seedTextBox.Text;
        
        if (weaknessShuffle == 3)//temp
        {
            MessageBox.Show("Selected weakness shuffle option is currently not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (string.IsNullOrEmpty(folderPath))
        {
            MessageBox.Show("No output folder path specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!Directory.Exists(folderPath))
        {
            MessageBox.Show("Output folder path does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        generateButton.Enabled = false;

        int seed = int.TryParse(seedText, out int i) ? i : (!string.IsNullOrEmpty(seedText) ? seedText.GetHashCode() : 0);

        IPS patchJP = new(), patchNA = new();
        PatchManager.AddPatches(patchJP, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.Japan);
        PatchManager.AddPatches(patchNA, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.NorthAmerica);

        if (shuffleLevels)
        {
            PatchManager.AddPatch(patchJP, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.Japan, PatchManager.PatchID.MysteryStageSelect);
            PatchManager.AddPatch(patchNA, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.NorthAmerica, PatchManager.PatchID.MysteryStageSelect);
        }

        if (october)
        {
            PatchManager.AddPatch(patchJP, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.Japan, PatchManager.PatchID.HalloweenMode1);
            PatchManager.AddPatch(patchJP, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.Japan, PatchManager.PatchID.HalloweenMode2);

            PatchManager.AddPatch(patchNA, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.NorthAmerica, PatchManager.PatchID.HalloweenMode1);
            PatchManager.AddPatch(patchNA, MergeMode.None, PatchManager.GameID.MM2, PatchManager.VersionID.NorthAmerica, PatchManager.PatchID.HalloweenMode2);
        }

        MM2.Generate(ref seed, out IPS shuffledPatchJP, out IPS shuffledPatchNA, out string spoiler, shuffleAllEquipment, heatManNoItem2, shuffleLevels, weaknessShuffle, robotsOnly, nerfBuster);
        patchJP.Add(shuffledPatchJP, MergeMode.CombineOver);
        patchNA.Add(shuffledPatchNA, MergeMode.CombineOver);

        folderPath += '\\' + (october ? "MM2R🎃 " : "MM2R ") + seed;
        File.WriteAllText(folderPath + " (Spoiler).txt", spoiler);
        patchJP.WritePatch(folderPath + $" ({PatchManager.VersionID.Japan})");
        patchNA.WritePatch(folderPath + $" ({PatchManager.VersionID.NorthAmerica})");

        seedTextBox.Text = seed.ToString();
        generateButton.Enabled = true;
    }

    private void OutputFolderButton()
    {
        folderBrowserDialog.ShowDialog();
        outputTextBox.Text = folderBrowserDialog.SelectedPath;
    }
    
    private void WeaknessShuffleIndex() => robotsOnlyCheckBox.Enabled = weaknessComboBox.SelectedIndex != 0;
}