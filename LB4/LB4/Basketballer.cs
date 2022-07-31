using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4
{
    /// <summary>
    /// Data class
    /// </summary>
    public sealed class Basketballer
    {
        public string NameSur { get; set; } // Name and surname of the player
        public int Height { get; set; } // Players height
        public int Age { get; set; } //Players age

        /// <summary>
        /// Class object constructor with parameters
        /// </summary>
        /// <param name="name">Name and surname</param>
        /// <param name="heigth">Height</param>
        /// <param name="ag">Age</param>
        public Basketballer(string name= "", int heigth = 0,DateTime ag = new DateTime())
        {
            NameSur = name;
            Height = heigth;
            Age = DateTime.Now.Year - ag.Year;
        }

        /// <summary>
        /// Sorting operator
        /// </summary>
        /// <param name="a">Player to compare</param>
        /// <param name="b">Another player to compare</param>
        /// <returns>True, if a has more age then b</returns>
        public static bool operator >(Basketballer a, Basketballer b)
        {

            return a.Age > b.Age;
        }

        /// <summary>
        /// Sorting operator
        /// </summary>
        /// <param name="a">Player to compare</param>
        /// <param name="b">Another player to compare</param>
        /// <returns>True, if a has less age then , b</returns>
        public static bool operator <(Basketballer a, Basketballer b)
        {

            return a.Age < b.Age;
        }

        /// <summary>
        /// To string method 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line = string.Format("{0, -30}{1, -15}{2, 2}" , NameSur, Height, Age);
            return line;
        }




    }
}
