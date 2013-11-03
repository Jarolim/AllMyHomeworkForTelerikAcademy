using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EShop
{
    public class ProductsList : IEnumerable
    {
        private List<Product> elements;

        public int Length
        {
            get { return this.elements.Count; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input! You should enter non-negative integer number.");
                }
            }
        }

        public ProductsList(int length = 4)
        {
            this.Length = length;
            this.elements = new List<Product>(length);
        }

        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentException(
                        string.Format("Invalid input! You should enter index between 0 and {0}.", this.Length - 1));
                }
                return this.elements[index];
            }
            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentException(
                        string.Format("Invalid input! You should enter index between 0 and {0}.", this.Length - 1));
                }
                this.elements[index] = value;
            }
        }

        public int Find(int productID)
        {
            int index = -1;
            for (int count = 0; count < this.elements.Count; count++)
            {
                if (productID.Equals(this.elements[count].ProductID))
                {
                    index = count;
                }
            }
            return index;
        }

        public void Remove(Product product)
        {
            this.elements.Remove(product);
        }

        public void RemoveAt(int index)
        {
            this.elements.RemoveAt(index);
        }

        public void Add(Product product)
        {
            this.elements.Add(product);
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return (elements as IEnumerable).GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (Product product in this.elements)
            {
                result.AppendLine(product.ToString());
            }
            return result.ToString();
        }
    }
}