using System;
using F = System.IO.File;
using D = System.IO.Directory;
using P = System.IO.Path;
using System.Windows.Forms;
using IPSLib;

namespace MM2Randomizer;

public partial class MainWindow : Form
{
    private const string InvalidPath = "INVALID PATH", FileName = "MM2R_", MysteryStageSelectPath = "MysteryStageSelect.ips";

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

        bool invalidPatches = false;
        string invalidPaths = "";

        if (!IPS.TryRead(out mysteryStageSelect, MysteryStageSelectPath))
        {
            invalidPatches = true;
            invalidPaths += MysteryStageSelectPath + '\n';
        }

        for (int i = 0; i < Paths.Length; i++)
            if (!IPS.TryRead(out patches[i], Paths[i]))
            {
                invalidPatches = true;
                invalidPaths += Paths[i] + '\n';
            }

        for (int i = 0; i < PathsJP.Length; i++)
            if (!IPS.TryRead(out patchesJP[i], PathsJP[i]))
            {
                invalidPatches = true;
                invalidPaths += PathsJP[i] + '\n';
            }

        for (int i = 0; i < PathsNA.Length; i++)
            if (!IPS.TryRead(out patchesNA[i], PathsNA[i]))
            {
                invalidPatches = true;
                invalidPaths += PathsNA[i] + '\n';
            }
        
        if (invalidPatches)
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
            MessageBox.Show("These patches could not be loaded they may be missing or corrupt:\n" + invalidPaths, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private readonly IPS mysteryStageSelect;
    private readonly IPS[] patches = new IPS[Paths.Length], patchesJP = new IPS[PathsJP.Length], patchesNA = new IPS[PathsNA.Length];

    private void generateButton_Click(object sender, EventArgs e) => GenerateButton();

    private void outputButton_Click(object sender, EventArgs e) => OutputFolderButton();

    private void weaknessComboBox_SelectedIndexChanged(object sender, EventArgs e) => WeaknessShuffleIndex();

    private void GenerateButton()
    {
        bool shuffleAllEquipment = shuffleEquipmentCheckBox.Checked, heatManNoItem2 = heatManCheckBox.Checked, shuffleLevels = shuffleLevelsCheckBox.Checked,
            robotsOnly = !robotsOnlyCheckBox.Checked, nerfBuster = nerfBusterCheckBox.Checked;
        int weaknessShuffle = weaknessComboBox.SelectedIndex;
        string folderPath = outputTextBox.Text, seedText = seedTextBox.Text;
        
        if (!D.Exists(folderPath))
        {
            outputTextBox.Text = InvalidPath;
            return;
        }

        generateButton.Enabled = false;

        IPS patchJP = new(), patchNA = new();

        foreach (IPS patch in patches)
        {
            patchJP.Add(patch, MergeMode.Combine);
            patchNA.Add(patch, MergeMode.Combine);
        }
        
        foreach (IPS patch in patchesJP) patchJP.Add(patch, MergeMode.Combine);

        foreach (IPS patch in patchesNA) patchNA.Add(patch, MergeMode.Combine);

        if (shuffleLevels)
        {
            patchJP.Add(mysteryStageSelect, MergeMode.Combine);
            patchNA.Add(mysteryStageSelect, MergeMode.Combine);
        }

        int seed = int.TryParse(seedText, out int i) ? i : (!string.IsNullOrEmpty(seedText) ? seedText.GetHashCode() : 0);

        MM2.Generate(ref seed, out IPS shuffledPatchJP, out IPS shuffledPatchNA, out string spoiler, shuffleAllEquipment, heatManNoItem2, shuffleLevels, weaknessShuffle, robotsOnly, nerfBuster);
        patchJP.Add(shuffledPatchJP, MergeMode.Combine);
        patchNA.Add(shuffledPatchNA, MergeMode.Combine);

        string outPath = P.Combine(folderPath, FileName + seed);
        F.WriteAllText(outPath + "_Spoiler.txt", spoiler);
        patchJP.WritePatch(outPath + "_JP");
        patchNA.WritePatch(outPath + "_NA");

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