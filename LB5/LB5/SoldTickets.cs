using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB5
{
    /// <summary>
    /// Sold tickets data type
    /// </summary>
    public class SoldTickets : IReadable
    {
        public string Name { get; set; } //Name
        public string SurName { get; set; } //Surname
        public string DayW { get; set; } //Day
        public string DepartureTimes { get; set; } //Departure times
        public double PriceForTicket { get; set; } //Price

        public string TripNumber { get; set; } // Trip number

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SoldTickets() { }

        /// <summary>
        /// IReadable defining how to read this type
        /// </summary>
        /// <param name="line">line of text from imput file</param>
        public void Read(string line)
        {
            string[] part = line.Split(';');
            Name = part[0];
            SurName = part[1];
            DayW = part[2];
            DepartureTimes = part[3];
            PriceForTicket = double.Parse(part[4]);
            TripNumber = part[5];
        }

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns>string with objects</returns>
        public override string ToString()
        {
            string line = string.Format("{0, -35}| {1, -20}| {2, -20}|    {3,-20} | {4,-20} | {5,-20}",
                Name,
                SurName,
                DayW,
                DepartureTimes,
                PriceForTicket,
                TripNumber);
            return line;
        }

        /// <summary>
        /// Horizontal line
        /// </summary>
        /// <returns>String horizontal line</returns>
        public static string HorizontalRule()
        {
            return new string('-', 150);
        }

        /// <summary>
        /// Defines the field names for table printing
        /// </summary>
        /// <returns>Names for table</returns>
        public static string FieldNames()
        {
            return string.Format("{0, -35}| {1, -20}| {2, -20}| {3, -20} | {4,-20} | {5,-20} | ",
                "Vardas",
                "Pavardė",
                "Savaites diena",
                "Isvykimo laikas",
                "Bilieto kaina",
                "Marsruto numeris");
        }

    }
}
