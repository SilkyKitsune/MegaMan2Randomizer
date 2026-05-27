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
            tabControl = new System.Windows.Forms.TabControl();
            MM1Tab = new System.Windows.Forms.TabPage();
            robotsOnlyMM1CheckBox = new System.Windows.Forms.CheckBox();
            weaknessMM1ComboBox = new System.Windows.Forms.ComboBox();
            weaknessMM1Label = new System.Windows.Forms.Label();
            MM2Tab = new System.Windows.Forms.TabPage();
            damage2Label = new System.Windows.Forms.Label();
            bossCount2Label = new System.Windows.Forms.Label();
            damageMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            damageMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            damageLabel = new System.Windows.Forms.Label();
            bossCountLabel = new System.Windows.Forms.Label();
            bossCountMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            bossCountMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            timeStopperComboBox = new System.Windows.Forms.ComboBox();
            timeStopperLabel = new System.Windows.Forms.Label();
            bossComboBox = new System.Windows.Forms.ComboBox();
            bossLabel = new System.Windows.Forms.Label();
            tabControl.SuspendLayout();
            MM1Tab.SuspendLayout();
            MM2Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)damageMaxNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)damageMinNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bossCountMaxNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bossCountMinNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new System.Drawing.Point(12, 380);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new System.Drawing.Size(81, 15);
            outputLabel.TabIndex = 1;
            outputLabel.Text = "Output Folder";
            // 
            // outputButton
            // 
            outputButton.Location = new System.Drawing.Point(383, 398);
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
            seedLabel.Location = new System.Drawing.Point(12, 424);
            seedLabel.Name = "seedLabel";
            seedLabel.Size = new System.Drawing.Size(89, 15);
            seedLabel.TabIndex = 4;
            seedLabel.Text = "Seed (Optional)";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new System.Drawing.Point(12, 398);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new System.Drawing.Size(365, 23);
            outputTextBox.TabIndex = 3;
            // 
            // weaknessLabel
            // 
            weaknessLabel.AutoSize = true;
            weaknessLabel.Location = new System.Drawing.Point(6, 3);
            weaknessLabel.Name = "weaknessLabel";
            weaknessLabel.Size = new System.Drawing.Size(99, 15);
            weaknessLabel.TabIndex = 7;
            weaknessLabel.Text = "Weakness Shuffle";
            // 
            // seedTextBox
            // 
            seedTextBox.Location = new System.Drawing.Point(12, 442);
            seedTextBox.Name = "seedTextBox";
            seedTextBox.Size = new System.Drawing.Size(315, 23);
            seedTextBox.TabIndex = 6;
            // 
            // generateButton
            // 
            generateButton.Location = new System.Drawing.Point(333, 442);
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
            nerfBusterCheckBox.Location = new System.Drawing.Point(6, 75);
            nerfBusterCheckBox.Name = "nerfBusterCheckBox";
            nerfBusterCheckBox.Size = new System.Drawing.Size(343, 19);
            nerfBusterCheckBox.TabIndex = 9;
            nerfBusterCheckBox.Text = "4 Random Robots/All Castle Bosses Immune to Mega Buster";
            nerfBusterCheckBox.UseVisualStyleBackColor = true;
            // 
            // shuffleLevelsCheckBox
            // 
            shuffleLevelsCheckBox.AutoSize = true;
            shuffleLevelsCheckBox.Location = new System.Drawing.Point(5, 150);
            shuffleLevelsCheckBox.Name = "shuffleLevelsCheckBox";
            shuffleLevelsCheckBox.Size = new System.Drawing.Size(98, 19);
            shuffleLevelsCheckBox.TabIndex = 10;
            shuffleLevelsCheckBox.Text = "Shuffle Levels";
            shuffleLevelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // heatManCheckBox
            // 
            heatManCheckBox.AutoSize = true;
            heatManCheckBox.Checked = true;
            heatManCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            heatManCheckBox.Location = new System.Drawing.Point(5, 125);
            heatManCheckBox.Name = "heatManCheckBox";
            heatManCheckBox.Size = new System.Drawing.Size(196, 19);
            heatManCheckBox.TabIndex = 11;
            heatManCheckBox.Text = "Never place Item 2 on Heat Man";
            heatManCheckBox.UseVisualStyleBackColor = true;
            // 
            // shuffleEquipmentCheckBox
            // 
            shuffleEquipmentCheckBox.AutoSize = true;
            shuffleEquipmentCheckBox.Location = new System.Drawing.Point(5, 100);
            shuffleEquipmentCheckBox.Name = "shuffleEquipmentCheckBox";
            shuffleEquipmentCheckBox.Size = new System.Drawing.Size(218, 19);
            shuffleEquipmentCheckBox.TabIndex = 12;
            shuffleEquipmentCheckBox.Text = "Shuffle Weapons and Items together";
            shuffleEquipmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // weaknessComboBox
            // 
            weaknessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            weaknessComboBox.FormattingEnabled = true;
            weaknessComboBox.Items.AddRange(new object[] { "None", "Boss Sets", "Per Boss", "Random Balanced", "Random Random" });
            weaknessComboBox.Location = new System.Drawing.Point(6, 21);
            weaknessComboBox.Name = "weaknessComboBox";
            weaknessComboBox.Size = new System.Drawing.Size(380, 23);
            weaknessComboBox.TabIndex = 13;
            weaknessComboBox.SelectedIndexChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // robotsOnlyCheckBox
            // 
            robotsOnlyCheckBox.AutoSize = true;
            robotsOnlyCheckBox.Location = new System.Drawing.Point(26, 50);
            robotsOnlyCheckBox.Name = "robotsOnlyCheckBox";
            robotsOnlyCheckBox.Size = new System.Drawing.Size(191, 19);
            robotsOnlyCheckBox.TabIndex = 14;
            robotsOnlyCheckBox.Text = "Shuffle Castle Boss Weaknesses";
            robotsOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(MM1Tab);
            tabControl.Controls.Add(MM2Tab);
            tabControl.Location = new System.Drawing.Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(400, 365);
            tabControl.TabIndex = 15;
            // 
            // MM1Tab
            // 
            MM1Tab.Controls.Add(robotsOnlyMM1CheckBox);
            MM1Tab.Controls.Add(weaknessMM1ComboBox);
            MM1Tab.Controls.Add(weaknessMM1Label);
            MM1Tab.Location = new System.Drawing.Point(4, 24);
            MM1Tab.Name = "MM1Tab";
            MM1Tab.Padding = new System.Windows.Forms.Padding(3);
            MM1Tab.Size = new System.Drawing.Size(392, 337);
            MM1Tab.TabIndex = 0;
            MM1Tab.Text = "Mega Man 1";
            MM1Tab.UseVisualStyleBackColor = true;
            // 
            // robotsOnlyMM1CheckBox
            // 
            robotsOnlyMM1CheckBox.AutoSize = true;
            robotsOnlyMM1CheckBox.Location = new System.Drawing.Point(26, 50);
            robotsOnlyMM1CheckBox.Name = "robotsOnlyMM1CheckBox";
            robotsOnlyMM1CheckBox.Size = new System.Drawing.Size(191, 19);
            robotsOnlyMM1CheckBox.TabIndex = 2;
            robotsOnlyMM1CheckBox.Text = "Shuffle Castle Boss Weaknesses";
            robotsOnlyMM1CheckBox.UseVisualStyleBackColor = true;
            // 
            // weaknessMM1ComboBox
            // 
            weaknessMM1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            weaknessMM1ComboBox.FormattingEnabled = true;
            weaknessMM1ComboBox.Items.AddRange(new object[] { "None", "Boss Sets", "Per Boss", "Random Balanced", "Random Random" });
            weaknessMM1ComboBox.Location = new System.Drawing.Point(6, 21);
            weaknessMM1ComboBox.Name = "weaknessMM1ComboBox";
            weaknessMM1ComboBox.Size = new System.Drawing.Size(380, 23);
            weaknessMM1ComboBox.TabIndex = 1;
            weaknessMM1ComboBox.SelectedIndexChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // weaknessMM1Label
            // 
            weaknessMM1Label.AutoSize = true;
            weaknessMM1Label.Location = new System.Drawing.Point(6, 3);
            weaknessMM1Label.Name = "weaknessMM1Label";
            weaknessMM1Label.Size = new System.Drawing.Size(99, 15);
            weaknessMM1Label.TabIndex = 0;
            weaknessMM1Label.Text = "Weakness Shuffle";
            // 
            // MM2Tab
            // 
            MM2Tab.AutoScroll = true;
            MM2Tab.Controls.Add(damage2Label);
            MM2Tab.Controls.Add(bossCount2Label);
            MM2Tab.Controls.Add(damageMaxNumericUpDown);
            MM2Tab.Controls.Add(damageMinNumericUpDown);
            MM2Tab.Controls.Add(damageLabel);
            MM2Tab.Controls.Add(bossCountLabel);
            MM2Tab.Controls.Add(bossCountMaxNumericUpDown);
            MM2Tab.Controls.Add(bossCountMinNumericUpDown);
            MM2Tab.Controls.Add(timeStopperComboBox);
            MM2Tab.Controls.Add(timeStopperLabel);
            MM2Tab.Controls.Add(bossComboBox);
            MM2Tab.Controls.Add(bossLabel);
            MM2Tab.Controls.Add(weaknessLabel);
            MM2Tab.Controls.Add(robotsOnlyCheckBox);
            MM2Tab.Controls.Add(heatManCheckBox);
            MM2Tab.Controls.Add(shuffleEquipmentCheckBox);
            MM2Tab.Controls.Add(nerfBusterCheckBox);
            MM2Tab.Controls.Add(shuffleLevelsCheckBox);
            MM2Tab.Controls.Add(weaknessComboBox);
            MM2Tab.Location = new System.Drawing.Point(4, 24);
            MM2Tab.Name = "MM2Tab";
            MM2Tab.Padding = new System.Windows.Forms.Padding(3);
            MM2Tab.Size = new System.Drawing.Size(392, 337);
            MM2Tab.TabIndex = 1;
            MM2Tab.Text = "Mega Man 2";
            MM2Tab.UseVisualStyleBackColor = true;
            // 
            // damage2Label
            // 
            damage2Label.AutoSize = true;
            damage2Label.Location = new System.Drawing.Point(151, 294);
            damage2Label.Name = "damage2Label";
            damage2Label.Size = new System.Drawing.Size(18, 15);
            damage2Label.TabIndex = 26;
            damage2Label.Text = "to";
            // 
            // bossCount2Label
            // 
            bossCount2Label.AutoSize = true;
            bossCount2Label.Location = new System.Drawing.Point(151, 265);
            bossCount2Label.Name = "bossCount2Label";
            bossCount2Label.Size = new System.Drawing.Size(18, 15);
            bossCount2Label.TabIndex = 25;
            bossCount2Label.Text = "to";
            // 
            // damageMaxNumericUpDown
            // 
            damageMaxNumericUpDown.Location = new System.Drawing.Point(175, 292);
            damageMaxNumericUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            damageMaxNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            damageMaxNumericUpDown.Name = "damageMaxNumericUpDown";
            damageMaxNumericUpDown.Size = new System.Drawing.Size(40, 23);
            damageMaxNumericUpDown.TabIndex = 24;
            damageMaxNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            damageMaxNumericUpDown.ValueChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // damageMinNumericUpDown
            // 
            damageMinNumericUpDown.Location = new System.Drawing.Point(105, 292);
            damageMinNumericUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            damageMinNumericUpDown.Name = "damageMinNumericUpDown";
            damageMinNumericUpDown.Size = new System.Drawing.Size(40, 23);
            damageMinNumericUpDown.TabIndex = 23;
            damageMinNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            damageMinNumericUpDown.ValueChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // damageLabel
            // 
            damageLabel.AutoSize = true;
            damageLabel.Location = new System.Drawing.Point(15, 294);
            damageLabel.Name = "damageLabel";
            damageLabel.Size = new System.Drawing.Size(84, 15);
            damageLabel.TabIndex = 22;
            damageLabel.Text = "Damage Dealt:";
            // 
            // bossCountLabel
            // 
            bossCountLabel.AutoSize = true;
            bossCountLabel.Location = new System.Drawing.Point(6, 265);
            bossCountLabel.Name = "bossCountLabel";
            bossCountLabel.Size = new System.Drawing.Size(93, 15);
            bossCountLabel.TabIndex = 21;
            bossCountLabel.Text = "Bosses Affected:";
            // 
            // bossCountMaxNumericUpDown
            // 
            bossCountMaxNumericUpDown.Location = new System.Drawing.Point(175, 263);
            bossCountMaxNumericUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            bossCountMaxNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            bossCountMaxNumericUpDown.Name = "bossCountMaxNumericUpDown";
            bossCountMaxNumericUpDown.Size = new System.Drawing.Size(40, 23);
            bossCountMaxNumericUpDown.TabIndex = 20;
            bossCountMaxNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            bossCountMaxNumericUpDown.ValueChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // bossCountMinNumericUpDown
            // 
            bossCountMinNumericUpDown.Location = new System.Drawing.Point(105, 263);
            bossCountMinNumericUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            bossCountMinNumericUpDown.Name = "bossCountMinNumericUpDown";
            bossCountMinNumericUpDown.Size = new System.Drawing.Size(40, 23);
            bossCountMinNumericUpDown.TabIndex = 19;
            bossCountMinNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            bossCountMinNumericUpDown.ValueChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // timeStopperComboBox
            // 
            timeStopperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            timeStopperComboBox.FormattingEnabled = true;
            timeStopperComboBox.Items.AddRange(new object[] { "Vanilla", "Robot Masters", "All Bosses" });
            timeStopperComboBox.Location = new System.Drawing.Point(6, 234);
            timeStopperComboBox.Name = "timeStopperComboBox";
            timeStopperComboBox.Size = new System.Drawing.Size(380, 23);
            timeStopperComboBox.TabIndex = 18;
            timeStopperComboBox.SelectedIndexChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // timeStopperLabel
            // 
            timeStopperLabel.AutoSize = true;
            timeStopperLabel.Location = new System.Drawing.Point(3, 216);
            timeStopperLabel.Name = "timeStopperLabel";
            timeStopperLabel.Size = new System.Drawing.Size(117, 15);
            timeStopperLabel.TabIndex = 17;
            timeStopperLabel.Text = "Time Stopper Shuffle";
            // 
            // bossComboBox
            // 
            bossComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bossComboBox.FormattingEnabled = true;
            bossComboBox.Items.AddRange(new object[] { "None", "Shuffle", "Random", "Single Random" });
            bossComboBox.Location = new System.Drawing.Point(6, 190);
            bossComboBox.Name = "bossComboBox";
            bossComboBox.Size = new System.Drawing.Size(380, 23);
            bossComboBox.TabIndex = 16;
            // 
            // bossLabel
            // 
            bossLabel.AutoSize = true;
            bossLabel.Location = new System.Drawing.Point(6, 172);
            bossLabel.Name = "bossLabel";
            bossLabel.Size = new System.Drawing.Size(118, 15);
            bossLabel.TabIndex = 15;
            bossLabel.Text = "Robot Master Shuffle";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(424, 475);
            Controls.Add(tabControl);
            Controls.Add(generateButton);
            Controls.Add(outputLabel);
            Controls.Add(seedLabel);
            Controls.Add(seedTextBox);
            Controls.Add(outputButton);
            Controls.Add(outputTextBox);
            Name = "MainWindow";
            Text = "Mega Man Randomizer";
            tabControl.ResumeLayout(false);
            MM1Tab.ResumeLayout(false);
            MM1Tab.PerformLayout();
            MM2Tab.ResumeLayout(false);
            MM2Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)damageMaxNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)damageMinNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)bossCountMaxNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)bossCountMinNumericUpDown).EndInit();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage MM1Tab;
        private System.Windows.Forms.TabPage MM2Tab;
        private System.Windows.Forms.Label bossLabel;
        private System.Windows.Forms.ComboBox bossComboBox;
        private System.Windows.Forms.CheckBox robotsOnlyMM1CheckBox;
        private System.Windows.Forms.ComboBox weaknessMM1ComboBox;
        private System.Windows.Forms.Label weaknessMM1Label;
        private System.Windows.Forms.NumericUpDown damageMaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown damageMinNumericUpDown;
        private System.Windows.Forms.Label damageLabel;
        private System.Windows.Forms.Label bossCountLabel;
        private System.Windows.Forms.NumericUpDown bossCountMaxNumericUpDown;
        private System.Windows.Forms.NumericUpDown bossCountMinNumericUpDown;
        private System.Windows.Forms.ComboBox timeStopperComboBox;
        private System.Windows.Forms.Label timeStopperLabel;
        private System.Windows.Forms.Label damage2Label;
        private System.Windows.Forms.Label bossCount2Label;
    }
}