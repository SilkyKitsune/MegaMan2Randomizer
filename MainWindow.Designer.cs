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
            romPathTextBox = new System.Windows.Forms.TextBox();
            romPathLabel = new System.Windows.Forms.Label();
            romPathButton = new System.Windows.Forms.Button();
            outputButton = new System.Windows.Forms.Button();
            outputLabel = new System.Windows.Forms.Label();
            outputTextBox = new System.Windows.Forms.TextBox();
            seedLabel = new System.Windows.Forms.Label();
            seedTextBox = new System.Windows.Forms.TextBox();
            generateButton = new System.Windows.Forms.Button();
            ipsCheckBox = new System.Windows.Forms.CheckBox();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            shuffleLevelsCheckBox = new System.Windows.Forms.CheckBox();
            heatManCheckBox = new System.Windows.Forms.CheckBox();
            shuffleEquipmentCheckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // romPathTextBox
            // 
            romPathTextBox.Enabled = false;
            romPathTextBox.Location = new System.Drawing.Point(12, 27);
            romPathTextBox.Name = "romPathTextBox";
            romPathTextBox.Size = new System.Drawing.Size(267, 23);
            romPathTextBox.TabIndex = 0;
            // 
            // romPathLabel
            // 
            romPathLabel.AutoSize = true;
            romPathLabel.Location = new System.Drawing.Point(12, 9);
            romPathLabel.Name = "romPathLabel";
            romPathLabel.Size = new System.Drawing.Size(223, 15);
            romPathLabel.TabIndex = 1;
            romPathLabel.Text = "Mega Man 2 Path (Optional if Export IPS)";
            // 
            // romPathButton
            // 
            romPathButton.Enabled = false;
            romPathButton.Location = new System.Drawing.Point(285, 27);
            romPathButton.Name = "romPathButton";
            romPathButton.Size = new System.Drawing.Size(25, 23);
            romPathButton.TabIndex = 2;
            romPathButton.Text = "...";
            romPathButton.UseVisualStyleBackColor = true;
            romPathButton.Click += romPathButton_Click;
            // 
            // outputButton
            // 
            outputButton.Location = new System.Drawing.Point(285, 71);
            outputButton.Name = "outputButton";
            outputButton.Size = new System.Drawing.Size(25, 23);
            outputButton.TabIndex = 5;
            outputButton.Text = "...";
            outputButton.UseVisualStyleBackColor = true;
            outputButton.Click += outputButton_Click;
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new System.Drawing.Point(12, 53);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new System.Drawing.Size(81, 15);
            outputLabel.TabIndex = 4;
            outputLabel.Text = "Output Folder";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new System.Drawing.Point(12, 71);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new System.Drawing.Size(267, 23);
            outputTextBox.TabIndex = 3;
            // 
            // seedLabel
            // 
            seedLabel.AutoSize = true;
            seedLabel.Location = new System.Drawing.Point(12, 97);
            seedLabel.Name = "seedLabel";
            seedLabel.Size = new System.Drawing.Size(89, 15);
            seedLabel.TabIndex = 7;
            seedLabel.Text = "Seed (Optional)";
            // 
            // seedTextBox
            // 
            seedTextBox.Location = new System.Drawing.Point(12, 115);
            seedTextBox.Name = "seedTextBox";
            seedTextBox.Size = new System.Drawing.Size(298, 23);
            seedTextBox.TabIndex = 6;
            // 
            // generateButton
            // 
            generateButton.Location = new System.Drawing.Point(235, 191);
            generateButton.Name = "generateButton";
            generateButton.Size = new System.Drawing.Size(75, 23);
            generateButton.TabIndex = 8;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // ipsCheckBox
            // 
            ipsCheckBox.AutoSize = true;
            ipsCheckBox.Checked = true;
            ipsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            ipsCheckBox.Enabled = false;
            ipsCheckBox.Location = new System.Drawing.Point(150, 194);
            ipsCheckBox.Name = "ipsCheckBox";
            ipsCheckBox.Size = new System.Drawing.Size(79, 19);
            ipsCheckBox.TabIndex = 9;
            ipsCheckBox.Text = "Export IPS";
            ipsCheckBox.UseVisualStyleBackColor = true;
            ipsCheckBox.CheckedChanged += ipsCheckBox_CheckedChanged;
            // 
            // shuffleLevelsCheckBox
            // 
            shuffleLevelsCheckBox.AutoSize = true;
            shuffleLevelsCheckBox.Location = new System.Drawing.Point(12, 194);
            shuffleLevelsCheckBox.Name = "shuffleLevelsCheckBox";
            shuffleLevelsCheckBox.Size = new System.Drawing.Size(98, 19);
            shuffleLevelsCheckBox.TabIndex = 10;
            shuffleLevelsCheckBox.Text = "Shuffle Levels";
            shuffleLevelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // heatManCheckBox
            // 
            heatManCheckBox.AutoSize = true;
            heatManCheckBox.Location = new System.Drawing.Point(12, 144);
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
            shuffleEquipmentCheckBox.Location = new System.Drawing.Point(12, 169);
            shuffleEquipmentCheckBox.Name = "shuffleEquipmentCheckBox";
            shuffleEquipmentCheckBox.Size = new System.Drawing.Size(218, 19);
            shuffleEquipmentCheckBox.TabIndex = 12;
            shuffleEquipmentCheckBox.Text = "Shuffle Weapons and Items together";
            shuffleEquipmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(324, 226);
            Controls.Add(shuffleEquipmentCheckBox);
            Controls.Add(heatManCheckBox);
            Controls.Add(shuffleLevelsCheckBox);
            Controls.Add(ipsCheckBox);
            Controls.Add(generateButton);
            Controls.Add(seedLabel);
            Controls.Add(seedTextBox);
            Controls.Add(outputButton);
            Controls.Add(outputLabel);
            Controls.Add(outputTextBox);
            Controls.Add(romPathButton);
            Controls.Add(romPathLabel);
            Controls.Add(romPathTextBox);
            Name = "MainWindow";
            Text = "Mega Man 2 Randomizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox romPathTextBox;
        private System.Windows.Forms.Label romPathLabel;
        private System.Windows.Forms.Button romPathButton;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.CheckBox ipsCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox shuffleLevelsCheckBox;
        private System.Windows.Forms.CheckBox heatManCheckBox;
        private System.Windows.Forms.CheckBox shuffleEquipmentCheckBox;
    }
}