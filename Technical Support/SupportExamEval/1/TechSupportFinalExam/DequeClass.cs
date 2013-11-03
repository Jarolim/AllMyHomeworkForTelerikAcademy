using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    /// <summary>
    /// Interface IDeque providing the methods for the deque to implement
    /// </summary>
    /// <typeparam name="T">Type of elements in deque ex. int, double...</typeparam>
    public interface IDeque<T>
    {
        /// <summary>
        /// returns the number of elements in the Deque
        /// </summary>
        /// <returns>int - number of elements in the Deque</returns>
        int Count();

        /// <summary>
        /// inserts element at the beginning of the Deque;
        /// </summary>
        /// <param name="element">element to be inserted</param>
        void PushFirst(T element);

        /// <summary>
        /// inserts element at the end of the Deque;
        /// </summary>
        /// <param name="element">element to be inserted</param>
        void PushLast(T element);

        /// <summary>
        /// removes and returns the element at the beginning of the Deque;
        /// </summary>
        /// <returns>returns the first element of the Deque</returns>
        T PopFirst();

        /// <summary>
        /// removes and returns the element at the end of the Deque;
        /// </summary>
        /// <returns>returns the last element of the Deque</returns>
        T PopLast();

        /// <summary>
        /// returns the element at the beginning of the Deque without removing it;
        /// </summary>
        /// <returns>returns the first element of the Deque</returns>
        T PeekFirst();

        /// <summary>
        /// returns the element at the end of the Deque without removing it;
        /// </summary>
        /// <returns>returns the last element of the Deque</returns>
        T PeekLast();

        /// <summary>
        /// clears the Deque. It will be empty after this operation completes;
        /// </summary>
        void Clear();

        /// <summary>
        /// returns true if this collection contains the specified element;
        /// </summary>
        /// <param name="element">element to be searched in the Deque</param>
        /// <returns>true if this collection contains the element; false if not</returns>
        bool Contains(T element);
    }

    /// <summary>
    /// Class Deque, implementing IDeque interface
    /// </summary>
    /// <typeparam name="T">Type of elements in deque ex. int, double...</typeparam>
    public class Deque<T> : IDeque<T>
    {
        /// <summary>
        /// LinkedList implementation of Deque
        /// </summary>
        private LinkedList<T> deque;

        //all methods documented in the interface, check above

        /// <summary>
        /// Constructor for the Deque, no paramethers
        /// creates a deque with no fixed limit of elements
        /// </summary>
        public Deque()
        {
            deque = new LinkedList<T>();
        }

        /// <summary>
        /// returns the number of elements in the Deque
        /// </summary>
        /// <returns>int - number of elements in the Deque</returns>
        public int Count()
        {
            return deque.Count;
            //using the count method for the LinkedList
        }

        /// <summary>
        /// inserts element at the beginning of the Deque;
        /// </summary>
        /// <param name="item">element to be inserted</param>
        public void PushFirst(T item)
        {
            deque.AddFirst(item);
            //using the AddFirst method for the LinkedList
        }

        /// <summary>
        /// inserts element at the end of the Deque;
        /// </summary>
        /// <param name="item">element to be inserted</param>
        public void PushLast(T item)
        {
            deque.AddLast(item);
            //using the AddLast method for the LinkedList
        }

        /// <summary>
        /// clears the Deque. It will be empty after this operation completes;
        /// </summary>
        public void Clear()
        {
            deque.Clear();
            //using the Clear method for the LinkedList
        }

        /// <summary>
        /// returns true if this collection contains the specified element;
        /// </summary>
        /// <param name="item">element to be searched in the Deque</param>
        /// <returns>true if this collection contains the element; false if not</returns>
        public bool Contains(T item)
        {
            return deque.Contains(item);
            //using the Contains method for the LinkedList
        }

        /// <summary>
        /// returns the element at the beginning of the Deque without removing it;
        /// </summary>
        /// <returns>returns the first element of the Deque</returns>
        public T PeekFirst()
        {
            return deque.First();
            //using the First method for the LinkedList
        }

        /// <summary>
        /// returns the element at the end of the Deque without removing it;
        /// </summary>
        /// <returns>returns the last element of the Deque</returns>
        public T PeekLast()
        {
            return deque.Last();
            //using the LAst method for the LinkedList
        }

        /// <summary>
        /// removes and returns the element at the beginning of the Deque;
        /// </summary>
        /// <returns>returns the first element of the Deque</returns>
        public T PopFirst()
        {
            //using the First and RemoveFirst methods for the LinkedList
            T result = deque.First();//get the result in a variavle
            deque.RemoveFirst();//delete the first element
            return result;//return the vatiable
        }

        /// <summary>
        /// removes and returns the element at the end of the Deque;
        /// </summary>
        /// <returns>returns the last element of the Deque</returns>
        public T PopLast()
        {
            //using the Last and RemoveLast methods for the LinkedList
            T result = deque.Last();//get the result in a variavle
            deque.RemoveLast();//delete the last element
            return result;//return the vatiable
        }
    }
}

