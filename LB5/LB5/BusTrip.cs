using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LB5
{
    /// <summary>
    /// Data type for bus trips
    /// </summary>
    class BusTrip : IReadable, IEquatable<BusTrip>
    {

        public string TripNumber { get; set; } //trip name
        public string Day { get; set; } // Day 
        public string DepartureTime { get; set; } //Number
        public double Cost { get; set; } //Price

        /// <summary>
        /// Empty constructor
        /// </summary>
        public BusTrip() { }

        /// <summary>
        /// Defines for to read this type of file
        /// </summary>
        /// <param name="line">line of text from imput file</param>
        public void Read(string line)
        {
            string[] parts = line.Split(';');
            TripNumber = parts[0];
            Day = parts[1];
            DepartureTime = parts[2];
            Cost = double.Parse(parts[3]);
        }

        /// <summary>
        /// Reqiured for IEqautable, defines what objects are considered equal
        /// </summary>
        /// <param name="other">Item to compare to</param>
        /// <returns> True, if Trip Name is equal</returns>
        public bool Equals(BusTrip other)
        {
            return TripNumber == other.TripNumber;
        }
        /// <summary>
        /// Prints items 
        /// </summary>
        /// <returns>string with items</returns>
        public override string ToString()
        {
            string line = string.Format("{0, -35}| {1, -20}| {2, -20}|    {3, -20}|",
                TripNumber, Day, DepartureTime, Cost);
            return line;
        }

        /// <summary>
        /// Horizontal line
        /// </summary>
        /// <returns>string returns line</returns>
        public static string HorizontalRule()
        {
            return new string('-', 120);
        }

        /// <summary>
        /// Defining names for table
        /// </summary>
        /// <returns>string formating</returns>
        public static string FieldNames()
        {
            return string.Format("{0, -35}| {1, -20}| {2, -20}| {3, -20}",
                "Marsruto numeris",
                "Savaites diena",
                "Isvykimo laikas",
                "Bilieto kaina");
        }
    }
}
