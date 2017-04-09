using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using ExtendedXmlSerialization;

namespace EdiVifExtract
{

    public partial class FormExtract : Form
    {
        // Les variables globals au formulaire
        string appDataArterris = "";//c'est dans ce repertoire qu'on a les droits et qu'il convient d'écrire
        string appdata = "";//son ss rep.
        String xml;

        //static List<FileInfo> listeFichiers = new List<FileInfo>();


        Dictionary<string, string> DicdepotDirectory = new Dictionary<string,string>();
        Dictionary<string, string> DicSourceDirectory = new Dictionary<string, string>();
        //Dictionary<string, string> DicdestinationDirectory = new Dictionary<string, string>();
        //class pour serialiser les params à mémoriser
        static configObject co = new configObject();

        public FormExtract()
        {

            co.DicSourceDirectory = DicSourceDirectory;
            //co.DicdestinationDirectory = DicdestinationDirectory;
            co.DicdepotDirectory = DicdepotDirectory;

            InitializeComponent();
            appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataArterris = Path.Combine(appdata, "Arterris");
            

            if (!Directory.Exists(appDataArterris))
                Directory.CreateDirectory(appDataArterris);

           
            ExtendedXmlSerializer xs = new ExtendedXmlSerializer();//pour serialiser en XML la config (sauvegarde des paths src et dst)
            if (!File.Exists(appDataArterris + "\\configEDI.xml"))//si le fichier n'existe pas on le cré avec init à "";
            {
                co.DicSourceDirectory.Add("1", @"c:\temp\");
                //co.DicdestinationDirectory.Add("1", @"c:\1");
                co.DicdepotDirectory.Add("1", @"\\srvvifprod1\ascii\edi\cde");
                co.DicdepotDirectory.Add("2", @"\\192.168.181.58\ascii\edi\cde");
                

                using (StreamWriter wr = new StreamWriter(appDataArterris + "\\configEDI.xml"))
                {
                  
                    xml  = xs.Serialize(co);
                    wr.WriteLine(xml);
                }

            }

            //init des txtbox avec les params enregistres dans le xml
            using (StreamReader rd = new StreamReader(appDataArterris + "\\configEDI.xml"))
            {

                xml = rd.ReadToEnd();
                co = xs.Deserialize<configObject>(xml);// as configObject;
                //this.DicdestinationDirectory = co.DicdestinationDirectory;
                this.DicSourceDirectory = co.DicSourceDirectory;
                this.DicdepotDirectory = co.DicdepotDirectory;
               
            }

            remplirCombo();
        }

        public void remplirCombo()
        {

            comboBoxSource.DataSource = new BindingSource(DicSourceDirectory, null);
            comboBoxSource.DisplayMember = "Value";
            comboBoxSource.ValueMember = "Key";
            comboBoxDepot.DataSource = new BindingSource(DicdepotDirectory, null);
            comboBoxDepot.DisplayMember = "Value";
            comboBoxDepot.ValueMember = "key";


        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(comboBoxSource.Text))
            {
              MessageBox.Show("Ce repertoire source n'existe pas : " + comboBoxSource.Text);
              return;
            }
            // recup de la liste des fichier .asc du repertoire de la combobox 
            string[] tabFiles = Directory.GetFileSystemEntries(((KeyValuePair<string, string>)comboBoxSource.SelectedItem).Value, "*.asc");

            for (int i = 0; i < tabFiles.Length; i++)
            {
                traiterFichierEnCours(tabFiles[i]);
            }
            
            string value = ((KeyValuePair<string, string>)comboBoxSource.SelectedItem).Value;
            MessageBox.Show(value);
        }

        private void traiterFichierEnCours(String fichierASC)
        {
            string[] OriginaleLines = System.IO.File.ReadAllLines(fichierASC);
            string[] modifiedLines = new string[OriginaleLines.Length];
            string[] StrSplit = OriginaleLines[0].Split('"');
            String numEDI = StrSplit[5];// on recupere le n° EDI
            numEDI = numEDI.Trim(new Char[] { ' ', '"' });//suppression des "decoration" du n° EDI
            string ediDir = Path.Combine(((KeyValuePair<string, string>)comboBoxSource.SelectedItem).Value, numEDI);//path + num EDI == new path
            Directory.CreateDirectory(ediDir);//creation repertoire au nom du n° EDI

            int i = 0;
            foreach (string line in OriginaleLines)
            {
                modifiedLines[i++] = line.Remove(0, 3);
                modifiedLines[i - 1] += Environment.NewLine;
            }


            //le fichier des entetes
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

            try
            {
                //co.DicdestinationDirectory = this.DicdestinationDirectory;
                co.DicSourceDirectory = this.DicSourceDirectory;
                co.DicdepotDirectory = this.DicdepotDirectory;
                ExtendedXmlSerializer xs = new ExtendedXmlSerializer();

                using (StreamWriter wr = new StreamWriter(appDataArterris + "\\configEDI.xml"))
                {

                    xml = xs.Serialize(co);
                    wr.WriteLine(xml);
                };

            }
            catch (Exception e)
            {

                MessageBox.Show("Erreur lors de la sauvegarde des paramètres: " + e.StackTrace.ToString());
            }

        }

        private void FormExtract_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            MessageBox.Show("@ Jean-Christophe BILLARD - 2017 "+"\n"+"     Version 0.1");
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

            bool b = DicdepotDirectory.Any(tr => tr.Value.Equals(comboBoxDepot.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicdepotDirectory.Count) + 1).ToString(), comboBoxDepot.Text);
                DicdepotDirectory.Add(kvp.Key, kvp.Value);
                comboBoxDepot.DataSource = new BindingSource(DicdepotDirectory, null);
                comboBoxDepot.SelectedIndex = comboBoxDepot.FindStringExact(kvp.Value);
            }
        }

        /// <summary>
        /// ajoute le texte du combo à sa liste
        /// </summary>
        private void ajouterSourcelistCombo()
        {
            if (!Directory.Exists(comboBoxSource.Text))
            {
                MessageBox.Show("Ce repertoire source n'existe pas : " + comboBoxSource.Text);
                return;
            }
            //deja dans la liste ?
            bool b = DicSourceDirectory.Any(tr => tr.Value.Equals(comboBoxSource.Text, StringComparison.CurrentCultureIgnoreCase));
            if (!b)//si non on le rajoute
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(((DicSourceDirectory.Count) + 1).ToString(), comboBoxSource.Text);
                DicSourceDirectory.Add(kvp.Key, kvp.Value);
                comboBoxSource.DataSource = new BindingSource(DicSourceDirectory, null);
                comboBoxSource.SelectedIndex = comboBoxSource.FindStringExact(kvp.Value);
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
    }

    public class configObject
    {
        public configObject()
        {

            //DicdestinationDirectory = new Dictionary<string, string>();//
            //DicSourceDirectory = new Dictionary<string, string>();
            //DicdepotDirectory = new Dictionary<string, string>();

        }

        public Dictionary<string, string> DicSourceDirectory;
        //public Dictionary<string, string> DicdestinationDirectory;
        public Dictionary<string, string> DicdepotDirectory;
    }

}
