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

        static List<FileInfo> listeFichiers = new List<FileInfo>();

        Dictionary<string, string> DicdepotDirectory = new Dictionary<string,string>();
        Dictionary<string, string> DicSourceDirectory = new Dictionary<string, string>();
        Dictionary<string, string> DicdestinationDirectory = new Dictionary<string, string>();
        static configObject co = new configObject();

        public FormExtract()
        {
            DicSourceDirectory.Add("1", @"c:\temp\");
            DicSourceDirectory.Add("2", @"d:\temp\");
            DicSourceDirectory.Add("3", @"e:\temp\");
            DicdestinationDirectory.Add("1", @"c:\1");
            DicdestinationDirectory.Add("2", @"c:\2");
            DicdestinationDirectory.Add("3", @"c:\3");
            DicdepotDirectory.Add("1", @"c:\1");

            co.DicSourceDirectory = DicSourceDirectory;
            co.DicdestinationDirectory = DicdestinationDirectory;
            co.DicdepotDirectory = DicdepotDirectory;

            InitializeComponent();
            appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataArterris = Path.Combine(appdata, "Arterris");
            

            if (!Directory.Exists(appDataArterris))
                Directory.CreateDirectory(appDataArterris);

           
            ExtendedXmlSerializer xs = new ExtendedXmlSerializer();//pour serialiser en XML la config (sauvegarde des paths src et dst)
            if (!File.Exists(appDataArterris + "\\configEDI.xml"))//si le fichier n'existe pas on le cré avec init à "";
            {

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
                this.DicdestinationDirectory = co.DicdestinationDirectory;
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
            //-----------------------------------------
            comboBoxDestination.DataSource = new BindingSource(DicdestinationDirectory, null);
            comboBoxDestination.DisplayMember = "Value";
            comboBoxDestination.ValueMember = "key";
            //-------------------------------------------
            comboBoxDepot.DataSource = new BindingSource(DicdepotDirectory, null);
            comboBoxDepot.DisplayMember = "Value";
            comboBoxDepot.ValueMember = "key";


        }

        private void buttonGenerer_Click(object sender, EventArgs e)
        {

            string[] OriginaleLines = System.IO.File.ReadAllLines(@"c:\temp\10474434.asc");
            string[] modifiedLines = new string[OriginaleLines.Length];
            string[] StrSplit = OriginaleLines[0].Split('"');
            String numEDI = StrSplit[5];
            numEDI = numEDI.Trim(new Char[] { ' ', '"'});
            string ediDir = Path.Combine(((KeyValuePair<string, string>)comboBoxSource.SelectedItem).Value, numEDI);
            Directory.CreateDirectory(ediDir);


            int i = 0;
            foreach (string line in OriginaleLines)
            {
                modifiedLines[i++] = line.Remove(0, 3);
                modifiedLines[i - 1] += Environment.NewLine;
            }


            //le fichier des entetes
            System.IO.File.WriteAllText(Path.Combine(ediDir,"cde_ent.asc"), modifiedLines[0].ToString());

            String destFile = Path.Combine(ediDir, "cde_lig.asc");
            if (File.Exists(destFile)) { File.Delete(destFile); }

            for (int j = 1; j < modifiedLines.Length; j++)
            {
                System.IO.File.AppendAllText(destFile, modifiedLines[j].ToString());
            }

            using (System.IO.FileStream fs = System.IO.File.Create(Path.Combine(ediDir, "tpcde")))
            {
                fs.Close();
                fs.Dispose();
            }

                string value = ((KeyValuePair<string, string>)comboBoxSource.SelectedItem).Value;
            MessageBox.Show(value);

        }



        public void creatXML()
        {

            try
            {
                co.DicdestinationDirectory = this.DicdestinationDirectory;
                co.DicSourceDirectory = this.DicSourceDirectory;
                co.DicdepotDirectory = this.DicdepotDirectory;
                ExtendedXmlSerializer xs = new ExtendedXmlSerializer();

                var xml = xs.Serialize(co);

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
        public Dictionary<string, string> DicdestinationDirectory;
        public Dictionary<string, string> DicdepotDirectory;
    }

    public class MyObject
    {
        public MyObject()
        {

            //DicdestinationDirectory = new Dictionary<string, string>();//
            //DicSourceDirectory = new Dictionary<string, string>();
            //DicdepotDirectory = new Dictionary<string, string>();

        }

        private int Myint;

        public int Myint1 { get => Myint; set => Myint = value; }
    }
}
