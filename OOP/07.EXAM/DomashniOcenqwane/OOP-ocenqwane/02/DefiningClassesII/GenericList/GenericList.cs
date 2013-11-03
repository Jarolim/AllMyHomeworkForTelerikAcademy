using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GenericList<T> where T : IComparable
{
    private T[] container;
    private int size;
    private int count = 0;
    private int lastSeqIndex = -1;
    private bool[] notEmptyIndicator;

    public GenericList(int size)
    {
        this.container = new T[size];
        this.notEmptyIndicator = new bool[size];
        this.size = size;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Index out f range");
            }
            return container[index];
        }
    }

    private bool IsFull()
    {
        if (this.count >= this.size)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Resize()
    {
        T[] tempHolder = new T[this.size];
        bool[] tempEmpty = new bool[this.size];
        for (int i = 0; i < this.size; i++)
        {
            tempHolder[i] = this.container[i];
            tempEmpty[i] = this.notEmptyIndicator[i];
        }

        this.size = this.size * 2;
        this.container = new T[this.size];
        this.notEmptyIndicator = new bool[this.size];
        for (int i = 0; i < tempHolder.Length; i++)
        {
            this.container[i] = tempHolder[i];
            this.notEmptyIndicator[i] = tempEmpty[i];
        }
    }

    private bool SequenceBefore(int beforeIndex)
    {
        for (int i = beforeIndex - 1; i >= 0; i--)
        {
            if (this.notEmptyIndicator[i] == false)
            {
                return false;
            }
        }

        return true;
    }

    private int FullAfter(int index)
    {
        for (int i = index + 1; i < this.size; i++)
        {
            if (notEmptyIndicator[i] == false)
            {
                return i;
            }
        }

        return -1;
    }

    private void Move(int insertionIndex, int firstEmptyIndex)
    {
        for (int i = firstEmptyIndex; i > insertionIndex; i--)
        {
            this.container[i] = this.container[i - 1];
            this.notEmptyIndicator[i] = this.notEmptyIndicator[i - 1];
        }
    }

    public void Add(T value)
    {
        if (IsFull() == false)
        {
            int index = lastSeqIndex + 1;
            while (index < size && notEmptyIndicator[index] == true)
            {
                index++;
            }

            if (index < size)
            {
                container[index] = value;
                notEmptyIndicator[index] = true;
                this.lastSeqIndex = index;
                this.count++;
            }
            else
            {
                Resize();
                Add(value);
            }

        }
        else
        {
            Resize();
            Add(value);
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new ArgumentException("Index out of range");
        }

        this.notEmptyIndicator[index] = false;

        if (SequenceBefore(index) == true)
        {
            this.lastSeqIndex = index - 1;
        }

        this.count--;
    }


    public void InsertAt(T value, int index)
    {
        if (index < 0 || index >= this.size)
        {
            throw new ArgumentException("Index out of range");
        }

        if (this.notEmptyIndicator[index] == false)
        {
            this.container[index] = value;
            this.notEmptyIndicator[index] = true;
            this.count++;
        }
        else
        {
            if (IsFull() == true || FullAfter(index) == -1)
            {
                Resize();
            }

            int feia = FullAfter(index);
            Move(index, feia);
            this.container[index] = value;
            this.notEmptyIndicator[index] = true;
            count++;
        }
    }

    public void Clear()
    {
        this.container = new T[this.size];
        this.notEmptyIndicator = new bool[this.size];
        this.lastSeqIndex = -1;
        this.count = 0;
    }

    public int Find(T value)
    {
        int indexOfValue = -1;
        for (int i = 0; i < this.size; i++)
        {
            if (this.container[i].CompareTo(value) == 0)
            {
                return i;
            }
        }

        return indexOfValue;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder(size * 2);
        for (int i = 0; i < size; i++)
        {
            if (this.notEmptyIndicator[i] == true)
            {
                result.Append(container[i].ToString());
                result.Append(" ");
            }
        }
        return result.ToString();
    }

    public T Max()
    {
        T max = this.container[0];
        for (int i = 1; i < size; i++)
        {
            if (this.container[i].CompareTo(max) > 0)
            {
                max = this.container[i];
            }
        }

        return max;
    }

    public T Min()
    {
        T min = this.container[0];
        for (int i = 1; i < size; i++)
        {
            if (this.container[i].CompareTo(min) < 0)
            {
                min = this.container[i];
            }
        }

        return min;
    }
}