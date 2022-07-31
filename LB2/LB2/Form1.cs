using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace LB2
{
    public partial class Krepsininkai : Form
    {
        /// <summary>
        /// Data files and results
        /// </summary>
        const string CFd3 = "Naujokai.txt";
        const string CFd2 = "Uzduotis.txt";
        const string CFr = "Rezultatai.txt";
        const string CFd4 = "Nurodymai.txt";
        /// <summary>
        /// List basketballers
        /// </summary>
        List<Basketballer> players1 = new List<Basketballer>();

        List<Basketballer> players2 = new List<Basketballer>();

        List<Basketballer> players3 = new List<Basketballer>();

        List<Basketballer> players4 = new List<Basketballer>();

        // Strings for team names and manager
        string TeamName1;
        string TeamName2;
        string nameSr;
        

        public Krepsininkai()
        {
            InitializeComponent();
            if (File.Exists(CFr))
                File.Delete(CFr);
            įvestiToolStripMenuItem.Enabled = true;
            spausdintiToolStripMenuItem.Enabled = true;
            rastiVidurkisToolStripMenuItem.Enabled = false;
            rastiVidurkisToolStripMenuItem.Enabled = false;
            surašytiToolStripMenuItem.Enabled = false;
            rikiuotiToolStripMenuItem.Enabled = false;
            pridėtiNaujokusToolStripMenuItem.Enabled = false;
            užduotisToolStripMenuItem.Enabled = false;
            nurodymaiToolStripMenuItem.Enabled = true;

        }
        // Ivesti click action
        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine("Užduotis" + "\n\n" + File.ReadAllText(CFd2) + "\n\n");
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                rezults.LoadFile(fv, RichTextBoxStreamType.PlainText);
                players1 = ReadBasketList(fv,players2,out TeamName1);
            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                rezults.LoadFile(fv, RichTextBoxStreamType.PlainText);
                players2 = ReadBasketList(fv, players1,out TeamName2);
            }


            players3 = ReadBasketList(CFd3, players3, out nameSr);
            PrintBasketBallerList(CFr, players1, "Pradiniai duomenys 1");
            PrintBasketBallerList(CFr, players2, "Pradiniai duomenys 2");
            PrintBasketBallerList(CFr, players3, "Pradiniai duomenys 3");
            rezults.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            rastiVidurkisToolStripMenuItem.Enabled = true;
            užduotisToolStripMenuItem.Enabled = true;
            įvestiToolStripMenuItem.Enabled = false;



        }
        // Spausdinti click action
        private void spausdintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Pasirinkite faila rezultatu sarasui spausdinti";
            DialogResult result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string cvsFile = saveFileDialog.FileName;
                if (File.Exists(cvsFile))
                    File.Delete(cvsFile);
                PrintCSVList(cvsFile, players4);
                MessageBox.Show(".csv failas sukurtas");

            }

        }
        // Rasti vidurki menu click action
        private void rastiVidurkisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fr = File.AppendText(CFr))
            {

                

                double totalAge = (AverageAge(players1) + AverageAge(players2)) / 2;
                double totalHeight = (AverageHeight(players1) + AverageHeight(players2)) / 2;


                fr.Write("Krepšininkų amžiaus vidurkis " + totalAge.ToString() + "m" + "\n\n"+
                    "Krepšininkų ugio vidurkis " + totalHeight.ToString() + "m" + "\n\n"
            + TeamName1 + "  Komandos vidurkis yra " + AverageHeight(players1).ToString() + "cm" + "\n\n"
            + TeamName2 + "  Komandos vidurkis yra " + AverageHeight(players2).ToString() + "cm" + "\n\n" +
             nameSr + "  Komandos vidurkis yra " + AverageHeight(players3).ToString() + "cm");
                fr.WriteLine();

            }
            rezults.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            surašytiToolStripMenuItem.Enabled = true;
            rikiuotiToolStripMenuItem.Enabled = true;
            pridėtiNaujokusToolStripMenuItem.Enabled = true;

        }
        // Surašyti click action
        private void surašytiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double totalHeight = (AverageHeight(players1) + AverageHeight(players2)) / 2;
            AddToList(players1, players4,totalHeight);
            AddToList(players2, players4,totalHeight);
            PrintBasketBallerList(CFr, players4, "Naujasis masyvas su formuotas iš krepšininkų kurie yra aukštesni už vidurkį");
            rezults.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            


        }
        // Rikiuoti click action
        private void rikiuotiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            players4.Sort();
            PrintBasketBallerList(CFr, players4, "Surikiuotas masyvas");
            rezults.LoadFile(CFr, RichTextBoxStreamType.PlainText);


        }
        // Prideti naujokus click action
        private void pridėtiNaujokusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertAll(players4, players3);
            PrintBasketBallerList(CFr, players4, "Insert");
            rezults.LoadFile(CFr, RichTextBoxStreamType.PlainText);

        }
        //Užduotis menu click action
        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(CFd2));
        }
        //nurodymai click action
        private void nurodymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(CFd4));
        }
        //Ismesti click action
        private void ismesti_Click(object sender, EventArgs e)
        {
            string value = agebox.Text;
            int result = Int32.Parse(value);
            RemoveListFromInt(players4, result);
            if (players3.Count == 0)
            {
                rezults.Text = "Pašalinti visi žaidejai";
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Pašalinti visi žaidejai");

                }
            }
            else
            {
                PrintBasketBallerList(CFr, players4, "Galutinis žaidėjų sarašas");
                rezults.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            }


        }
        /// <summary>
        /// Baigti click action
        /// </summary>
        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Reading method list
        /// </summary>
        /// <param name="fv">Data file</param>
        /// <param name="BasketBallersList">List</param>
        /// <param name="nameSur">Team name or Manager name</param>
        /// <returns>BasketballersList</returns>
        static List<Basketballer> ReadBasketList(string fv, List<Basketballer> BasketBallersList, out string nameSur)
        {
            using (StreamReader file = new StreamReader(fv, Encoding.UTF8))
            {
                string line = file.ReadLine();
                nameSur = line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] part = line.Split(';');
                    string namSur = part[0];
                    int height = int.Parse(part[1]);
                    DateTime age = DateTime.Parse(part[2]);

                    Basketballer basketballer = new Basketballer(namSur, height, age);
                    BasketBallersList.Add(basketballer);
                }
            }
            return BasketBallersList;
        }
        /// <summary>
        /// List print method
        /// </summary>
        /// <param name="fv">Rezults file</param>
        /// <param name="BasketBallersList">Basketballers list</param>
        /// <param name="something">Text</param>
        static void PrintBasketBallerList(string fv, List<Basketballer> BasketBallersList, string something)
        {

            const string top =
            "---------------------------------------------------------------------\r\n"
            + " Nr. Pavardė ir vardas        Ugis        Amžius \r\n"
            + "--------------------------------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append),Encoding.UTF8))
            {
                fr.WriteLine("\n " + something);
                fr.WriteLine(top);
                for (int i = 0; i < BasketBallersList.Count; i++)
                {
                    Basketballer bst = BasketBallersList[i];
                    fr.WriteLine("{0, 3} {1}", i + 1, bst);
                }
                fr.WriteLine("--------------------------------------------------------------------\n");
            }

        }


        
        /// <summary>
        /// Method remove from index
        /// </summary>
        /// <param name="BasketBallersList">Basketballers list</param>
        /// <param name="index">index from form1</param>
        static void RemoveListFromInt(List<Basketballer> BasketBallersList, int index)
        {

            for (int i = 0; i < BasketBallersList.Count; i++)
                if (BasketBallersList[i].Age > index)
                {
                    BasketBallersList.RemoveAt(i);
                    i--;
                }
        }
        /// <summary>
        /// Adds players to one list
        /// </summary>
        /// <param name="BasketBallersList">Basketballer players list</param>
        /// <param name="BasketBallersList1">Another basketballer players list</param>
        static void AddToList(List<Basketballer> BasketBallersList, List<Basketballer>BasketBallersList1,double aveHei)
        {
            

            for (int i = 0; i < BasketBallersList.Count; i++)
            {
               

                if(BasketBallersList[i].Height > aveHei)
                {
                    BasketBallersList1.Add(BasketBallersList[i]);
                }
                
            }
        }
        /// <summary>
        /// Average height method
        /// </summary>
        /// <param name="BasketballersList">Basketballer players list</param>
        /// <returns>double average</returns>
        static double AverageHeight(List<Basketballer> BasketballersList)
        {
            double average;
            int sumHeight = BasketballersList.Sum(item => item.Height);
            average = (double)sumHeight / BasketballersList.Count;
            return average;

        }
        /// <summary>
        /// Average age method 
        /// </summary>
        /// <param name="BasketballersList">Basketballer players list</param>
        /// <returns>double averageAge</returns>
        static double AverageAge(List<Basketballer> BasketballersList)
        {
            double averageAge;
            int sumAge = BasketballersList.Sum(item => item.Age);
            averageAge = (double)sumAge / BasketballersList.Count;
            return averageAge;

        }

        /// <summary>
        /// Inserts in new list
        /// </summary>
        /// <param name="BasketballersList">Basketballer players list</param>
        /// <param name="BasketballersList1">Basketballer players list</param>
        private static void InsertAll(List<Basketballer> BasketballersList, List<Basketballer> BasketballersList1)
        {
            for (int i = 0; i < BasketballersList1.Count; i++)
            {
                Basketballer ts = BasketballersList1[i];
                int j;
                for (j = 0; (j < BasketballersList.Count) && (BasketballersList[j].CompareTo(ts) < 0); j++)
                { }
                BasketballersList.Insert(j, ts);
            }
        }
        /// <summary>
        /// Printing in excel 
        /// </summary>
        /// <param name="fileDirectory">where file is</param>
        /// <param name="BasketballersList">Basketballer players list</param>
        void PrintCSVList(string fileDirectory, List<Basketballer> BasketballersList)
        {
            using (StreamWriter writer = new StreamWriter(@fileDirectory, false, Encoding.UTF8))
            {
                for (int i = 0; i < BasketballersList.Count; i++)
                {
                    writer.WriteLine("{0,1},{1,1},{2,1}",
                        BasketballersList[i].NameSur,
                        BasketballersList[i].Age,
                        BasketballersList[i].Height);

                }
            }
        }
    }
}
