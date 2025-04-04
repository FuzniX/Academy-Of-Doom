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
            this.resultLabel = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
            this.successCountLabel = new System.Windows.Forms.Label();
            this.failuresLabel = new System.Windows.Forms.Label();
            this.deathsLabel = new System.Windows.Forms.Label();
            this.failuresCountLabel = new System.Windows.Forms.Label();
            this.resultOkBtn = new System.Windows.Forms.Button();
            this.deathsCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(167, 9);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(113, 31);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "Results";
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successLabel.Location = new System.Drawing.Point(25, 68);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(68, 16);
            this.successLabel.TabIndex = 1;
            this.successLabel.Text = "success:";
            // 
            // successCountLabel
            // 
            this.successCountLabel.AutoSize = true;
            this.successCountLabel.Location = new System.Drawing.Point(99, 71);
            this.successCountLabel.Name = "successCountLabel";
            this.successCountLabel.Size = new System.Drawing.Size(0, 13);
            this.successCountLabel.TabIndex = 2;
            // 
            // failuresLabel
            // 
            this.failuresLabel.AutoSize = true;
            this.failuresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failuresLabel.Location = new System.Drawing.Point(25, 126);
            this.failuresLabel.Name = "failuresLabel";
            this.failuresLabel.Size = new System.Drawing.Size(62, 16);
            this.failuresLabel.TabIndex = 3;
            this.failuresLabel.Text = "failures:";
            // 
            // deathsLabel
            // 
            this.deathsLabel.AutoSize = true;
            this.deathsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathsLabel.Location = new System.Drawing.Point(25, 184);
            this.deathsLabel.Name = "deathsLabel";
            this.deathsLabel.Size = new System.Drawing.Size(58, 16);
            this.deathsLabel.TabIndex = 4;
            this.deathsLabel.Text = "deaths:";
            // 
            // failuresCountLabel
            // 
            this.failuresCountLabel.AutoSize = true;
            this.failuresCountLabel.Location = new System.Drawing.Point(93, 128);
            this.failuresCountLabel.Name = "failuresCountLabel";
            this.failuresCountLabel.Size = new System.Drawing.Size(0, 13);
            this.failuresCountLabel.TabIndex = 5;
            // 
            // resultOkBtn
            // 
            this.resultOkBtn.Location = new System.Drawing.Point(338, 203);
            this.resultOkBtn.Name = "resultOkBtn";
            this.resultOkBtn.Size = new System.Drawing.Size(75, 23);
            this.resultOkBtn.TabIndex = 7;
            this.resultOkBtn.Text = "OK";
            this.resultOkBtn.UseVisualStyleBackColor = true;
            this.resultOkBtn.Click += new System.EventHandler(this.resultOkBtn_Click);
            // 
            // deathsCountLabel
            // 
            this.deathsCountLabel.AutoSize = true;
            this.deathsCountLabel.Location = new System.Drawing.Point(89, 187);
            this.deathsCountLabel.Name = "deathsCountLabel";
            this.deathsCountLabel.Size = new System.Drawing.Size(0, 13);
            this.deathsCountLabel.TabIndex = 8;
            // 
            // ResultPhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 238);
            this.Controls.Add(this.deathsCountLabel);
            this.Controls.Add(this.resultOkBtn);
            this.Controls.Add(this.failuresCountLabel);
            this.Controls.Add(this.deathsLabel);
            this.Controls.Add(this.failuresLabel);
            this.Controls.Add(this.successCountLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.resultLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
    }
}