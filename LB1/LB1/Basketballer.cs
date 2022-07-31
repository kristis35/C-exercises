using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    /// <summary>
    /// Class player with stats
    /// </summary>

    class Basketballer
    {
        /// <summary>
        /// Player stats
        /// </summary>
        public string NameSur { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }

        public Basketballer(string nams, int hgt, DateTime ag)
        {
            NameSur = nams;
            Height = hgt;
            Age = DateTime.Now.Year - ag.Year;

        }


        /// <summary>
        /// Get players stats
        /// </summary>
        /// <returns></returns>
        public string GetNameSur() { return NameSur; }
        public int GetHeight() { return Height; }
        public int GetAge() { return Age; }

        /// <summary>
        /// Printi method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-25} {1, -3} {2,12}", NameSur, Height, Age);
            return eilute;
        }
        /// <summary>
        /// Operators for sorting 
        /// </summary>
        /// <param name="p1">First player</param>
        /// <param name="p2">Second player</param>
        /// <returns></returns>
        public static bool operator >(Basketballer p1, Basketballer p2)
        {


            return p1.Age > p2.Age;
        }
        /// <summary>
        /// Operators for sorting 
        /// </summary>
        /// <param name="p1">First player</param>
        /// <param name="p2">Second player</param>
        /// <returns></returns>
        public static bool operator <(Basketballer p1, Basketballer p2)
        {


            return p1.Age < p2.Age;
        }

    }
}
