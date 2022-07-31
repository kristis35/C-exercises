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

namespace LB4
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Files how to and task constants
        /// </summary>
        const string howto = "Nurodymai.txt";
        const string task = "Uzduotis.txt";


        /// <summary>
        /// Results file
        /// </summary>
        string saveFile;
        /// <summary>
        /// Team names and agent name
        /// </summary>
        string teamname1, teamname2;

        /// <summary>
        /// Average height
        /// </summary>
        double aveheight3;

        /// <summary>
        /// Linked list 
        /// </summary>
        BasketballerData Basketballer1,
                         Basketballer2,
                         Basketballer3;
                         

        public Form1()
        {
            Basketballer1 = new BasketballerData();
            Basketballer2 = new BasketballerData();
            Basketballer3 = new BasketballerData();

            
            InitializeComponent();

            skačiavimaiToolStripMenuItem.Enabled = false;
        }
        /// <summary>
        /// Pradinis zingsnis menu click action
        /// </summary>
        
        private void pradinisŽingsnisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite failą rezultatų rašymui";
            DialogResult result3 = saveFileDialog1.ShowDialog();
            if (result3 == DialogResult.OK)
            {
                saveFile = saveFileDialog1.FileName;
                if (File.Exists(saveFile))
                    File.Delete(saveFile);
            }

            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite pirmos institucijos duomenų failą";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                string file1 = openFileDialog1.FileName;
                ReadList(file1, Basketballer1, out teamname1, 1);
                PrintTable(saveFile, Basketballer1, teamname1 + ':');
               
            }

            
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite antros institucijos duomenų failą";
            DialogResult result2 = openFileDialog1.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                string file2 = openFileDialog1.FileName;
                ReadList(file2, Basketballer2, out teamname1, 1);
                PrintTable(saveFile, Basketballer2, teamname1 + ':');
            }
            richTextBox1.Text = File.ReadAllText(saveFile, Encoding.UTF8);
            skačiavimaiToolStripMenuItem.Enabled = true;
            surašytiToolStripMenuItem.Enabled = false;
            rikiuotiToolStripMenuItem.Enabled = false;
            pašalintiToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Baigti menu click action
        /// </summary>
        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Vidurkis menu click action
        /// </summary>
        private void vidurkiaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int two = 2;
            double aveage1 = AgeAverage(Basketballer1);
            double aveage2 = AgeAverage(Basketballer2);
            double aveage3 = (aveage1 + aveage2) / two;
            double aveheig1 = HeightAverage(Basketballer1);
            double aveheig2 = HeightAverage(Basketballer2);
            aveheight3 = (aveheig1 + aveheig2) / two;
            PrintLine(saveFile,"Amziaus vidurkis: ",aveage3);
            PrintLine(saveFile, teamname1 + " Ugio vidurkis yra:", aveheig1);
            PrintLine(saveFile, teamname2 + " Ugio vidurkis yra:", aveheig2);
            richTextBox1.Text = File.ReadAllText(saveFile, Encoding.UTF8);
            surašytiToolStripMenuItem.Enabled = true;
            rikiuotiToolStripMenuItem.Enabled = true;
            pašalintiToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Surasyti menu click action
        /// </summary>
        private void surašytiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ListPlayers(Basketballer1, Basketballer3, aveheight3);
            ListPlayers(Basketballer2, Basketballer3, aveheight3);
            if(!Basketballer3.IsEmpty())
            {
                PrintTable(saveFile, Basketballer3, "Sudarytas naujas sarasas");
            }
            else
            {
                PrintLine(saveFile, "Nera tinkamu zaideju", 0);
            }
            richTextBox1.Text = File.ReadAllText(saveFile, Encoding.UTF8);
        }
        /// <summary>
        /// Rikiuoti click action
        /// </summary>
        private void rikiuotiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Basketballer3.BubbleSort();
            PrintTable(saveFile, Basketballer3, "Surikiuoti");
            richTextBox1.Text = File.ReadAllText(saveFile, Encoding.UTF8);
        }

        /// <summary>
        /// Pasalinti menu click action
        /// </summary>
        private void pašalintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int limit = int.Parse(textBox1.Text);
            Basketballer3.Remove(limit);

            if (!Basketballer3.IsEmpty())
            {
                PrintTable(saveFile, Basketballer3, "Pašalinti:");
            }
            else
            {
                PrintLine(saveFile, "Krepšininkų sąrašas tuščias!",0);
               
            }

            richTextBox1.Text = File.ReadAllText(saveFile, Encoding.UTF8);
        }


        /// <summary>
        /// Nurodymai menu click action
        /// </summary>
        private void nurodymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(howto, Encoding.UTF8));
        }

        /// <summary>
        /// U=duotis menu click action
        /// </summary>
        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(task,Encoding.UTF8));
        }

        /// <summary>
        /// Reading method from a file to linked list
        /// </summary>
        /// <param name="fv">Reading file</param>
        /// <param name="BasketballerList">Linked list</param>
        /// <param name="team">Team Name or manager</param>
        /// <param name="type">Generated type of list</param>
        void ReadList(string fv, BasketballerData BasketballerList,out string team,int type)
        {
            
            using (var file = new StreamReader(fv))
            {
                string line;
                team = line = file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] linePart = line.Split(';');
                    Basketballer bskt = new Basketballer(linePart[0], int.Parse(linePart[1]), DateTime.Parse(linePart[2]));
                    if (type >= 0)
                        BasketballerList.SetDataFront(bskt);
                    else
                        BasketballerList.SetDataBack(bskt);
                }
            }
            
        }

        /// <summary>
        /// Print method to file
        /// </summary>
        /// <param name="file">File where text is printing</param>
        /// <param name="BasketballerList">Linkedlist to print</param>
        /// <param name="caption">Caption</param>
        void PrintTable(string file, BasketballerData BasketballerList, string caption)
        {
            string top = "-------------------------|--------------|-----------|\n" +
                         "     Name                |  Height      |    Age \n"
                        +"-------------------------|--------------|-----------|";

          string hline = "-------------------------|--------------|------------";

            using (var fw = File.AppendText(file))
            {
                if (!BasketballerList.IsEmpty())
                {
                    fw.WriteLine(caption);
                    fw.WriteLine(top);
                    foreach (Basketballer bskt in BasketballerList)
                    {
                        fw.WriteLine(bskt.ToString());
                    }
                    fw.WriteLine(hline);
                    fw.WriteLine();
                }
                else
                {
                    fw.WriteLine(caption);
                    fw.WriteLine("Tuscias");
                }
            }
        }

        /// <summary>
        /// Age average method
        /// </summary>
        /// <param name="BaskList">Linked list</param>
        /// <returns>Age average</returns>
        double AgeAverage(BasketballerData BaskList)
        {
            double age = 0;
            int count = 0;
            foreach(Basketballer bskt in BaskList)
            {
                age = age + bskt.Age;
                count++;
            }
            return age/count;
        }

        /// <summary>
        /// Adds into new LinkedList player who are above average
        /// </summary>
        /// <param name="Old">Olf LinkedList</param>
        /// <param name="New">New linkedlist with players above average</param>
        /// <param name="height">Height average</param>
        void ListPlayers(BasketballerData Old, BasketballerData New, double height)
        {
            foreach (Basketballer bskt in Old)
            {
                if (bskt.Height >= height)
                {
                    New.SetDataBack(bskt);
                }
            }
        }

        /// <summary>
        /// Height average method
        /// </summary>
        /// <param name="BaskList">LinkedList</param>
        /// <returns>Height average</returns>
        double HeightAverage(BasketballerData BaskList)
        {
            int count = 0;
            double heig = 0;
            foreach (Basketballer bskt in BaskList)
            {
                heig = heig + bskt.Height;
                count++;
            }
            return heig/count;
        }

       
        /// <summary>
        /// Prints line 
        /// </summary>
        /// <param name="file">where to print</param>
        /// <param name="text">caption text</param>
        /// <param name="data">Data</param>
        void PrintLine(string file, string text ,double data )
        {
            using (var fw = File.AppendText(file))
            {
                fw.WriteLine(text);
                fw.WriteLine(data);
                fw.WriteLine();
            }
        }
    }
}
