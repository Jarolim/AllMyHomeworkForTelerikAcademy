using System;
using System.Text;

namespace _05GenericClass
{
    public class GenericListClass<T>
    {
        const int BaseCapacity = 5;
        private T[] elementsList;
        private int count = 0;

        public GenericListClass() : this(BaseCapacity)
	    {
	    }

        public GenericListClass(int capacity)  // constructor with arr capacity entered by the user
        {
            this.elementsList = new T[capacity];
        }

        public void Add(T element)
        {
            if (count >= elementsList.Length) // if array is full
            {
                AutoArrayGrow();   // problem 6, increace the array size so that the new element will be added
            }
            this.elementsList[count] = element;
            count++;
        }

        public T this[int index]          // get the element by index
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                T result = elementsList[index];
                return result;
            }
        }

        public void Remove(int index)
        {
            if (index > count) 
            {
                throw new IndexOutOfRangeException(String.Format("Index out of range!")); 
            }
            for (int i = index; i < (elementsList.Length - 1); i++)
            {
                elementsList[i] = elementsList[i + 1];
            }
            count--;
        }

        public void InsertElement(int index, T element)
        {
            if (index > count)
            {
                throw new IndexOutOfRangeException(String.Format("Index out of range!"));
            }
             if (index == count) // if array is full
            {
                AutoArrayGrow();  // from problem 6, the array is increased to receive the extra element
            }

            T buffer;
            T blank = default(T);
            for (int i = index; i < (elementsList.Length - 1); i++)
            {
                if (elementsList[index + 1].Equals(blank))
                {
                    buffer = elementsList[i + 1];
                    elementsList[i + 1] = elementsList[i];
                    break;
                }
                buffer = elementsList[i + 1];
                elementsList[i + 1] = elementsList[i];              
            }

            elementsList[index] = element;
            count++;
        }

        public void Clear()
        {
            for (int i = count; i >= 0; i--)
            {
                elementsList[i] = default (T);               
            }
            count = 0;                     // restarting the count /list is cleared/
        }

        public int FindByValue(T element)
        {
            int index = Array.IndexOf(elementsList, element);
            return index; 
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(elementsList[i] + "\n");
            }
            return result.ToString();
        }

        // problem 6

        private void AutoArrayGrow()
        {
            int length = elementsList.Length;
            length *= 2;
            T[] tempArr = new T[length];
            Array.Copy(elementsList, tempArr, elementsList.Length);
            elementsList = tempArr;
        }

        // problem 7 Min<T>() and Max<T>()

        public T Min<T>() where T : IComparable
        {
            if (count == 0)
            {
                throw new InvalidOperationException(String.Format("There are no elements in the array!"));
            }

            dynamic buffer = elementsList[0];
            
            for (int i = 1; i < count; i++)
            {
                if (buffer >= elementsList[i])
                {
                    buffer = elementsList[i];
                }
            }
            return buffer;
        }

        public T Max<T>() where T : IComparable
        {
            if (count == 0)
            {
                throw new InvalidOperationException(String.Format("There are no elements in the array!"));
            }

            dynamic buffer = elementsList[0];

            for (int i = 1; i < count; i++)
            {
                if (buffer <= elementsList[i])
                {
                    buffer = elementsList[i];
                }
            }
            return buffer;
        }
     }
}
