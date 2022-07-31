using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB3
{
    /// <summary>
    /// Automobile calss
    /// </summary>
    abstract public class Automobile : IComparable<Automobile>, IEquatable<Automobile>
    {

        public string Numb { get; set; }
        public string Produc { get; set; }
        public int Age { get; set; }
        public int TehAge { get; set; }
        public string Fuel { get; set; }
        public double AvgFuel { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="num">Number plate</param>
        /// <param name="prod">Production</param>
        /// <param name="agee">Car Age</param>
        /// <param name="tehage">Teh age</param>
        /// <param name="fuell">Fuel type</param>
        /// <param name="avgfuel">Average fuel</param>
        public Automobile(string num, string prod, DateTime agee, DateTime tehage, string fuell, double avgfuel)
        {
            Numb = num;
            Produc = prod;
            Age = DateTime.Now.Year - agee.Year;
            TehAge = DateTime.Now.Year - tehage.Year;
            Fuel = fuell;
            AvgFuel = avgfuel;
        }
        /// <summary>
        /// Clear constructor
        /// </summary>
        public Automobile()
        {

        }

        /// <summary>
        /// Methods to define object equality terms
        /// </summary>
        public override bool Equals(object obj)
        {
            Automobile other = (Automobile)obj;
            return Equals(other);
        }
        public bool Equals(Automobile other)
        {
            return string.Equals(Produc, other.Produc);
        }
        public override int GetHashCode()
        {
            return Produc.GetHashCode();
        }

        /// <summary>
        /// to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line;
            line = string.Format("{0,12} {1,22} {2,18} {3, 18} {4,23} {5,15}", Numb, Produc,Age, TehAge, Fuel, AvgFuel);
            return line;
        }
        /// <summary>
        /// Compare to method
        /// </summary>
        /// <param name="other">Obeject</param>
        /// <returns>1 or -1</returns>
        public int CompareTo(Automobile other)
        {

            int poz = String.Compare(this.Numb, other.Numb, StringComparison.CurrentCulture);
            if ((this.Age > other.Age) || ((this.Age == other.Age) && (poz > 0)))
                return 1;
            else
                return -1;
        }

        /// <summary>
        /// Abstract method for calculating fuel cost
        /// </summary>
        abstract public void FuelCalc();



    }
}
