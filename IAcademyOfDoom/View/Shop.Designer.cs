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
            this.label1 = new System.Windows.Forms.Label();
            this.buyButton = new System.Windows.Forms.Button();
            this.moneyContentLabel = new System.Windows.Forms.Label();
            this.moneyAmountLabel = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shop";
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(248, 279);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(117, 23);
            this.buyButton.TabIndex = 2;
            this.buyButton.Text = "buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // moneyContentLabel
            // 
            this.moneyContentLabel.AutoSize = true;
            this.moneyContentLabel.Location = new System.Drawing.Point(245, 251);
            this.moneyContentLabel.Name = "moneyContentLabel";
            this.moneyContentLabel.Size = new System.Drawing.Size(82, 13);
            this.moneyContentLabel.TabIndex = 3;
            this.moneyContentLabel.Text = "Money aviable: ";
            // 
            // moneyAmountLabel
            // 
            this.moneyAmountLabel.AutoSize = true;
            this.moneyAmountLabel.Location = new System.Drawing.Point(334, 251);
            this.moneyAmountLabel.Name = "moneyAmountLabel";
            this.moneyAmountLabel.Size = new System.Drawing.Size(0, 13);
            this.moneyAmountLabel.TabIndex = 4;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closeButton.Location = new System.Drawing.Point(431, 279);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "close";
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
            this.Controls.Add(this.moneyAmountLabel);
            this.Controls.Add(this.moneyContentLabel);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buyablesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Shop";
            this.Text = "Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox buyablesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Label moneyContentLabel;
        private System.Windows.Forms.Label moneyAmountLabel;
        private System.Windows.Forms.Button closeButton;
    }
}