using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4
{
    /// <summary>
    /// Class knot
    /// </summary>
    public class Knot
    {
        
            public Basketballer Data { get; set; }
            public Knot Next { get; set; }

            public Knot() { } //empty contructor

            /// <summary>
            /// Constructor with parameters
            /// </summary>
            /// <param name="data">element data</param>
            /// <param name="addr">element address</param>
            public Knot(Basketballer data, Knot addr)
            {
                Data = data;
                Next = addr;
            }

        
    }
}
