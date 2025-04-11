namespace IAcademyOfDoom.View
{
    partial class Shop
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
            this.buyablesList = new System.Windows.Forms.ListBox();
            this.ShopLabel = new System.Windows.Forms.Label();
            this.buyButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buyablesList
            // 
            this.buyablesList.FormattingEnabled = true;
            this.buyablesList.Location = new System.Drawing.Point(12, 103);
            this.buyablesList.Name = "buyablesList";
            this.buyablesList.Size = new System.Drawing.Size(180, 199);
            this.buyablesList.TabIndex = 0;
            // 
            // ShopLabel
            // 
            this.ShopLabel.AutoSize = true;
            this.ShopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopLabel.Location = new System.Drawing.Point(224, 28);
            this.ShopLabel.Name = "ShopLabel";
            this.ShopLabel.Size = new System.Drawing.Size(66, 25);
            this.ShopLabel.TabIndex = 1;
            this.ShopLabel.Text = "Shop";
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(248, 279);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(117, 23);
            this.buyButton.TabIndex = 2;
            this.buyButton.Text = "Buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(431, 279);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.Paint += new System.Windows.Forms.PaintEventHandler(this.closeButton_Paint);
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(518, 332);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.ShopLabel);
            this.Controls.Add(this.buyablesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Shop";
            this.Text = "Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox buyablesList;
        private System.Windows.Forms.Label ShopLabel;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button closeButton;
    }
}