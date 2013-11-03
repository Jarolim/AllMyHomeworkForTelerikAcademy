using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T> where T : IComparable
    {
        private int length;
        private int currentElement;
        private T[] genericList;
        private bool[] filled;
        private int count;

        /// <summary>
        /// initializes the collection by given lenght
        /// </summary>
        /// <param name="lenght"></param>
        public GenericList(int lenght)
        {
            this.length = lenght;
            this.currentElement = 0;
            this.Initialize();
            
        }

        /// <summary>
        /// Clears/Initializes the collection with the default literal for <T>
        /// </summary>
        public void Initialize()
        {
            if (this.Length > 0)
            {
                this.genericList = new T[this.Length];
                this.filled = new bool[this.Length];
            }
            else
            {
                this.genericList = new T[1];
                this.filled = new bool[1];
            }
        }

        /// <summary>
        /// Returns the capacity of the collection
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }
        }

        /// <summary>
        /// Gives the number of filled elements of the collection
        /// </summary>
        public int Count
        {
            get
            {
                //int count = 0;
                //if (this.filled.Length==0)
                //{
                //    return count;
                //}
                //while (this.filled[count] == true)
                //{
                //    count++;
                //    if (count == this.filled.Length)
                //    {
                //        count--;
                //        return count;
                //    }
                //}
                return this.count;
            }            
        }

        /// <summary>
        /// Property for accessing the index at current position and for incrementing it with 1
        /// </summary>
        private int CurrentElement
        {
            get
            {
                return this.currentElement;
            }
            set
            {
                if (currentElement == this.Length - 1)
                {
                    GenericList<T> widerCollection = new GenericList<T>(2 * this.Length);
                    bool[] widerFilled = new bool[2 * this.Length];
                    for (int i = 0; i < this.Length; i++)
                    {
                        widerCollection[i] = this.genericList[i];
                        widerFilled[i] = this.filled[i];
                    }
                    this.genericList = widerCollection.genericList;
                    this.filled = widerFilled;
                    this.length = 2 * this.Length;

                }
                this.currentElement++;
            }
        }

        /// <summary>
        /// Indexer for the class
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= length)
                {
                    this.ExceptionMethod();
                }
                return genericList[index];
            }
            set
            {
                if (index >= 0 && index < length)
                {
                    this.genericList[index] = value;
                    this.filled[index] = true;
                }
                else
                {
                    this.ExceptionMethod();
                }
            }
        }

        /// <summary>
        /// adds an element at the end of the collection
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (this.Count > 0)
            {
                do
                {
                    if (this.filled[this.CurrentElement] == true)
                    {
                        this.CurrentElement++;
                    }
                    else
                    {
                        break;
                    }
                } while (this.CurrentElement < this.Length);
            }            
            this.genericList[this.CurrentElement] = element;
            this.filled[this.currentElement] = true;
            this.count ++;
            this.CurrentElement++;
        }

        /// <summary>
        /// Removes element in position
        /// </summary>
        /// <param name="index">Which element to remove</param>
        public void Remove(int index)
        {
            if (index < this.length)
            {
                for (int i = index; i < this.length - 1; i++)
                {
                    genericList[i] = genericList[i + 1];
                }
                genericList[this.length - 1] = default(T);
            }
            else
            {
                this.ExceptionMethod();
            }

        }

        /// <summary>
        /// Inserts an element at given position moving all elements from that poin to the end one position to the right (meaning towards the end of the collection). Last element is lost
        /// </summary>
        /// <param name="element"></param>
        /// <param name="index"></param>
        public void InsertAt(T element, int index)
        {
            if (index < 0 || index >= this.length)
            {
                this.ExceptionMethod();
            }
            else
            {
                for (int i = this.length - 1; i > index; i--)
                {
                    this.genericList[i] = this.genericList[i - 1];
                }
                this.genericList[index] = element;
            }
        }
               
        /// <summary>
        /// Gets the index of the firs occurence of the element
        /// </summary>
        /// <param name="element">What to search for</param>
        /// <returns>Index of elemnent if exists - else => -1</returns>
        public int IndexOf(T element)
        {
            int result = -1;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i].CompareTo(element) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the index of the firs occurence of the element starting at give position
        /// </summary>
        /// <param name="element">What to search for</param>
        /// <param name="startIndex">Where to start</param> 
        /// <returns>Index of elemnent if exists - else => -1</returns>
        public int IndexOf(T element, int startIndex)
        {
            int result = -1;

            if (!IsInside(startIndex))
            {
                this.ExceptionMethod();
            }

            for (int i = startIndex; i < this.Length; i++)
            {
                if (this[i].CompareTo(element) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// throws exception when argument is outside boundaries of collection
        /// </summary>
        private void ExceptionMethod()
        {
            throw new ArgumentOutOfRangeException(string.Format("Index should be between [0] and [{0}]", length));
        }

        /// <summary>
        /// Checke if the index is inside the collection
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool IsInside(int index)
        {
            var isInside = true;
            if (index < 0 || index >= this.Length)
            {
                isInside = false;
            }
            return isInside;
        }

        /// <summary>
        /// Method for easy string generating from the elements in the collection 
        /// </summary>
        /// <returns>String with -[element]- new line</returns>
        public override string ToString()
        {
            StringBuilder genericListToString = new StringBuilder();
            int index = 0;
            int length = this.Count;
            while (index < length && this.filled[index] == true)
            {
                genericListToString.Append(this.genericList[index] + "\n");
                index++;
            }
            return genericListToString.ToString();

        }

        ///// <summary>
        ///// Checks if element at position index is == to element
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="element"></param>
        ///// <returns></returns>
        //public bool IsEqual(int index, T element)
        //{
        //    bool isEqual = true;
        //    if (this.genericList[index].ToString() != element.ToString())
        //    {
        //        isEqual = false;
        //    }
        //    return isEqual;
        //}

        /// <summary>
        /// Finds Max element from a given index onwards
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index">Start index</param>
        /// <returns>T</returns>
        public T Max(int index)
        {
            if (!IsInside(index))
            {
                this.ExceptionMethod();
            }
            T maxElement = this[index];
            for (int i = index; i < this.Count; i++)
            {
                if (this[i].CompareTo(maxElement) > 0)
                {
                    maxElement = this[i];
                }
            }
            return maxElement;
        }

        /// <summary>
        /// Finds the Min element from a give index onwards
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index">StartIndex</param>
        /// <returns>T</returns>
        public T Min(int index)
        {
            if (!IsInside(index))
            {
                this.ExceptionMethod();
            }

            T minElement = this[index];
            for (int i = index; i < this.Count; i++)
            {
                if (this[i].CompareTo(minElement) < 0)
                {
                    minElement = this[i];
                }
            }
            return minElement;
        }
    }
}
