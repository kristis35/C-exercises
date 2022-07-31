using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LB2
{
    
        /// <summary>
        /// Class player with stats
        /// </summary>
        class Basketballer : IComparable<Basketballer>
        {
            /// <summary>
            /// Player stats
            /// </summary>
            public string NameSur { get; set; }
            public int Height { get; set; }
            public int Age { get; set; }
            
        /// <summary>
        /// Basketballers array 
        /// </summary>
        /// <param name="nams">NameSur</param>
        /// <param name="hgt">Height</param>
        /// <param name="ag">Age</param>
            public Basketballer(string nams, int hgt, DateTime ag)
            {
                NameSur = nams;
                Height = hgt;
                Age = DateTime.Now.Year - ag.Year;

            }


            /// <summary>
            /// Get players stats
            /// </summary>
            /// <returns>NameSur Height Age</returns>
            public string GetNameSur() { return NameSur; }
            public int GetHeight() { return Height; }
            public int GetAge() { return Age; }

            /// <summary>
            /// Printi method
            /// </summary>
            /// <returns>eilute</returns>
            public override string ToString()
            {
                string eilute;
                eilute = string.Format("{0,-25} {1, -3} {2,12}", NameSur, Height, Age);
                return eilute;
            }
            

            /// <summary>
            /// Compare method for sorting 
            /// </summary>
            /// <param name="other">list of players</param>
            /// <returns>i or -1</returns>
            public int CompareTo(Basketballer other)
            {
                if (Age < other.Age)
                    return 1;
                else
                {
                    return -1;
                }
            }


        }
    

}

