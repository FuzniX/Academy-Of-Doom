namespace IAcademyOfDoom.View
{
    partial class ResultPhase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultPhase));
            this.resultLabel = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
            this.successCountLabel = new System.Windows.Forms.Label();
            this.failuresLabel = new System.Windows.Forms.Label();
            this.deathsLabel = new System.Windows.Forms.Label();
            this.failuresCountLabel = new System.Windows.Forms.Label();
            this.deathsCountLabel = new System.Windows.Forms.Label();
            this.okToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resultOkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.BackColor = System.Drawing.Color.Transparent;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.Color.White;
            this.resultLabel.Location = new System.Drawing.Point(167, 9);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(113, 31);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "Results";
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.BackColor = System.Drawing.Color.Transparent;
            this.successLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successLabel.ForeColor = System.Drawing.Color.White;
            this.successLabel.Location = new System.Drawing.Point(12, 152);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(87, 16);
            this.successLabel.TabIndex = 1;
            this.successLabel.Text = "Successes:";
            // 
            // successCountLabel
            // 
            this.successCountLabel.AutoSize = true;
            this.successCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.successCountLabel.ForeColor = System.Drawing.Color.White;
            this.successCountLabel.Location = new System.Drawing.Point(105, 155);
            this.successCountLabel.Name = "successCountLabel";
            this.successCountLabel.Size = new System.Drawing.Size(0, 13);
            this.successCountLabel.TabIndex = 2;
            // 
            // failuresLabel
            // 
            this.failuresLabel.AutoSize = true;
            this.failuresLabel.BackColor = System.Drawing.Color.Transparent;
            this.failuresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failuresLabel.ForeColor = System.Drawing.Color.White;
            this.failuresLabel.Location = new System.Drawing.Point(12, 166);
            this.failuresLabel.Name = "failuresLabel";
            this.failuresLabel.Size = new System.Drawing.Size(67, 16);
            this.failuresLabel.TabIndex = 3;
            this.failuresLabel.Text = "Failures:";
            // 
            // deathsLabel
            // 
            this.deathsLabel.AutoSize = true;
            this.deathsLabel.BackColor = System.Drawing.Color.Transparent;
            this.deathsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathsLabel.ForeColor = System.Drawing.Color.White;
            this.deathsLabel.Location = new System.Drawing.Point(12, 182);
            this.deathsLabel.Name = "deathsLabel";
            this.deathsLabel.Size = new System.Drawing.Size(60, 16);
            this.deathsLabel.TabIndex = 4;
            this.deathsLabel.Text = "Deaths:";
            // 
            // failuresCountLabel
            // 
            this.failuresCountLabel.AutoSize = true;
            this.failuresCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.failuresCountLabel.ForeColor = System.Drawing.Color.White;
            this.failuresCountLabel.Location = new System.Drawing.Point(85, 168);
            this.failuresCountLabel.Name = "failuresCountLabel";
            this.failuresCountLabel.Size = new System.Drawing.Size(0, 13);
            this.failuresCountLabel.TabIndex = 5;
            // 
            // deathsCountLabel
            // 
            this.deathsCountLabel.AutoSize = true;
            this.deathsCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.deathsCountLabel.ForeColor = System.Drawing.Color.White;
            this.deathsCountLabel.Location = new System.Drawing.Point(78, 184);
            this.deathsCountLabel.Name = "deathsCountLabel";
            this.deathsCountLabel.Size = new System.Drawing.Size(0, 13);
            this.deathsCountLabel.TabIndex = 8;
            // 
            // resultOkBtn
            // 
            this.resultOkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resultOkBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resultOkBtn.BackgroundImage")));
            this.resultOkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resultOkBtn.Location = new System.Drawing.Point(374, 152);
            this.resultOkBtn.Name = "resultOkBtn";
            this.resultOkBtn.Size = new System.Drawing.Size(50, 50);
            this.resultOkBtn.TabIndex = 7;
            this.okToolTip.SetToolTip(this.resultOkBtn, "OK");
            this.resultOkBtn.UseVisualStyleBackColor = true;
            this.resultOkBtn.Click += new System.EventHandler(this.resultOkBtn_Click);
            // 
            // ResultPhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IAcademyOfDoom.Properties.Resources.result_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(436, 214);
            this.Controls.Add(this.deathsCountLabel);
            this.Controls.Add(this.resultOkBtn);
            this.Controls.Add(this.failuresCountLabel);
            this.Controls.Add(this.deathsLabel);
            this.Controls.Add(this.failuresLabel);
            this.Controls.Add(this.successCountLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.resultLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultPhase";
            this.Text = "Result";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ResultPhase_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label successCountLabel;
        private System.Windows.Forms.Label failuresLabel;
        private System.Windows.Forms.Label deathsLabel;
        private System.Windows.Forms.Label failuresCountLabel;
        private System.Windows.Forms.Button resultOkBtn;
        private System.Windows.Forms.Label deathsCountLabel;
        private System.Windows.Forms.ToolTip okToolTip;
    }
}