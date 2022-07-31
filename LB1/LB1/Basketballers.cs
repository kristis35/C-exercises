using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1
{
    /// <summary>
    /// Conteiner class
    /// </summary>
    class Basketballers
    {


        const int Cn = 500;
        private Basketballer[] Bskt;
        public int Much { get; set; }
        /// <summary>
        /// Array stats
        /// </summary>
        public Basketballers()
        {
            Much = 0;
            Bskt = new Basketballer[Cn];
        }
        /// <summary>
        /// Get player by index
        /// </summary>
        /// <param name="i">index</param>
        /// <returns></returns>
        public Basketballer GetBasketballer(int i) { return Bskt[i]; }
        /// <summary>
        /// Player set to array
        /// </summary>
        /// <param name="bskt">Player with his stats</param>
        public void SetBasketballer(Basketballer bskt) { Bskt[Much++] = bskt; }
        /// <summary>
        /// Sorts array
        /// </summary>
        public void SortArray()
        {
            for (int i = 0; i < Much - 1; i++)
            {
                Basketballer max = Bskt[i];
                int maxIndex = i;
                for (int j = i + 1; j < Much; j++)
                {
                    if (Bskt[j] > max)
                    {
                        max = Bskt[j];
                        maxIndex = j;
                    }
                }
                Bskt[maxIndex] = Bskt[i];
                Bskt[i] = max;
            }
        }
        /// <summary>
        /// Removes players for array
        /// </summary>
        /// <param name="index">Indeksas kuri reikia žaidėja išmesti</param>
        public void RemovePlayers(int index)
        {

            for (int i = index; i < Much - 1; i++)
            {
                Bskt[i] = Bskt[i + 1];
            }
            Much = Much - 1;

        }


    }
}
