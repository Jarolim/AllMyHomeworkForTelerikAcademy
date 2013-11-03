using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableSample
{
    public class HashTable<K, T> : IEnumerable
    {
        private LinkedList<KeyValuePair<K, T>>[] hashTable;

        public HashTable()
        {
            this.Capacity = 8;
            this.Count = 0;
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new HashTableEnumerator<K, T>(hashTable);
        }

        public void Add(K key, T value)
        {
            int hashedKey = this.GenerateIndex(key);

            if (this.Count > ((this.Capacity / 100.0) * 75))
            {
                this.IncreaseCapacity();
            }

            if (this.hashTable[hashedKey] == null)
            {
                this.hashTable[hashedKey] = new LinkedList<KeyValuePair<K, T>>();
                this.hashTable[hashedKey].AddFirst(new KeyValuePair<K, T>(key, value));
            }
            else
            {
                this.hashTable[hashedKey].AddAfter(this.hashTable[hashedKey].Last, new KeyValuePair<K, T>(key, value));
            }

            this.Count++;
        }

        public void Remove(K key)
        {
            int hashedIndex = this.GenerateIndex(key);
            // The != operator should be replaced ! Equals() method, because u cant compare generics
            if (this.hashTable[hashedIndex].Count == 1 && !this.hashTable[hashedIndex].First.Equals(key))
            {
                throw new ArgumentException("Key was not found in the hash-table.");
            }
            //// The == operator should be replaced Equals() method also
            else if (this.hashTable[hashedIndex].Count == 1 && this.hashTable[hashedIndex].First.Equals(key))
            {
                this.hashTable[hashedIndex].RemoveFirst();
                this.hashTable[hashedIndex] = null;
            }
            else
            {
                var node = this.hashTable[hashedIndex].First;

                while (!node.Value.Key.Equals(key))
                {
                    node = node.Next;
                }

                this.hashTable[hashedIndex].Remove(node);
            }

            this.Count--;
        }

        public T Find(K key)
        {
            int hashedIndex = this.GenerateIndex(key);

            if (this.hashTable[hashedIndex].Count == 1)
            {
                return this.hashTable[hashedIndex].First.Value.Value;
            }
            else
            {
                var node = this.hashTable[hashedIndex].First;

                while (!node.Value.Key.Equals(key))
                {
                    node = node.Next;
                }

                return node.Value.Value;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value cannot be null or empty.");
                }

                int hashedIndex = this.GenerateIndex(key);

                if (this.hashTable[hashedIndex].Count == 1)
                {
                    KeyValuePair<K, T> nextPair = new KeyValuePair<K, T>(key, value);
                    this.hashTable[hashedIndex].First.Value = nextPair;
                }
                else
                {
                    var node = this.hashTable[hashedIndex].First;

                    while (!node.Value.Key.Equals(key))
                    {
                        node = node.Next;
                    }

                    KeyValuePair<K, T> nextPair = new KeyValuePair<K, T>(key, value);
                    node.Value = nextPair;
                }
            }
        }

        public void Clear()
        {
            this.Count = 0;
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[this.Capacity];
        }

        private void IncreaseCapacity()
        {
            var newCapacity = Capacity * 2;

            LinkedList<KeyValuePair<K, T>>[] copiedArray = new LinkedList<KeyValuePair<K, T>>[newCapacity];

            for (int i = 0; i < this.hashTable.Length; i++)
            {
                copiedArray[i] = this.hashTable[i];
            }

            ReAddValues(copiedArray, Capacity);
        }

        private int GenerateIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % this.hashTable.Length);
        }

        private void ReAddValues(LinkedList<KeyValuePair<K, T>>[] copiedArray, int capacity)
        {
            this.Capacity = capacity;
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[this.Capacity];
            this.Count = 0;

            for (int i = 0; i < copiedArray.Length; i++)
            {
                if (copiedArray[i] != null)
                {
                    LinkedList<KeyValuePair<K, T>> list = copiedArray[i];
                    
                    // This code should be replaced with this one because it's going into deep recursion 
                    // and it's could creating perfomance issue
                    foreach (var keyValuePair in list)
                    { 
                        int index = GenerateIndex(keyValuePair.Key);

                        if (hashTable[index] == null)
                        {
                            hashTable[index] = new LinkedList<KeyValuePair<K, T>>();
                        }

                        this.hashTable[index].AddLast(keyValuePair);
                    }
                }
            }
        }
    }
}
