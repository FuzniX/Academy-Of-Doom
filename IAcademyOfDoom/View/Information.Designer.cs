namespace IAcademyOfDoom.View
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            this.actionImage = new System.Windows.Forms.PictureBox();
            this.placeableImage = new System.Windows.Forms.PictureBox();
            this.placeableLabel = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.closeButtonToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rightClickInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.actionImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.placeableImage)).BeginInit();
            this.SuspendLayout();
            // 
            // actionImage
            // 
            this.actionImage.BackColor = System.Drawing.Color.Transparent;
            this.actionImage.BackgroundImage = global::IAcademyOfDoom.Properties.Resources.action;
            this.actionImage.Location = new System.Drawing.Point(12, 114);
            this.actionImage.Name = "actionImage";
            this.actionImage.Size = new System.Drawing.Size(96, 96);
            this.actionImage.TabIndex = 1;
            this.actionImage.TabStop = false;
            // 
            // placeableImage
            // 
            this.placeableImage.BackColor = System.Drawing.Color.Transparent;
            this.placeableImage.BackgroundImage = global::IAcademyOfDoom.Properties.Resources.placeable;
            this.placeableImage.Location = new System.Drawing.Point(12, 12);
            this.placeableImage.Name = "placeableImage";
            this.placeableImage.Size = new System.Drawing.Size(96, 96);
            this.placeableImage.TabIndex = 0;
            this.placeableImage.TabStop = false;
            // 
            // placeableLabel
            // 
            this.placeableLabel.AutoSize = true;
            this.placeableLabel.BackColor = System.Drawing.Color.Transparent;
            this.placeableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeableLabel.ForeColor = System.Drawing.Color.White;
            this.placeableLabel.Location = new System.Drawing.Point(114, 49);
            this.placeableLabel.Name = "placeableLabel";
            this.placeableLabel.Size = new System.Drawing.Size(116, 25);
            this.placeableLabel.TabIndex = 2;
            this.placeableLabel.Text = "Placeable";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.BackColor = System.Drawing.Color.Transparent;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLabel.ForeColor = System.Drawing.Color.White;
            this.actionLabel.Location = new System.Drawing.Point(114, 143);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(78, 25);
            this.actionLabel.TabIndex = 3;
            this.actionLabel.Text = "Action";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(425, 187);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 50);
            this.closeButton.TabIndex = 6;
            this.closeButtonToolTip.SetToolTip(this.closeButton, "Close");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // rightClickInformation
            // 
            this.rightClickInformation.AutoSize = true;
            this.rightClickInformation.BackColor = System.Drawing.Color.Transparent;
            this.rightClickInformation.ForeColor = System.Drawing.Color.White;
            this.rightClickInformation.Location = new System.Drawing.Point(9, 223);
            this.rightClickInformation.Name = "rightClickInformation";
            this.rightClickInformation.Size = new System.Drawing.Size(268, 13);
            this.rightClickInformation.TabIndex = 7;
            this.rightClickInformation.Text = "Right Click to display information on botlings and rooms!";
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IAcademyOfDoom.Properties.Resources.information_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(487, 247);
            this.Controls.Add(this.rightClickInformation);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.placeableLabel);
            this.Controls.Add(this.actionImage);
            this.Controls.Add(this.placeableImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Information";
            this.Text = "Information";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Information_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.actionImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.placeableImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox placeableImage;
        private System.Windows.Forms.PictureBox actionImage;
        private System.Windows.Forms.Label placeableLabel;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ToolTip closeButtonToolTip;
        private System.Windows.Forms.Label rightClickInformation;
    }
}