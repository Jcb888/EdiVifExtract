﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
//using ExtendedXmlSerialization;

namespace EdiVifExtract
{

    public partial class FormExtract : Form
    {
        // Les variables globals au formulaire
        string appDataArterris = "";//c'est dans ce repertoire qu'on a les droits et qu'il convient d'écrire
        string appdata = "";//son ss rep.
       
        //class pour serialiser les params à mémoriser
        static configObject co = new configObject();

        public FormExtract()
        {

            InitializeComponent();
            appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataArterris = Path.Combine(appdata, "Arterris");
            XmlSerializer xs = new XmlSerializer(typeof(configObject));//pour serialiser en XML la config (sauvegarde des paths src et dst)
            co.ListSourceDirectory = new List<comboItem>();
            co.listDepotDirectory = new List<comboItem>();
            co.strDepotSelectionne = "";
            co.strSourceSelectionne = "";

            if (!Directory.Exists(appDataArterris))
                Directory.CreateDirectory(appDataArterris);

           
            if (!File.Exists(appDataArterris + "\\configEDIv2.xml"))//si le fichier n'existe pas on le cré avec init à "";
            {
                co.ListSourceDirectory.Add(new comboItem("1",@"c:\temp"));
                co.strSourceSelectionne = @"c:\temp";
                co.listDepotDirectory.Add(new comboItem("1", @"\\vifprod.sca.local.\ascii\edi\cde"));
                co.listDepotDirectory.Add(new comboItem("2", @"\\viftest.sca.local.\ascii\edi\cde"));
                co.strDepotSelectionne = @"\\viftest.sca.local.\ascii\edi\cde";

                //if (!File.Exists(appDataArterris + "\\configEDIv2.xml"))
                //{
                    
                    using (StreamWriter wr = new StreamWriter(appDataArterris + "\\configEDIv2.xml"))
                    {
                        xs.Serialize(wr, co);//On sérialise;
                    }

                //}

            }

            //init des txtbox avec les params enregistres dans le xml

            using (StreamReader rd = new StreamReader(appDataArterris + "\\configEDIv2.xml"))
            {
                co = xs.Deserialize(rd) as configObject;
                
                //this.comboBoxSourcePath.Text = co.strSourcePath;

            }

            //verif si la deserialisation s'est bien faite
            if (co.strSourceSelectionne is null)
                MessageBox.Show("deserialisation du fichier de config echoue");


            remplirCombo();
        }

        public void remplirCombo()
        {
            //comboListeSource = co.ListSourceDirectory;
            //comboListeDest = co.listDepotDirectory;

            co.ListSourceDirectory.ForEach(i => comboBoxSource.Items.Add(i));
            co.listDepotDirectory.ForEach(i => comboBoxDepot.Items.Add(i));
            comboBoxSource.Text = co.strSourceSelectionne;
            comboBoxDepot.Text = co.strDepotSelectionne;

        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(comboBoxSource.Text))
            {
              MessageBox.Show("Ce repertoire source n'existe pas : " + comboBoxSource.Text);
              return;
            }
            // recup de la liste des fichier .asc du repertoire de la combobox 
            string[] tabFiles = Directory.GetFileSystemEntries(comboBoxSource.Text, "*.asc");

            if(tabFiles.Length < 1)
            {
                MessageBox.Show("Aucun fichier asc trouvé dans : " + comboBoxSource.Text);
                return;
            }

            for (int i = 0; i < tabFiles.Length; i++)
            {
                traiterFichierEnCours(tabFiles[i]);
            }

            try
            {
                System.Diagnostics.Process.Start("explorer.exe", comboBoxSource.Text);
            }
            catch (Exception e2)
            {

                MessageBox.Show(e2.StackTrace);
            }
        }

        private void traiterFichierEnCours(String fichierASC)
        {
            string[] OriginaleLines = System.IO.File.ReadAllLines(fichierASC);
            string[] modifiedLines = new string[OriginaleLines.Length];
            //string[] StrSplit = OriginaleLines[0].Split('"');
            string[] stringSeparators = new string[] { "\""+" "+"\"" };
            string[] StrSplit = OriginaleLines[0].Split(stringSeparators, StringSplitOptions.None);
            String numEDI = StrSplit[2];// on recupere le n° EDI
            if (this.checkBoxChangerDate.Checked)
            {
                StrSplit[09] = this.textBoxDateEmission.Text; //dateEmission
                StrSplit[10] = this.textBoxDateReception.Text;//dateReception
                StrSplit[11] = this.textBoxDateLivraison.Text;//dateLivraison

                //creation d'une nouvelle ligne d'en tete (1er ligne du fichier) par la meme avec les nouvelles dates
                String newlineEntete = "";
                for (int j = 0; j < StrSplit.Length; j++)
                {
                    if (j == StrSplit.Length-1 || j == 0) //si on est sur la 1er ligne ou la dernière
                    {
                        if (j == 0)// si on est sur la 1er ligne
                        {
                            newlineEntete = StrSplit[0] + '"'; // on ne rajoute pas d'espace
                        }
                        else//c'est le dernier
                        {
                            newlineEntete = newlineEntete + ' ' + '"' + StrSplit[j]; //on rajoute juste un espace
                        }
                        
                    }
                    else //toute sles autres lignes
                    {
                        newlineEntete = newlineEntete +' '+ '"'+StrSplit[j]+'"'; //
                    }
                   

                }

                OriginaleLines[0] = newlineEntete; // on remplace la ligne d'entete avec les dates original par la ligne d'entete avec les nouvelles dates


            }


            numEDI = numEDI.Trim(new Char[] { ' ', '"' });//suppression des "decoration" du n° EDI
            

            int i = 0;
            foreach (string line in OriginaleLines)
            {
                modifiedLines[i++] = line.Remove(0, 3);
                modifiedLines[i - 1] += Environment.NewLine;
                
            }

            if (this.checkBoxChangeNumEDI.Checked)
            {
                for (int j = 0; j < modifiedLines.Length; j++)
                {
                    modifiedLines[j] = modifiedLines[j].Replace(numEDI, textBoxNouveauNumEDI.Text);
                }
                numEDI = textBoxNouveauNumEDI.Text;
            }

            //creation du path et du repertoire pour placer les fcihiers
            string ediDir = Path.Combine(comboBoxSource.Text, numEDI);//path + num EDI == new path
            Directory.CreateDirectory(ediDir);//creation repertoire au nom du n° EDI

            //le fichier des entetes
            String Entete = "";

            System.IO.File.WriteAllText(Path.Combine(ediDir, "cde_ent.asc"), modifiedLines[0].ToString());

            String destFile = Path.Combine(ediDir, "cde_lig.asc");
            if (File.Exists(destFile)) { File.Delete(destFile); }

            for (int j = 1; j < modifiedLines.Length; j++)
            {
                System.IO.File.AppendAllText(destFile, modifiedLines[j].ToString());
            }

            using (System.IO.FileStream fs = System.IO.File.Create(Path.Combine(ediDir, "topcde")))
            {
                fs.Close();
                fs.Dispose();
            }

            
        }


        public void creatXML()
        {

            if (co == null)//un min de verif qd mm
                return;

            try
            {
                //co.strSourcePath = this.comboBoxSourcePath.Text;
                //co.strDestinationPath = this.comboBoxDestination.Text;
                //co.strFileSourcePath = this.comboBoxSourceFile.Text;

                XmlSerializer xs = new XmlSerializer(typeof(configObject));
                using (StreamWriter wr = new StreamWriter(appDataArterris + "\\configEDIv2.xml"))
                {
                    xs.Serialize(wr, co);
                }

                //MessageBox.Show("Enregitrement des paramétres bien effectué \n\r" + "Source: " + co.strSourcePath + "\n\r" + "Destination: " + co.strDestinationPath);

            }
            catch (Exception e)
            {

                MessageBox.Show("Erreur lors de la sauvegarde des paramètres: " + e.StackTrace.ToString());
            }

        }

        private void FormExtract_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Directory.Exists(comboBoxDepot.Text))
            //    co.strDepotSelectionne = comboBoxDepot.Text;

            //if (Directory.Exists(comboBoxSource.Text))
            //    co.strSourceSelectionne = comboBoxSource.Text;

            creatXML();
        }


        private void buttonOuvrirDest_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(comboBoxDepot.Text))
            {
                MessageBox.Show("Ce repertoire source est introuvable : " + comboBoxDepot.Text);
                return;
            }

            try
            {
                System.Diagnostics.Process.Start("explorer.exe", comboBoxDepot.Text );
            }
            catch (Exception e2)
            {

                MessageBox.Show(e2.StackTrace);
            }
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@ JCSoft - 2018 "+"\n"+"     Version 1.3");
        }

        private void comboBoxDepot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ajouterdepotlistCombo();
            }

        }

        private void ajouterdepotlistCombo()
        {

            if (!Directory.Exists(comboBoxDepot.Text))
            {
                MessageBox.Show("Ce repertoire est introuvable : " + comboBoxDepot.Text);
                return;
            }

            bool b = co.listDepotDirectory.Any(tr => tr.myValue.Equals(comboBoxDepot.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)
            {
                //KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicdepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                comboItem ci = new comboItem(((co.listDepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                co.listDepotDirectory.Add(ci);
                comboBoxDepot.Items.Add(ci);
                comboBoxDepot.SelectedIndex = comboBoxDepot.FindStringExact(ci.myValue);
            }
        }

        /// <summary>
        /// ajoute le texte du combo à sa liste
        /// </summary>
        private void ajouterSourcelistCombo()
        {
            if (!Directory.Exists(comboBoxSource.Text))
            {
                MessageBox.Show("Ce repertoire est introuvable : " + comboBoxSource.Text);
                return;
            }

            bool b = co.ListSourceDirectory.Any(tr => tr.myValue.Equals(comboBoxSource.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)
            {
                //KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicdepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                comboItem ci = new comboItem(((co.ListSourceDirectory.Count) + 1).ToString(), comboBoxSource.Text);
                co.ListSourceDirectory.Add(ci);
                comboBoxSource.Items.Add(ci);
                comboBoxSource.SelectedIndex = comboBoxSource.FindStringExact(ci.myValue);
            }
        }

        private void buttonSelectSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                comboBoxSource.Text = fbd.SelectedPath.ToString();
            }

            ajouterSourcelistCombo();
        }

        private void buttonSelectDepot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                comboBoxDepot.Text = fbd.SelectedPath.ToString();
            }

            ajouterdepotlistCombo();
        }

        private void comboBoxSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ajouterSourcelistCombo();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class configObject
    {

        public configObject()
        {

        }

        public String strSourceSelectionne;
        public String strDepotSelectionne;
        public List<comboItem> ListSourceDirectory;
        public List<comboItem> listDepotDirectory;
    }

    [Serializable]
    public class comboItem
    {
        public comboItem()
        {
         
        }

        public comboItem(string k, string v)
        {
            myKey = k;
            myValue = v;
        }

        [XmlElement("StringElementKey")]
        public String myKey { get; set; }

        [XmlElement("StringElementValue")]
        public String myValue { get; set; }

        public override string ToString()
        {
            return myValue;
        }

    }


}
