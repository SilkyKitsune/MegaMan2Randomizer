namespace MM2Randomizer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            outputLabel = new System.Windows.Forms.Label();
            outputButton = new System.Windows.Forms.Button();
            seedLabel = new System.Windows.Forms.Label();
            outputTextBox = new System.Windows.Forms.TextBox();
            weaknessLabel = new System.Windows.Forms.Label();
            seedTextBox = new System.Windows.Forms.TextBox();
            generateButton = new System.Windows.Forms.Button();
            nerfBusterCheckBox = new System.Windows.Forms.CheckBox();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            shuffleLevelsCheckBox = new System.Windows.Forms.CheckBox();
            heatManCheckBox = new System.Windows.Forms.CheckBox();
            shuffleEquipmentCheckBox = new System.Windows.Forms.CheckBox();
            weaknessComboBox = new System.Windows.Forms.ComboBox();
            robotsOnlyCheckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new System.Drawing.Point(12, 9);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new System.Drawing.Size(81, 15);
            outputLabel.TabIndex = 1;
            outputLabel.Text = "Output Folder";
            // 
            // outputButton
            // 
            outputButton.Location = new System.Drawing.Point(347, 27);
            outputButton.Name = "outputButton";
            outputButton.Size = new System.Drawing.Size(25, 23);
            outputButton.TabIndex = 5;
            outputButton.Text = "...";
            outputButton.UseVisualStyleBackColor = true;
            outputButton.Click += outputButton_Click;
            // 
            // seedLabel
            // 
            seedLabel.AutoSize = true;
            seedLabel.Location = new System.Drawing.Point(12, 53);
            seedLabel.Name = "seedLabel";
            seedLabel.Size = new System.Drawing.Size(89, 15);
            seedLabel.TabIndex = 4;
            seedLabel.Text = "Seed (Optional)";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new System.Drawing.Point(12, 27);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new System.Drawing.Size(329, 23);
            outputTextBox.TabIndex = 3;
            // 
            // weaknessLabel
            // 
            weaknessLabel.AutoSize = true;
            weaknessLabel.Location = new System.Drawing.Point(12, 97);
            weaknessLabel.Name = "weaknessLabel";
            weaknessLabel.Size = new System.Drawing.Size(99, 15);
            weaknessLabel.TabIndex = 7;
            weaknessLabel.Text = "Weakness Shuffle";
            // 
            // seedTextBox
            // 
            seedTextBox.Location = new System.Drawing.Point(12, 71);
            seedTextBox.Name = "seedTextBox";
            seedTextBox.Size = new System.Drawing.Size(360, 23);
            seedTextBox.TabIndex = 6;
            // 
            // generateButton
            // 
            generateButton.Location = new System.Drawing.Point(297, 240);
            generateButton.Name = "generateButton";
            generateButton.Size = new System.Drawing.Size(75, 23);
            generateButton.TabIndex = 8;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // nerfBusterCheckBox
            // 
            nerfBusterCheckBox.AutoSize = true;
            nerfBusterCheckBox.Enabled = false;
            nerfBusterCheckBox.Location = new System.Drawing.Point(12, 169);
            nerfBusterCheckBox.Name = "nerfBusterCheckBox";
            nerfBusterCheckBox.Size = new System.Drawing.Size(343, 19);
            nerfBusterCheckBox.TabIndex = 9;
            nerfBusterCheckBox.Text = "4 Random Robots/All Castle Bosses Immune to Mega Buster";
            nerfBusterCheckBox.UseVisualStyleBackColor = true;
            // 
            // shuffleLevelsCheckBox
            // 
            shuffleLevelsCheckBox.AutoSize = true;
            shuffleLevelsCheckBox.Location = new System.Drawing.Point(11, 244);
            shuffleLevelsCheckBox.Name = "shuffleLevelsCheckBox";
            shuffleLevelsCheckBox.Size = new System.Drawing.Size(98, 19);
            shuffleLevelsCheckBox.TabIndex = 10;
            shuffleLevelsCheckBox.Text = "Shuffle Levels";
            shuffleLevelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // heatManCheckBox
            // 
            heatManCheckBox.AutoSize = true;
            heatManCheckBox.Location = new System.Drawing.Point(11, 219);
            heatManCheckBox.Name = "heatManCheckBox";
            heatManCheckBox.Size = new System.Drawing.Size(196, 19);
            heatManCheckBox.TabIndex = 11;
            heatManCheckBox.Text = "Never place Item 2 on Heat Man";
            heatManCheckBox.UseVisualStyleBackColor = true;
            // 
            // shuffleEquipmentCheckBox
            // 
            shuffleEquipmentCheckBox.AutoSize = true;
            shuffleEquipmentCheckBox.Enabled = false;
            shuffleEquipmentCheckBox.Location = new System.Drawing.Point(11, 194);
            shuffleEquipmentCheckBox.Name = "shuffleEquipmentCheckBox";
            shuffleEquipmentCheckBox.Size = new System.Drawing.Size(218, 19);
            shuffleEquipmentCheckBox.TabIndex = 12;
            shuffleEquipmentCheckBox.Text = "Shuffle Weapons and Items together";
            shuffleEquipmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // weaknessComboBox
            // 
            weaknessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            weaknessComboBox.Enabled = false;
            weaknessComboBox.FormattingEnabled = true;
            weaknessComboBox.Items.AddRange(new object[] { "None", "Boss Sets", "Per Boss", "All" });
            weaknessComboBox.Location = new System.Drawing.Point(12, 115);
            weaknessComboBox.Name = "weaknessComboBox";
            weaknessComboBox.Size = new System.Drawing.Size(360, 23);
            weaknessComboBox.TabIndex = 13;
            weaknessComboBox.SelectedIndexChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // robotsOnlyCheckBox
            // 
            robotsOnlyCheckBox.AutoSize = true;
            robotsOnlyCheckBox.Enabled = false;
            robotsOnlyCheckBox.Location = new System.Drawing.Point(12, 144);
            robotsOnlyCheckBox.Name = "robotsOnlyCheckBox";
            robotsOnlyCheckBox.Size = new System.Drawing.Size(257, 19);
            robotsOnlyCheckBox.TabIndex = 14;
            robotsOnlyCheckBox.Text = "Shuffle Castle Boss Weaknesses with Robots";
            robotsOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 276);
            Controls.Add(robotsOnlyCheckBox);
            Controls.Add(weaknessComboBox);
            Controls.Add(shuffleEquipmentCheckBox);
            Controls.Add(heatManCheckBox);
            Controls.Add(shuffleLevelsCheckBox);
            Controls.Add(nerfBusterCheckBox);
            Controls.Add(generateButton);
            Controls.Add(weaknessLabel);
            Controls.Add(seedTextBox);
            Controls.Add(outputButton);
            Controls.Add(seedLabel);
            Controls.Add(outputTextBox);
            Controls.Add(outputLabel);
            Name = "MainWindow";
            Text = "Mega Man 2 Randomizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label weaknessLabel;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.CheckBox nerfBusterCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox shuffleLevelsCheckBox;
        private System.Windows.Forms.CheckBox heatManCheckBox;
        private System.Windows.Forms.CheckBox shuffleEquipmentCheckBox;
        private System.Windows.Forms.ComboBox weaknessComboBox;
        private System.Windows.Forms.CheckBox robotsOnlyCheckBox;
    }
}