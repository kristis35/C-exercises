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

namespace LB5
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// List for data
        /// </summary>
        GenericLinkedList<BusTrip> BusTrips;
        GenericLinkedList<SoldTickets> SoldTicketss;

        /// <summary>
        /// Best trip name 
        /// </summary>
        string bestRoad;

        


        /// <summary>
        /// Rezults file
        /// </summary>
        string resultFile;

        /// <summary>
        /// Best trip money gain
        /// </summary>
        double bestMoney;

        const string Guide = "ProgramosGidas.txt";
        const string Uzduotis = "Uzduotis.txt";
        public Form1()
        {
            InitializeComponent();
            rezultataiToolStripMenuItem.Enabled = true;
            duomenuToolStripMenuItem.Enabled = true;
            skaičiavimaiToolStripMenuItem.Enabled = false;
            programaToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Menu item that select result file
        /// </summary>
        private void rezultataiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programaToolStripMenuItem.Enabled = true;
            failasToolStripMenuItem.Enabled = true;
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite failą rezultatų saugojimui";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                resultFile = saveFileDialog1.FileName;
                if (File.Exists(resultFile))
                    File.Delete(resultFile);
            }
        }

        /// <summary>
        /// Selects data files
        /// </summary>
        
        private void duomenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skaičiavimaiToolStripMenuItem.Enabled = true;

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.Title = "Pasirinkite duomenų failą.";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file1 = openFileDialog1.FileName;
                    BusTrips = ReadData<BusTrip>(file1);
                    if (BusTrips.IsEmpty())
                    {
                        PrintLine(resultFile, "Sąrašas tuščias!");
                    }
                    else
                    {
                        PrintTable(resultFile, BusTrips, "Pradiniai duomenys apie " +
                            "marsrutus::", BusTrip.HorizontalRule(), BusTrip.FieldNames());
                        
                    }
                }

                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.Title = "Pasirinkite duomenų failą.";
                result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string file1 = openFileDialog1.FileName;
                    SoldTicketss = ReadData<SoldTickets>(file1);
                   
                    PrintTable(resultFile, SoldTicketss,
                    "Pradiniai duomenys apie parduotus bilietus:",
                    SoldTickets.HorizontalRule(),
                    SoldTickets.FieldNames());
                        
                    
                }

                
               
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Klaida!. " + ex.Message);
            }

            richTextBox1.Text = File.ReadAllText(resultFile);
        }

        
        /// <summary>
        /// Finds trips
        /// </summary>
        private void grupesKuriomisVaziuojaBetVienasZmogusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            GenericLinkedList<string> AllTrips = UniqueGroups(SoldTicketss);
            if(AllTrips.IsEmpty())
            {
                PrintLine(resultFile, "Nera jokiu marsrutu kuriais vaziuoja bet vienas zmogus");
            }
            else
            {
                PrintTable(resultFile, AllTrips, "Marsrutai kurie turi bet viena keleivi", "--------", "");
            }

            richTextBox1.Text = File.ReadAllText(resultFile);
        }
        /// <summary>
        /// Finds what is the best trip road
        /// </summary>
        private void didziausiaPelnaTurintiMarsrutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenericLinkedList<TripCost> PassengerPerBusses = HowManyPassengersBus(SoldTicketss);
            GenericLinkedList<TripCost> MostValuableTrip = ValueForTrips(SoldTicketss, PassengerPerBusses);
            bestRoad = MostValuableTrip.HighestPrice(MostValuableTrip).TripNam;
            bestMoney = MostValuableTrip.HighestPrice(MostValuableTrip).Price;
            PrintLine(resultFile, bestRoad + " Geriausiai uzdirbes marsrutas" + " Sis marsrutas uzdirbo:" + bestMoney + "Eur");
            richTextBox1.Text = File.ReadAllText(resultFile);
        }
        //Displays task
        private void uzduotisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(Uzduotis);
        }

        //Displays guide
        private void programosNurodymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(Guide);
        }
        private void iseitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Finds how much passengers buyed trips
        /// </summary>
        /// <param name="SoldTicketData">List of sold ticket</param>
        /// <returns>Returns list with counted passengers</returns>
        GenericLinkedList<TripCost> HowManyPassengersBus(
            GenericLinkedList<SoldTickets> SoldTicketData)
        {
            var PassengerPerBus = new GenericLinkedList<TripCost>();
            foreach(SoldTickets ticket in SoldTicketData)
            {
                TripCost check = new TripCost(ticket.TripNumber,0, 1);
                if(PassengerPerBus.Contains(PassengerPerBus,check))
                {
                    PassengerPerBus.IncreaseRepetitionCount(PassengerPerBus,
                        check, 1);
                }
                else
                {
                    PassengerPerBus.AddToStart(check);
                }
            }
            return PassengerPerBus;
        }

        /// <summary>
        /// Sums up money gain
        /// </summary>
        /// <param name="BusTicketCost">List to check if matches trip name</param>
        /// <param name="CountedList">List to check if matches trip name</param>
        /// <returns>Return countedlist</returns>
        GenericLinkedList<TripCost> ValueForTrips(
            GenericLinkedList<SoldTickets> BusTicketCost,
            GenericLinkedList<TripCost> CountedList)
        {
            
            {
                foreach(TripCost item in CountedList)
                {
                    foreach(SoldTickets trip in BusTicketCost)
                    {
                        if(item.TripNam == trip.TripNumber)
                        {
                            item.Price = item.Count * trip.PriceForTicket;
                            
                        }
                    }
                }
            }
            return CountedList;
        }

        /// <summary>
        /// Reads input file and creates a custom generic linked list
        /// </summary>
        /// <typeparam name="T">Type of data class</typeparam>
        /// <param name="file">Filepath</param>
        /// <returns>Custom generic linked list</returns>
        GenericLinkedList<T> ReadData<T>(string file)
            where T : IReadable, new()
        {
            var MyList = new GenericLinkedList<T>();
            using (StreamReader fr = new StreamReader(file))
            {
                string line;
                while ((line = fr.ReadLine()) != null)
                {
                    T newItem = new T();
                    newItem.Read(line);
                    MyList.AddToStart(newItem);
                }
            }
            return MyList;
        }

        /// <summary>
        /// Add a line of text to output file
        /// </summary>
        /// <param name="file">file location</param>
        /// <param name="text">line to print</param>
        void PrintLine(string file, string text)
        {
            using (StreamWriter fw = File.AppendText(file))
            {
                fw.WriteLine(text);
                fw.WriteLine();
            }
        }

        /// <summary>
        /// Prints custom generic linked list items as a table
        /// </summary>
        /// <typeparam name="T">Type of data class</typeparam>
        /// <param name="file">filepath</param>
        /// <param name="MyList">Custom genericlinked list</param>
        /// <param name="title">table caption</param>
        /// <param name="horizontalRule">line</param>
        /// <param name="fieldNames">Table field names</param>
        void PrintTable<T>(string file, GenericLinkedList<T> MyList, string title,
            string horizontalRule = "", string fieldNames = "")
        {
            using (StreamWriter fw = File.AppendText(file))
            {
                fw.WriteLine(title);
                fw.WriteLine(horizontalRule);
                if (fieldNames != "")
                {
                    fw.WriteLine(fieldNames);
                    fw.WriteLine(horizontalRule);
                }
                foreach (T item in MyList)
                {
                    fw.WriteLine(item);
                }
                fw.WriteLine(horizontalRule);
                fw.WriteLine();
            }
        }

        /// <summary>
        /// Method who fins unique groups
        /// </summary>
        /// <param name="SoldTicketList">Custom generic linked list with soldticket data</param>
        /// <returns></returns>
        GenericLinkedList<string> UniqueGroups(
            GenericLinkedList<SoldTickets> SoldTicketList)
        {
            GenericLinkedList<string> groups = new GenericLinkedList<string>();
            foreach (SoldTickets item in SoldTicketList)
            {
                if (!groups.Contains(groups, item.TripNumber))
                {
                    groups.AddToStart(item.TripNumber);
                }
            }
            return groups;
        }

        
    }
}
