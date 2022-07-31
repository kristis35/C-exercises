///Krepšinio mokykloje treniruotes lankančių sąrašas yra tekstiniame faile: būsimo krepšininko vardas ir pavardė, amžius ir ūgis. Pirmoje eilutėje yra krepšinio mokyklos pavadinimas. Turime dviejų mokyklų duomenis. L1+L2+L4.
///• Raskite, koks būsimų krepšininkų amžiaus vidurkis ir koks ūgio vidurkis kiekvienoje mokykloje. 
///• Surašykite į atskirą rinkinį visus abiejų mokyklų sportininkus, kurių ūgis didesnis už vidurkį. 
///• Surikiuokite rezultatų sąrašą amžiaus didėjimo tvarka. 
///• Pašalinkite iš rezultatų sąrašo krepšininkus, kurių amžius yra didesnis už nurodytą klaviatūra.


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


namespace LB1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Data files and results
        /// </summary>
        const string CFd = "Krepsininkai1.txt";
        const string CFd1 = "Krepsininkai2.txt";
        const string CFd2 = "Uzduotis.txt";
        const string CFr = "Rezultatai.txt";

        Basketballers players1;//Array with first data files

        Basketballers players2;//Array with second data files

        Basketballers players3 = new Basketballers();//Array with players > vid2

        string TeamName1;//team name first
        string TeamName2;//team name second

        public Form1()
        {
            InitializeComponent();
            if (File.Exists(CFr))
                File.Delete(CFr);
            
        }

        ///action of "Iveskti" click
        private void uploud_Click(object sender, EventArgs e)
        {

            using (var fr = File.AppendText(CFr))
            {
                fr.WriteLine("Užduotis" + "\n\n" + File.ReadAllText(CFd2) + "\n\n");
            }

            players1 = ReadBasketCont(CFd, out TeamName1);
            players2 = ReadBasketCont(CFd1, out TeamName2);
            PrintBasketBallersCont(CFr, players1, "Pradiniai duomenys 1");
            PrintBasketBallersCont(CFr, players2, "Pradiniai duomenys 2");
            richTextBox1.LoadFile(CFr, RichTextBoxStreamType.PlainText);

            

        }

        //action of "Rasti vidurkį" click
        private void find_Click(object sender, EventArgs e)
        {
            double vid1 = (AgeAverage(players1) + AgeAverage(players2)) / 2;
            double vid3 = HeightAverage(players1);
            double vid4 = HeightAverage(players2);

            using (var fr = File.AppendText(CFr))
            {
                fr.Write("Krepšininkų amžiaus vidurkis " + vid1.ToString() + "m" + "\n\n"
            + TeamName1 + "  Komandos vidurkis yra " + vid3.ToString() + "cm" + "\n\n"
            + TeamName2 + "  Komandos vidurkis yra " + vid4.ToString() + "cm");
                fr.WriteLine();
            }
            richTextBox1.LoadFile(CFr, RichTextBoxStreamType.PlainText);

            
        }

        //action of "Surašyti" click
        private void write_Click(object sender, EventArgs e)
        {
            double vid2 = (HeightAverage(players1) + HeightAverage(players2)) / 2;

            AddToNew(players1, players3, vid2);
            AddToNew(players2, players3, vid2);


            PrintBasketBallersCont(CFr, players3, "Naujasis masyvas su formuotas iš krepšininkų kurie yra aukštesni už vidurkį");
            richTextBox1.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            

        }

        //action of "Rikiuoti" click

        private void sort_Click(object sender, EventArgs e)
        {
            players3.SortArray();
            PrintBasketBallersCont(CFr, players3, "Surikiuotas masyvas");
            richTextBox1.LoadFile(CFr, RichTextBoxStreamType.PlainText);

        }

        //action of "Baigti" click

        private void end_Click(object sender, EventArgs e)
        {
            Close();
        }

        //action of "Išmesti" click

        private void remove_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            int result = Int32.Parse(value);
            RemovePlayers(players3, result);
            players3.SortArray();
            if (players3.Much == 0)
                richTextBox1.Text = "Pašalinti visi žaidejai";
            else
            {
                PrintBasketBallersCont(CFr, players3, "Galutinis žaidėjų sarašas");
                richTextBox1.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            }


        }
        /// <summary>
        /// Method reading data files
        /// </summary>
        /// <param name="fv">Reading file</param>
        /// <param name="TeamNam">Team name</param>
        /// <returns></returns>
        static Basketballers ReadBasketCont(string fv, out string TeamNam)
        {
            Basketballers BasketballersCont = new Basketballers();
            using (StreamReader file = new StreamReader(fv, Encoding.UTF8))
            {
                string line = file.ReadLine();
                TeamNam = line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] part = line.Split(';');
                    string namSur = part[0];
                    int height = int.Parse(part[1]);
                    DateTime age = DateTime.Parse(part[2]);

                    Basketballer basketballer = new Basketballer(namSur, height, age);
                    BasketballersCont.SetBasketballer(basketballer);

                }
            }
            return BasketballersCont;
        }
        /// <summary>
        /// Array print method
        /// </summary>
        /// <param name="fv">Print file</param>
        /// <param name="basketCont">Players array</param>
        /// <param name="something">Heading</param>
        static void PrintBasketBallersCont(string fv, Basketballers basketCont, string
 something)
        {
            const string top =
            "--------------------------------------------------------------\r\n"
            + " Nr. Pavardė ir vardas        Ugis        Amžius \r\n"
            + "-------------------------------------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.UTF8))
            {
                fr.WriteLine("\n " + something);
                fr.WriteLine(top);
                for (int i = 0; i < basketCont.Much; i++)
                {
                    Basketballer bst = basketCont.GetBasketballer(i);
                    fr.WriteLine("{0, 3} {1}", i + 1, bst);
                }
                fr.WriteLine("----------------------------------------------------------\n");
            }
        }
        /// <summary>
        /// Finding average age method
        /// </summary>
        /// <param name="bstkbCont">Players array</param>
        /// <returns></returns>
        static double AgeAverage(Basketballers bstkbCont)
        {
            int ave = 0;
            int hm = 0;

            for (int i = 0; i < bstkbCont.Much; i++)
            {
                Basketballer play = bstkbCont.GetBasketballer(i);
                ave = ave + play.GetAge();
                hm++;
            }
            return ave / hm;
        }
        /// <summary>
        /// Finding average height method
        /// </summary>
        /// <param name="bstkbCont">Players array</param>
        /// <returns></returns>
        static double HeightAverage(Basketballers bstkbCont)
        {
            int heig = 0;
            int hm = 0;

            for (int i = 0; i < bstkbCont.Much; i++)
            {
                Basketballer play = bstkbCont.GetBasketballer(i);
                heig = heig + play.GetHeight();
                hm++;
            }
            return heig / hm;
        }
        /// <summary>
        /// Add players to new array
        /// </summary>
        /// <param name="bstkbCont">Original array with players</param>
        /// <param name="bsktbCont1">New array with players</param>
        /// <param name="vid">vidurkis</param>
        static void AddToNew(Basketballers bstkbCont, Basketballers bsktbCont1, double vid)
        {


            for (int i = 0; i < bstkbCont.Much; i++)
            {
                Basketballer play = bstkbCont.GetBasketballer(i);
                if (play.GetHeight() > vid)
                {
                    bsktbCont1.SetBasketballer(bstkbCont.GetBasketballer(i));


                }
            }


        }
        /// <summary>
        /// Removes players form array
        /// </summary>
        /// <param name="bsktCont">Players array</param>
        /// <param name="result">Number from from app</param>
        static void RemovePlayers(Basketballers bsktCont, int result)
        {
            for (int i = 0; i < bsktCont.Much; i++)
            {
                Basketballer player = bsktCont.GetBasketballer(i);
                if (player.GetAge() > result)
                {
                    bsktCont.RemovePlayers(i);
                    i--;

                }
            }
        }


    }

}
