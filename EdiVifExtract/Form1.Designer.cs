namespace EdiVifExtract
{
    partial class FormExtract
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
            this.buttonGenerer = new System.Windows.Forms.Button();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.comboBoxDepot = new System.Windows.Forms.ComboBox();
            this.buttonOuvrirDest = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerer
            // 
            this.buttonGenerer.Location = new System.Drawing.Point(20, 142);
            this.buttonGenerer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonGenerer.Name = "buttonGenerer";
            this.buttonGenerer.Size = new System.Drawing.Size(86, 23);
            this.buttonGenerer.TabIndex = 0;
            this.buttonGenerer.Text = "genererFichiers";
            this.buttonGenerer.UseVisualStyleBackColor = true;
            this.buttonGenerer.Click += new System.EventHandler(this.buttonGenerer_Click);
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(20, 35);
            this.comboBoxSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(270, 21);
            this.comboBoxSource.TabIndex = 1;
            // 
            // comboBoxDepot
            // 
            this.comboBoxDepot.FormattingEnabled = true;
            this.comboBoxDepot.Location = new System.Drawing.Point(20, 86);
            this.comboBoxDepot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxDepot.Name = "comboBoxDepot";
            this.comboBoxDepot.Size = new System.Drawing.Size(270, 21);
            this.comboBoxDepot.TabIndex = 3;
            this.comboBoxDepot.SelectedValueChanged += new System.EventHandler(this.comboBoxDepot_SelectedValueChanged);
            this.comboBoxDepot.TextChanged += new System.EventHandler(this.comboBoxDepot_TextChanged);
            this.comboBoxDepot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxDepot_KeyDown);
            // 
            // buttonOuvrirDest
            // 
            this.buttonOuvrirDest.Location = new System.Drawing.Point(186, 140);
            this.buttonOuvrirDest.Name = "buttonOuvrirDest";
            this.buttonOuvrirDest.Size = new System.Drawing.Size(104, 25);
            this.buttonOuvrirDest.TabIndex = 5;
            this.buttonOuvrirDest.Text = "OuvrirDestination";
            this.buttonOuvrirDest.UseVisualStyleBackColor = true;
            this.buttonOuvrirDest.Click += new System.EventHandler(this.buttonOuvrirDest_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(325, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 190);
            this.Controls.Add(this.buttonOuvrirDest);
            this.Controls.Add(this.comboBoxDepot);
            this.Controls.Add(this.comboBoxSource);
            this.Controls.Add(this.buttonGenerer);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormExtract";
            this.Text = "ASCGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExtract_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerer;
        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.ComboBox comboBoxDepot;
        private System.Windows.Forms.Button buttonOuvrirDest;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

