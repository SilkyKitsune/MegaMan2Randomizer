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
            label1 = new System.Windows.Forms.Label();
            MM2Tab = new System.Windows.Forms.TabPage();
            tabControl.SuspendLayout();
            MM1Tab.SuspendLayout();
            MM2Tab.SuspendLayout();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new System.Drawing.Point(12, 265);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new System.Drawing.Size(81, 15);
            outputLabel.TabIndex = 1;
            outputLabel.Text = "Output Folder";
            // 
            // outputButton
            // 
            outputButton.Location = new System.Drawing.Point(383, 283);
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
            seedLabel.Location = new System.Drawing.Point(12, 309);
            seedLabel.Name = "seedLabel";
            seedLabel.Size = new System.Drawing.Size(89, 15);
            seedLabel.TabIndex = 4;
            seedLabel.Text = "Seed (Optional)";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new System.Drawing.Point(12, 283);
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
            seedTextBox.Location = new System.Drawing.Point(12, 327);
            seedTextBox.Name = "seedTextBox";
            seedTextBox.Size = new System.Drawing.Size(315, 23);
            seedTextBox.TabIndex = 6;
            // 
            // generateButton
            // 
            generateButton.Location = new System.Drawing.Point(333, 327);
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
            weaknessComboBox.Items.AddRange(new object[] { "None", "Boss Sets", "Per Boss", "Random (Coming soon)" });
            weaknessComboBox.Location = new System.Drawing.Point(6, 21);
            weaknessComboBox.Name = "weaknessComboBox";
            weaknessComboBox.Size = new System.Drawing.Size(360, 23);
            weaknessComboBox.TabIndex = 13;
            weaknessComboBox.SelectedIndexChanged += weaknessComboBox_SelectedIndexChanged;
            // 
            // robotsOnlyCheckBox
            // 
            robotsOnlyCheckBox.AutoSize = true;
            robotsOnlyCheckBox.Location = new System.Drawing.Point(6, 50);
            robotsOnlyCheckBox.Name = "robotsOnlyCheckBox";
            robotsOnlyCheckBox.Size = new System.Drawing.Size(257, 19);
            robotsOnlyCheckBox.TabIndex = 14;
            robotsOnlyCheckBox.Text = "Shuffle Castle Boss Weaknesses with Robots";
            robotsOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(MM1Tab);
            tabControl.Controls.Add(MM2Tab);
            tabControl.Location = new System.Drawing.Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(400, 250);
            tabControl.TabIndex = 15;
            // 
            // MM1Tab
            // 
            MM1Tab.Controls.Add(label1);
            MM1Tab.Location = new System.Drawing.Point(4, 24);
            MM1Tab.Name = "MM1Tab";
            MM1Tab.Padding = new System.Windows.Forms.Padding(3);
            MM1Tab.Size = new System.Drawing.Size(392, 222);
            MM1Tab.TabIndex = 0;
            MM1Tab.Text = "Mega Man 1";
            MM1Tab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Coming soon!";
            // 
            // MM2Tab
            // 
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
            MM2Tab.Size = new System.Drawing.Size(392, 222);
            MM2Tab.TabIndex = 1;
            MM2Tab.Text = "Mega Man 2";
            MM2Tab.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(424, 366);
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
        private System.Windows.Forms.Label label1;
    }
}