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

namespace LB3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constants
        /// </summary>
        const string CFd2 = "Uzduotis.txt";
        const string CFd3 = "Uzduotis.txt";

        /// <summary>
        /// Lists
        /// </summary>
        List<CarMade> CarMadeList4 = new List<CarMade>();
        List<CarMade> CarMadeList1 = new List<CarMade>();
        List<CarMade> CarMadeList2 = new List<CarMade>();
        List<CarMade> CarMadeList3 = new List<CarMade>();
        Dictionary<int, CarMade>


        /// <summary>
        /// Results file
        /// </summary>
        string filesave;

        /// <summary>
        /// Buttons
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            įvestiToolStripMenuItem.Enabled = false;
            skaičiavimaiToolStripMenuItem.Enabled = false;
        }

        
        /// <summary>
        /// Reading method
        /// </summary>
        /// <param name="fv">file</param>
        /// <param name="AutoList">List</param>
        /// <returns>List/returns>
        static List<CarMade> ReadCarMadeList(string fv, List<CarMade> AutoList)
        {
            using (StreamReader file = new StreamReader(fv, Encoding.UTF8))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    string[] part = line.Split(';');
                    string num = part[0];
                    string prod = part[1];
                    string mod = part[2];
                    DateTime agee = DateTime.Parse(part[3]);
                    DateTime tehage = DateTime.Parse(part[4]);
                    string fuell = part[5];
                    double avgfuel = double.Parse(part[6]);

                    CarMade auto = new CarMade(num, prod, mod,agee, tehage, fuell, avgfuel);
                    AutoList.Add(auto);
                }
            }
            return AutoList;
        }
        /// <summary>
        /// Print method
        /// </summary>
        /// <param name="fv">File</param>
        /// <param name="AutosList">List</param>
        /// <param name="something">Heading</param>
        static void PrintCarMadeList(string fv, List<CarMade> AutosList, string something)
        {

            const string top =
            "-----------------------------------------------------------------------------------------------------------------------------------------------\r\n"
            + " Nr.    Modelis   Valstybinis numeris          Gamintojas           Auto amzius      Technine apziura       Kuro tipas      Vid Sanaudos \r\n"
            + "-----------------------------------------------------------------------------------------------------------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.UTF8))
            {
                fr.WriteLine("\n " + something);
                fr.WriteLine(top);
                for (int i = 0; i < AutosList.Count; i++)
                {
                    CarMade aut = AutosList[i];
                    fr.WriteLine("{0, -8} {1}", i + 1, aut);
                }
                fr.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------\n");
            }

        }


        
        /// <summary>
        /// Takes two newest cars
        /// </summary>
        /// <param name="CarList">List</param>
        /// <param name="max">Max age int</param>
        /// <param name="secondMax">Second max int</param>
        private (int, int) TakeTwo(List<CarMade> CarList)
        {
            ///max int value
            int firstMaxAge = int.MaxValue, secondMaxAge = int.MaxValue;
            
            int firstIndMax = -1;
            int secondIndMax = -1;
            for(int i = 0; i < CarList.Count; i++)
            {
                if (CarList[i].Age <= firstMaxAge)
                {
                    secondMaxAge = firstMaxAge;
                    secondIndMax = firstIndMax;
                    firstMaxAge = CarList[i].Age;
                    firstIndMax = i;
                    
                }
                else if (CarList[i].Age <= secondMaxAge && CarList[i].Age < firstMaxAge)
                {
                    secondMaxAge = CarList[i].Age;
                    secondIndMax = i;
                }
                    
            }
            return (firstIndMax, secondIndMax);
        }
        /// <summary>
        /// All same model cars
        /// </summary>
        /// <param name="automobilesListt">List</param>
        /// <param name="automobilesListt1">List1</param>
        /// <param name="something">Heading</param>
        public void AllSameCars(List<CarMade> automobilesListt, List<CarMade> automobilesListt1, string something)
        {
            for(int i = 0; i < automobilesListt.Count; i++)
            {
                if(automobilesListt[i].Model == something)
                {
                    automobilesListt1.Add(automobilesListt[i]);
                }

            }
        }



        /// <summary>
        /// Removes same car models
        /// </summary>
        /// <param name="AutomobileList">List</param>
        /// <returns>List Different</returns>
        public void AllDifferent(List<CarMade> AutomobileList,List<CarMade> AutomobilesList1)
        {
            
            {
                for(int i = 0; i < AutomobileList.Count; i++)
                {
                    if(!AutomobilesList1.Contains(AutomobileList[i]))
                    {
                        AutomobilesList1.Add(AutomobileList[i]);
                    }
                }
            }
            
        }
        /// <summary>
        /// Ivesti click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fr = File.AppendText(filesave))
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
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                ReadCarMadeList(fv, CarMadeList1);
            }
            skaičiavimaiToolStripMenuItem.Enabled = true;



        }
        /// <summary>
        /// Spausdinti click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spausidintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintCarMadeList(filesave, CarMadeList1, "Pradinis sąrašas");
            richTextBox1.LoadFile(filesave, RichTextBoxStreamType.PlainText);
        }
        /// <summary>
        /// Baigti click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Du naujausi click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void duNaujausiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            (int, int) twoNew = TakeTwo(CarMadeList1);
            CarMadeList4.Add(CarMadeList1[twoNew.Item1]);
            CarMadeList4.Add(CarMadeList1[twoNew.Item2]);
            PrintCarMadeList(filesave, CarMadeList4, "Du naujausi automobiliai");
            richTextBox1.LoadFile(filesave, RichTextBoxStreamType.PlainText);


        }
        /// <summary>
        /// Sudaryti sarasa click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sudarytiSąrašąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mar = textBox1.Text;
            AllSameCars(CarMadeList1,CarMadeList2, mar);
            if (CarMadeList2.Count() > 0)
            {
                PrintCarMadeList(filesave, CarMadeList2, "Suformuotas sąrašas");
            }
            else
                using (var fr = File.AppendText(filesave))
                {
                    fr.WriteLine("Naujas sąrašas tuščias");
                }
            richTextBox1.LoadFile(filesave, RichTextBoxStreamType.PlainText);

        }
        /// <summary>
        /// Sarasas be pasikartojimu action click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sąrašasBePasikartojimųToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AllDifferent(CarMadeList1,CarMadeList3);
            if (CarMadeList3.Count() > 0)
            {
                PrintCarMadeList(filesave, CarMadeList3,"Suformuotas naujas sarasas");
            }
            else
                using (var fr = File.AppendText(filesave))
                {
                    fr.WriteLine("Naujas sąrašas tuščias");
                }

            richTextBox1.LoadFile(filesave, RichTextBoxStreamType.PlainText);
        }
        /// <summary>
        /// Rikiuoti click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rikiuotiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarMadeList1.Sort();
            PrintCarMadeList(filesave, CarMadeList1, "Rikiutoas");
            richTextBox1.LoadFile(filesave, RichTextBoxStreamType.PlainText);

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }
        /// <summary>
        /// Issaugoti action click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void issaugotiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (.*txt)| *.txt| All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatu faila";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filesave = saveFileDialog1.FileName;
                if (File.Exists(filesave))
                {
                    File.Delete(filesave);
                }

            }
            įvestiToolStripMenuItem.Enabled = true;

        }

        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(CFd2));
        }

        private void nurodymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText(CFd3));
        }
    }
}
