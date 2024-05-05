using System;
using F = System.IO.File;
using D = System.IO.Directory;
using P = System.IO.Path;
using System.Windows.Forms;
using IPSLib;

namespace MM2Randomizer;

public partial class MainWindow : Form
{
    private const int RomSize = 0x40010;

    private const string InvalidFile = "INVALID FILE", InvalidPath = "INVALID PATH", Ext = ".nes", FileName = "MM2R_",
        IncreaseBarSpeed = "IncreaseBarSpeed.ips",
        IncreaseMenuSpeed = "IncreaseMenuSpeed.ips",
        KeepETanks = "KeepETanks.ips",
        LevelRoutineFix = "LevelRoutineFix.ips",
        ReplaceBooBeamWalls = "ReplaceBooBeamWalls.ips";
    
    public MainWindow() => InitializeComponent();

    private void generateButton_Click(object sender, EventArgs e) => GenerateButton();

    private void ipsCheckBox_CheckedChanged(object sender, EventArgs e) => IPSCheckBox();

    private void outputButton_Click(object sender, EventArgs e) => OutputFolderButton();

    private void romPathButton_Click(object sender, EventArgs e) => RomPathButton();

    private void GenerateButton()
    {
        if (!F.Exists(IncreaseBarSpeed) ||
            !F.Exists(IncreaseMenuSpeed) ||
            !F.Exists(KeepETanks) ||
            !F.Exists(LevelRoutineFix) ||
            !F.Exists(ReplaceBooBeamWalls))
        {
            Close();
            return;
        }

        bool ips = ipsCheckBox.Checked, heatManNoItem2 = heatManCheckBox.Checked, replaceBooBeamWalls = wallCheckBox.Checked, shuffleLevels = shuffleLevelsCheckBox.Checked;
        string romPath = romPathTextBox.Text, folderPath = outputTextBox.Text, seedText = seedTextBox.Text;
        byte[] rom = null;

        if (!ips)
        {
            if (!F.Exists(romPath))
            {
                romPathTextBox.Text = InvalidPath;
                return;
            }

            rom = F.ReadAllBytes(romPath);
            if (rom.Length != RomSize)
            {
                romPathTextBox.Text = InvalidFile;
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
        IPS patch = new(LevelRoutineFix);
        patch.Add(new(IncreaseBarSpeed), false);
        patch.Add(new(IncreaseMenuSpeed), false);
        patch.Add(new(KeepETanks), false);
        if (replaceBooBeamWalls) patch.Add(new(ReplaceBooBeamWalls), false);
        MM2.Generate(ref patch, ref seed, out string spoiler, heatManNoItem2, shuffleLevels);

        string outPath = P.Combine(folderPath, FileName + seed);
        F.WriteAllText(outPath + "_Spoiler.txt", spoiler);
        if (ips) patch.WritePatch(outPath);
        else
        {
            patch.Apply(rom);
            F.WriteAllBytes(P.Combine(folderPath, outPath + Ext), rom);
        }

        seedTextBox.Text = seed.ToString();
        generateButton.Enabled = true;
    }

    private void IPSCheckBox()
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

    private void RomPathButton()
    {
        openFileDialog.ShowDialog();
        romPathTextBox.Text = openFileDialog.FileName;
    }
}