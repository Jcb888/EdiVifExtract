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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExtract));
            this.buttonGenerer = new System.Windows.Forms.Button();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.comboBoxDepot = new System.Windows.Forms.ComboBox();
            this.buttonOuvrirDest = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.buttonSelectDepot = new System.Windows.Forms.Button();
            this.labelrepTravail = new System.Windows.Forms.Label();
            this.labelDepot = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxChangerDate = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelFormatDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerer
            // 
            this.buttonGenerer.Location = new System.Drawing.Point(19, 272);
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
            this.comboBoxSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxSource_KeyDown);
            // 
            // comboBoxDepot
            // 
            this.comboBoxDepot.FormattingEnabled = true;
            this.comboBoxDepot.Location = new System.Drawing.Point(20, 86);
            this.comboBoxDepot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxDepot.Name = "comboBoxDepot";
            this.comboBoxDepot.Size = new System.Drawing.Size(270, 21);
            this.comboBoxDepot.TabIndex = 3;
            this.comboBoxDepot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxDepot_KeyDown);
            // 
            // buttonOuvrirDest
            // 
            this.buttonOuvrirDest.Location = new System.Drawing.Point(172, 272);
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
            this.menuStrip1.Size = new System.Drawing.Size(338, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.aboutToolStripMenuItem.Text = "?";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // buttonSelectSource
            // 
            this.buttonSelectSource.Location = new System.Drawing.Point(296, 35);
            this.buttonSelectSource.Name = "buttonSelectSource";
            this.buttonSelectSource.Size = new System.Drawing.Size(30, 23);
            this.buttonSelectSource.TabIndex = 7;
            this.buttonSelectSource.Tag = resources.GetString("buttonSelectSource.Tag");
            this.buttonSelectSource.Text = "...";
            this.buttonSelectSource.UseVisualStyleBackColor = true;
            this.buttonSelectSource.Click += new System.EventHandler(this.buttonSelectSource_Click);
            // 
            // buttonSelectDepot
            // 
            this.buttonSelectDepot.Location = new System.Drawing.Point(296, 86);
            this.buttonSelectDepot.Name = "buttonSelectDepot";
            this.buttonSelectDepot.Size = new System.Drawing.Size(30, 23);
            this.buttonSelectDepot.TabIndex = 8;
            this.buttonSelectDepot.Tag = resources.GetString("buttonSelectDepot.Tag");
            this.buttonSelectDepot.Text = "...";
            this.buttonSelectDepot.UseVisualStyleBackColor = true;
            this.buttonSelectDepot.Click += new System.EventHandler(this.buttonSelectDepot_Click);
            // 
            // labelrepTravail
            // 
            this.labelrepTravail.AutoSize = true;
            this.labelrepTravail.Location = new System.Drawing.Point(20, 17);
            this.labelrepTravail.Name = "labelrepTravail";
            this.labelrepTravail.Size = new System.Drawing.Size(102, 13);
            this.labelrepTravail.TabIndex = 9;
            this.labelrepTravail.Text = "Répertoire de travail";
            // 
            // labelDepot
            // 
            this.labelDepot.AutoSize = true;
            this.labelDepot.Location = new System.Drawing.Point(19, 70);
            this.labelDepot.Name = "labelDepot";
            this.labelDepot.Size = new System.Drawing.Size(146, 13);
            this.labelDepot.TabIndex = 10;
            this.labelDepot.Text = "Répertoire destination (dépot)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = ".55 => prod / .58 => test";
            // 
            // checkBoxChangerDate
            // 
            this.checkBoxChangerDate.AutoSize = true;
            this.checkBoxChangerDate.Location = new System.Drawing.Point(20, 135);
            this.checkBoxChangerDate.Name = "checkBoxChangerDate";
            this.checkBoxChangerDate.Size = new System.Drawing.Size(111, 17);
            this.checkBoxChangerDate.TabIndex = 12;
            this.checkBoxChangerDate.Text = "Changer les dates";
            this.checkBoxChangerDate.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(39, 211);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(39, 185);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 15;
            // 
            // labelFormatDate
            // 
            this.labelFormatDate.AutoSize = true;
            this.labelFormatDate.Location = new System.Drawing.Point(42, 243);
            this.labelFormatDate.Name = "labelFormatDate";
            this.labelFormatDate.Size = new System.Drawing.Size(63, 13);
            this.labelFormatDate.TabIndex = 16;
            this.labelFormatDate.Text = "AAAAMMJJ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "label4";
            // 
            // FormExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 314);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFormatDate);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxChangerDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDepot);
            this.Controls.Add(this.labelrepTravail);
            this.Controls.Add(this.buttonSelectDepot);
            this.Controls.Add(this.buttonSelectSource);
            this.Controls.Add(this.buttonOuvrirDest);
            this.Controls.Add(this.comboBoxDepot);
            this.Controls.Add(this.comboBoxSource);
            this.Controls.Add(this.buttonGenerer);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button buttonSelectSource;
        private System.Windows.Forms.Button buttonSelectDepot;
        private System.Windows.Forms.Label labelrepTravail;
        private System.Windows.Forms.Label labelDepot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxChangerDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label labelFormatDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

