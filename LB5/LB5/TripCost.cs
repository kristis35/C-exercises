using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB5
{
    /// <summary>
    /// Datatype for stroing Trip name price and coun
    /// </summary>
    public class TripCost : IEquatable<TripCost>
    {
        public string TripNam { get; set; } //Trip name
        public double Price { get; set; } //Trip price
        public int Count { get; set; } //Repetitions

        // Empty constructor
        public TripCost() { }

        // Constructor with parameters
        public TripCost(string tripname,double price,int count)
        {
            TripNam = tripname;
            Price = price;
            Count = count;
        }

        /// <summary>
        /// Required for IEquatable
        /// </summary>
        /// <param name="other">Item to compare to</param>
        /// <returns>True if Tripname is equal</returns>
        public bool Equals(TripCost other)
        {
            return TripNam == other.TripNam;
        }

        /// <summary>
        /// Prints Trip Name and price
        /// </summary>
        /// <returns>string with tripname and price</returns>
        public override string ToString()
        {
            return TripNam + "-" + Price;
        }

        /// <summary>
        /// Logic operator greater or equal
        /// </summary>
        /// <param name="a">item a</param>
        /// <param name="b">item b</param>
        /// <returns>true if object a property count is greater or equal</returns>
        public static bool operator >=(TripCost a, TripCost b)
        {
            return a.Count >= b.Count;
        }

        /// <summary>
        /// Logic operator greater or equal
        /// </summary>
        /// <param name="a">item a</param>
        /// <param name="b">item b</param>
        /// <returns>true if object a property count is greater or equal</returns>
        public static bool operator <=(TripCost a, TripCost b)
        {
            return a.Count <= b.Count;
        }

        

        
    }
}
