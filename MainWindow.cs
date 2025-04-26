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
        //"BooBeamNerf.ips",
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

    public MainWindow() => InitializeComponent();

    private void generateButton_Click(object sender, EventArgs e) => GenerateButton();

    private void outputButton_Click(object sender, EventArgs e) => OutputFolderButton();

    private void weaknessComboBox_SelectedIndexChanged(object sender, EventArgs e) => WeaknessShuffleIndex();

    private void GenerateButton()
    {
        IPS patchJP = new(), patchNA = new();

        foreach (string path in Paths)
            if (F.Exists(path) && IPS.TryRead(out IPS patch_, path))
            {
                patchJP.Add(patch_, MergeMode.Combine);
                patchNA.Add(patch_, MergeMode.Combine);
            }
            else
            {
                Close();
                return;
            }

        foreach (string path in PathsJP)
            if (F.Exists(path) && IPS.TryRead(out IPS patch_, path)) patchJP.Add(patch_, MergeMode.Combine);
            else
            {
                Close();
                return;
            }

        foreach (string path in PathsNA)
            if (F.Exists(path) && IPS.TryRead(out IPS patch_, path)) patchNA.Add(patch_, MergeMode.Combine);
            else
            {
                Close();
                return;
            }

        bool heatManNoItem2 = heatManCheckBox.Checked, shuffleAllEquipment = shuffleEquipmentCheckBox.Checked, shuffleLevels = shuffleLevelsCheckBox.Checked;
        string folderPath = outputTextBox.Text, seedText = seedTextBox.Text;

        if (shuffleLevels)
        {
            if (F.Exists(MysteryStageSelectPath) && IPS.TryRead(out IPS patch_, MysteryStageSelectPath))
            {
                patchJP.Add(patch_, MergeMode.Combine);
                patchNA.Add(patch_, MergeMode.Combine);
            }
            else
            {
                Close();
                return;
            }
        }

        if (!D.Exists(folderPath))
        {
            outputTextBox.Text = InvalidPath;
            return;
        }

        generateButton.Enabled = false;

        int seed = int.TryParse(seedText, out int i) ? i : (!string.IsNullOrEmpty(seedText) ? seedText.GetHashCode() : 0);

        IPS shuffledPatch = MM2.Generate(ref seed, out string spoiler, heatManNoItem2, shuffleAllEquipment, shuffleLevels);
        patchJP.Add(shuffledPatch, MergeMode.Combine);
        patchNA.Add(shuffledPatch, MergeMode.Combine);

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