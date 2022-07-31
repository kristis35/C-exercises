using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LB4
{
    /// <summary>
    /// Conteiner class
    /// </summary>
    public class BasketballerData : IEnumerable // foreach 
    {
        private Knot strt; // First element
        private Knot end; // Last elemnt

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public BasketballerData()
        {
            strt = null;
            end = null;
        }

        
        /// <summary>
        /// Going through the list with foreach
        /// </summary>
        /// <returns> list elements data</returns>
        public IEnumerator GetEnumerator()
        {
            for(Knot first = strt; first != null; first = first.Next )
            {
                yield return first.Data;
            }
        }
        /// <summary>
        /// inserts an element in the front of the list
        /// </summary>
        /// <param name="bskt">inserted element</param>
        public void SetDataFront(Basketballer bskt)
        {
            var play = new Knot(bskt, null);
            play.Next = strt;
            strt = play;
        }
        /// <summary>
        /// inserts an element in the end of the list
        /// </summary>
        /// <param name="bskt">Inseted element</param>
        public void SetDataBack(Basketballer bskt)
        {
            var element = new Knot(bskt, null);
            if (strt != null)
            {
                end.Next = element;
                end = element;
            }
            else
            {
                strt = element;
                end = element;
            }
        }
        /// <summary>
        /// For checking if list is empty
        /// </summary>
        /// <returns>True if list is empty</returns>
        public bool IsEmpty()
        {
            if (strt == null)
                return true;
            return false;
        }
        /// <summary>
        /// Bubble sorting algorithm
        /// </summary>
        public void BubbleSort()
        {
            bool hit = true;
            Knot element1, element2;
            while (hit)
            {
                hit = false;
                element1 = element2 = strt;
                while (element2 != null)
                {
                    if (element2.Data > element1.Data)
                    {
                        Basketballer holder = element1.Data;
                        element1.Data = element2.Data;
                        element2.Data = holder;
                        hit = true;
                    }
                    element1 = element2;
                    element2 = element2.Next;
                }
            }
        }

        /// <summary>
        /// Remove method
        /// </summary>
        /// <param name="ageLimit">age limit imput</param>
        public void Remove(int ageLimit)
        {
            Knot play = strt;
            Knot holder;
            while (play.Next != null)
            {
                holder = play.Next;
                if (holder.Data.Age > ageLimit)
                {
                    play.Next = holder.Next;
                    holder = null;
                }
                else
                {
                    play = play.Next;
                }
            }

            if (strt.Data.Age > ageLimit)
            {
                play = strt;
                strt = strt.Next;
                play.Next = null;
                play = null;
            }
        }

        
    }
}
