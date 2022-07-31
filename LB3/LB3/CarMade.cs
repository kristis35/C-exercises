using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB3
{
    /// <summary>
    /// Car made class
    /// </summary>
    public class CarMade : Automobile
    {
        /// <summary>
        /// Modle string
        /// </summary>
        public string Model { get; set; }


        /// <summary>
        /// Clear constructor
        /// </summary>
        public CarMade()
        {

        }
        /// <summary>
        /// full constructor
        /// </summary>
        /// <param name="num">Numbet plate</param>
        /// <param name="prod">Production</param>
        /// <param name="mod">Model</param>
        /// <param name="agee">Car age</param>
        /// <param name="tehage">Technical Age</param>
        /// <param name="fuell">Fuel Type</param>
        /// <param name="avgfuel">Average fuel</param>
        public CarMade(string num, string prod, string mod, DateTime agee, DateTime tehage, string fuell, double avgfuel)
                      : base(num, prod, agee, tehage, fuell, avgfuel)
        {
            Model = mod;
            FuelCalc();
        }
        /// <summary>
        /// To string method
        /// </summary>
        /// <returns>Lina</returns>
        public override string ToString()
        {
            string line;
            line = string.Format("{0,-9} {1,7}", Model, base.ToString());
            return line;
        }


        /// <summary>
        /// Calculates Average fuel cost
        /// </summary>
        public override void FuelCalc()
        {
            AvgFuel = AvgFuel + 0.10;


        }
    }
}
