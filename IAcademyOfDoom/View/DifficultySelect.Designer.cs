namespace IAcademyOfDoom.View
{
    partial class DifficultySelect
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifficultySelect));
            this.nameLabel = new System.Windows.Forms.Label();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.difficultyListBox = new System.Windows.Forms.ListBox();
            this.okToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.ForeColor = System.Drawing.Color.Black;
            this.nameLabel.Location = new System.Drawing.Point(36, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(61, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Your name:";
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.BackColor = System.Drawing.Color.Transparent;
            this.difficultyLabel.ForeColor = System.Drawing.Color.Black;
            this.difficultyLabel.Location = new System.Drawing.Point(36, 58);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(95, 13);
            this.difficultyLabel.TabIndex = 1;
            this.difficultyLabel.Text = "Selected Difficulty:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(139, 27);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // difficultyListBox
            // 
            this.difficultyListBox.FormattingEnabled = true;
            this.difficultyListBox.Location = new System.Drawing.Point(139, 58);
            this.difficultyListBox.Name = "difficultyListBox";
            this.difficultyListBox.Size = new System.Drawing.Size(120, 95);
            this.difficultyListBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(398, 103);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(50, 50);
            this.okButton.TabIndex = 4;
            this.okToolTip.SetToolTip(this.okButton, "OK");
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // DifficultySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IAcademyOfDoom.Properties.Resources.background2_blurred;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(465, 167);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.difficultyListBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DifficultySelect";
            this.Text = "DifficultySelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ListBox difficultyListBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip okToolTip;
    }
}