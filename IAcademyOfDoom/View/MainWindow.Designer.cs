using System.Windows.Forms;

namespace IAcademyOfDoom.View
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.botnumTextLabel = new System.Windows.Forms.Label();
            this.numberOfBotlingsContentLabel = new System.Windows.Forms.Label();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.MoneyContentLabel = new System.Windows.Forms.Label();
            this.MoneyAmountLabel = new System.Windows.Forms.Label();
            this.shopToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.shopButton = new System.Windows.Forms.Button();
            this.quitToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.quitButton = new System.Windows.Forms.Button();
            this.resultToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resultsBtn = new System.Windows.Forms.Button();
            this.endPrepToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.endPrepButton = new System.Windows.Forms.Button();
            this.nextToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nextInAssaultButton = new System.Windows.Forms.Button();
            this.informationBtn = new System.Windows.Forms.Button();
            this.informationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.InformationGiver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botnumTextLabel
            // 
            this.botnumTextLabel.AutoSize = true;
            this.botnumTextLabel.BackColor = System.Drawing.Color.Transparent;
            this.botnumTextLabel.ForeColor = System.Drawing.Color.White;
            this.botnumTextLabel.Location = new System.Drawing.Point(12, 12);
            this.botnumTextLabel.Name = "botnumTextLabel";
            this.botnumTextLabel.Size = new System.Drawing.Size(47, 13);
            this.botnumTextLabel.TabIndex = 3;
            this.botnumTextLabel.Text = "Botlings:";
            // 
            // numberOfBotlingsContentLabel
            // 
            this.numberOfBotlingsContentLabel.AutoSize = true;
            this.numberOfBotlingsContentLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberOfBotlingsContentLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfBotlingsContentLabel.Location = new System.Drawing.Point(63, 12);
            this.numberOfBotlingsContentLabel.Name = "numberOfBotlingsContentLabel";
            this.numberOfBotlingsContentLabel.Size = new System.Drawing.Size(16, 13);
            this.numberOfBotlingsContentLabel.TabIndex = 4;
            this.numberOfBotlingsContentLabel.Text = "   ";
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerNameLabel.ForeColor = System.Drawing.Color.White;
            this.playerNameLabel.Location = new System.Drawing.Point(12, 38);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(39, 13);
            this.playerNameLabel.TabIndex = 6;
            this.playerNameLabel.Text = "Player:";
            // 
            // MoneyContentLabel
            // 
            this.MoneyContentLabel.AutoSize = true;
            this.MoneyContentLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoneyContentLabel.ForeColor = System.Drawing.Color.White;
            this.MoneyContentLabel.Location = new System.Drawing.Point(12, 25);
            this.MoneyContentLabel.Name = "MoneyContentLabel";
            this.MoneyContentLabel.Size = new System.Drawing.Size(45, 13);
            this.MoneyContentLabel.TabIndex = 10;
            this.MoneyContentLabel.Text = "Money: ";
            // 
            // MoneyAmountLabel
            // 
            this.MoneyAmountLabel.AutoSize = true;
            this.MoneyAmountLabel.BackColor = System.Drawing.Color.Transparent;
            this.MoneyAmountLabel.ForeColor = System.Drawing.Color.White;
            this.MoneyAmountLabel.Location = new System.Drawing.Point(63, 25);
            this.MoneyAmountLabel.Name = "MoneyAmountLabel";
            this.MoneyAmountLabel.Size = new System.Drawing.Size(0, 13);
            this.MoneyAmountLabel.TabIndex = 11;
            // 
            // shopButton
            // 
            this.shopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shopButton.BackColor = System.Drawing.Color.Transparent;
            this.shopButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shopButton.BackgroundImage")));
            this.shopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shopButton.Location = new System.Drawing.Point(986, 12);
            this.shopButton.Name = "shopButton";
            this.shopButton.Size = new System.Drawing.Size(50, 50);
            this.shopButton.TabIndex = 9;
            this.shopToolTip.SetToolTip(this.shopButton, "Shop");
            this.shopButton.UseVisualStyleBackColor = false;
            this.shopButton.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitButton.Location = new System.Drawing.Point(1098, 12);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(50, 50);
            this.quitButton.TabIndex = 5;
            this.quitToolTip.SetToolTip(this.quitButton, "Quit");
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // resultsBtn
            // 
            this.resultsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resultsBtn.BackgroundImage")));
            this.resultsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resultsBtn.Location = new System.Drawing.Point(1042, 12);
            this.resultsBtn.Name = "resultsBtn";
            this.resultsBtn.Size = new System.Drawing.Size(50, 50);
            this.resultsBtn.TabIndex = 7;
            this.resultToolTip.SetToolTip(this.resultsBtn, "Result");
            this.resultsBtn.UseVisualStyleBackColor = true;
            this.resultsBtn.Click += new System.EventHandler(this.ResultsBtn_Click);
            // 
            // endPrepButton
            // 
            this.endPrepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endPrepButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("endPrepButton.BackgroundImage")));
            this.endPrepButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.endPrepButton.Location = new System.Drawing.Point(929, 12);
            this.endPrepButton.Name = "endPrepButton";
            this.endPrepButton.Size = new System.Drawing.Size(50, 50);
            this.endPrepButton.TabIndex = 1;
            this.endPrepToolTip.SetToolTip(this.endPrepButton, "End Preparations");
            this.endPrepButton.UseVisualStyleBackColor = true;
            this.endPrepButton.Click += new System.EventHandler(this.EndPrepButton_Click);
            // 
            // nextInAssaultButton
            // 
            this.nextInAssaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextInAssaultButton.BackColor = System.Drawing.SystemColors.Control;
            this.nextInAssaultButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextInAssaultButton.BackgroundImage")));
            this.nextInAssaultButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextInAssaultButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.nextInAssaultButton.Location = new System.Drawing.Point(929, 12);
            this.nextInAssaultButton.Name = "nextInAssaultButton";
            this.nextInAssaultButton.Size = new System.Drawing.Size(50, 50);
            this.nextInAssaultButton.TabIndex = 2;
            this.nextToolTip.SetToolTip(this.nextInAssaultButton, "Assault: Next");
            this.nextInAssaultButton.UseVisualStyleBackColor = false;
            this.nextInAssaultButton.Visible = false;
            this.nextInAssaultButton.Click += new System.EventHandler(this.NextInAssaultButton_Click);
            // 
            // informationBtn
            // 
            this.informationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.informationBtn.BackColor = System.Drawing.SystemColors.Control;
            this.informationBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("informationBtn.BackgroundImage")));
            this.informationBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.informationBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.informationBtn.Location = new System.Drawing.Point(873, 12);
            this.informationBtn.Name = "informationBtn";
            this.informationBtn.Size = new System.Drawing.Size(50, 50);
            this.informationBtn.TabIndex = 12;
            this.informationToolTip.SetToolTip(this.informationBtn, "Information");
            this.informationBtn.UseVisualStyleBackColor = false;
            this.informationBtn.Click += new System.EventHandler(this.InformationBtn_Click);
            // 
            // InformationGiver
            // 
            this.InformationGiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationGiver.AutoSize = true;
            this.InformationGiver.BackColor = System.Drawing.Color.Transparent;
            this.InformationGiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformationGiver.ForeColor = System.Drawing.Color.White;
            this.InformationGiver.Location = new System.Drawing.Point(310, 29);
            this.InformationGiver.Name = "InformationGiver";
            this.InformationGiver.Size = new System.Drawing.Size(47, 25);
            this.InformationGiver.TabIndex = 13;
            this.InformationGiver.Text = "     ";
            this.InformationGiver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IAcademyOfDoom.Properties.Resources.background_blurred;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1160, 687);
            this.Controls.Add(this.InformationGiver);
            this.Controls.Add(this.informationBtn);
            this.Controls.Add(this.MoneyAmountLabel);
            this.Controls.Add(this.MoneyContentLabel);
            this.Controls.Add(this.shopButton);
            this.Controls.Add(this.resultsBtn);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.numberOfBotlingsContentLabel);
            this.Controls.Add(this.botnumTextLabel);
            this.Controls.Add(this.nextInAssaultButton);
            this.Controls.Add(this.endPrepButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1176, 726);
            this.Name = "MainWindow";
            this.Text = "IAcademy of Doom";
            this.ClientSizeChanged += new System.EventHandler(this.MainWindow_ClientSizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button endPrepButton;
        private System.Windows.Forms.Button nextInAssaultButton;
        private System.Windows.Forms.Label botnumTextLabel;
        private System.Windows.Forms.Label numberOfBotlingsContentLabel;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Button resultsBtn;
        private System.Windows.Forms.Button shopButton;
        private System.Windows.Forms.Label MoneyContentLabel;
        private System.Windows.Forms.Label MoneyAmountLabel;
        private System.Windows.Forms.ToolTip shopToolTip;
        private System.Windows.Forms.ToolTip quitToolTip;
        private System.Windows.Forms.ToolTip resultToolTip;
        private System.Windows.Forms.ToolTip endPrepToolTip;
        private System.Windows.Forms.ToolTip nextToolTip;
        private Button informationBtn;
        private ToolTip informationToolTip;
        private Label InformationGiver;
    }
}

