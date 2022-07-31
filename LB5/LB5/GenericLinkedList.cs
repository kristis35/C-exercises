using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB5
{
    /// <summary>
    /// Custom Linked list of type T objects
    /// </summary>
    /// <typeparam name="T"> Type of dataclass </typeparam>
    public sealed class GenericLinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Node class
        /// </summary>
        /// <typeparam name="T2"> Type of data class in node </typeparam>
        private class Node<T2>
        {
            public T2 NodeData { get; set; }
            public Node<T2> NextNode { get; set; }

            public Node() { }

            public Node(T2 data, Node<T2> AddressOfNext)
            {
                NodeData = data;
                NextNode = AddressOfNext;
            }
        }

        // first list element
        private Node<T> start;

        // Empty constructor
        public GenericLinkedList() { }

        /// <summary>
        /// Adds an item to start of list (reverse list)
        /// </summary>
        /// <param name="obj"> Item to add </param>
        public void AddToStart(T obj)
        {
            var elementToAdd = new Node<T>(obj, null);
            if (start != null)
            {
                Node<T> placeholder = start;
                start = elementToAdd;
                start.NextNode = placeholder;
            }
            else
                start = elementToAdd;
        }

        /// <summary>
        /// Required for IEnumerable property, allows cycling through list with foreach
        /// </summary>
        /// <returns> IEnumerator of data in each node </returns>
        public IEnumerator GetEnumerator()
        {
            for (Node<T> pointer = start; pointer != null;
                    pointer = pointer.NextNode)
            {
                yield return pointer.NodeData;
            }
        }

        /// <summary>
        /// Checks if list is empty
        /// </summary>
        /// <returns>True, if first item is null </returns>
        public bool IsEmpty()
        {
            return start == null;
        }

        /// <summary>
        /// Checks if an item already exists in specified list
        /// </summary>
        /// <typeparam name="T2"> Type of list and object data class </typeparam>
        /// <param name="MyList"> List to search in </param>
        /// <param name="obj"> item to find </param>
        /// <returns> True, if item is already in list </returns>
        public bool Contains<T2>(GenericLinkedList<T2> MyList, T2 obj)
            where T2 : IEquatable<T2>
        {
            foreach (T2 item in MyList)
            {
                if (item.Equals(obj))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Increasing count if there is repetition
        /// </summary>
        /// <param name="TripList">Increasable items</param>
        /// <param name="item">Specific item to increase</param>
        /// <param name="amount">Number by witch to increase count</param>
        public void IncreaseRepetitionCount(
           GenericLinkedList<TripCost> TripList, TripCost item,
           int amount)
        {
            foreach (TripCost listItem in TripList)
            {
                if (listItem.Equals(item))
                {
                    listItem.Count += amount;
                }
            }
        }
        /// <summary>
        /// Method to find the highiest price
        /// </summary>
        /// <param name="PriceList">List ere to find the highiest amount</param>
        /// <returns>Returns string with highiest amount</returns>
        public TripCost HighestPrice(
           GenericLinkedList<TripCost> PriceList)
        {
            TripCost most = PriceList.start.NodeData;
            foreach (TripCost item in PriceList)
            {
                if (item.Price >= most.Price)
                {
                    most = item;
                }
            }
            return most;
        }


    }
}
