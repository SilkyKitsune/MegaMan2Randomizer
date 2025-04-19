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
        "FastCrashBomber_NA.ips",
        "IncreaseBarSpeed.ips",
        "IncreaseMenuSpeed_NA.ips",
        "KeepETanks.ips",
        "MetalBladeNerf_NA.ips",
        "QuickBoomerangNerf_NA.ips",
        "ReEnterLevels.ips",
        "SplitWeaponFlags.ips",//rename?
    };

    public MainWindow() => InitializeComponent();

    private void generateButton_Click(object sender, EventArgs e) => GenerateButton();

    private void outputButton_Click(object sender, EventArgs e) => OutputFolderButton();

    private void GenerateButton()
    {
        IPS patch = new();

        foreach (string path in Paths)
            if (F.Exists(path) && IPS.TryRead(out IPS patch_, path)) patch.Add(patch_, IPS.MergeMode.Combine);
            else
            {
                Close();
                return;
            }

        bool heatManNoItem2 = heatManCheckBox.Checked, shuffleAllEquipment = shuffleEquipmentCheckBox.Checked, shuffleLevels = shuffleLevelsCheckBox.Checked;
        string folderPath = outputTextBox.Text, seedText = seedTextBox.Text;

        if (shuffleLevels)
        {
            if (F.Exists(MysteryStageSelectPath) && IPS.TryRead(out IPS patch_, MysteryStageSelectPath)) patch.Add(patch_, IPS.MergeMode.Combine);
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

        MM2.Generate(ref patch, ref seed, out string spoiler, heatManNoItem2, shuffleAllEquipment, shuffleLevels);

        string outPath = P.Combine(folderPath, FileName + seed);
        F.WriteAllText(outPath + "_Spoiler.txt", spoiler);
        patch.WritePatch(outPath);

        seedTextBox.Text = seed.ToString();
        generateButton.Enabled = true;
    }

    [Obsolete] private void IPSCheckBox()
    {
        bool ips = ipsCheckBox.Checked;
        romPathTextBox.Enabled = !ips;
        romPathButton.Enabled = !ips;
    }

    private void OutputFolderButton()
    {
        folderBrowserDialog.ShowDialog();
        outputTextBox.Text = folderBrowserDialog.SelectedPath;
    }

    [Obsolete] private void RomPathButton()
    {
        openFileDialog.ShowDialog();
        romPathTextBox.Text = openFileDialog.FileName;
    }
}