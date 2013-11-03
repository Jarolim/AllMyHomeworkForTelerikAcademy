using System;
using System.Collections.Generic;

public class MyDeque<T>
{

    public LinkedList<T> data;

    public MyDeque()
    {
        data = new LinkedList<T>();
    }

    /// <summary>
    /// returns the number of elements in the Deque
    /// </summary>
    public int Count()
    {
        return data.Count;
    }

    /// <summary>
    /// inserts element at the end of the Deque
    /// </summary>
    /// <param name="item">index of the item</param>
    public void PushLast(T item)
    {
        data.AddLast(item);
    }

    /// <summary>
    /// inserts element at the beginning of the Deque
    /// </summary>
    /// <param name="item">index of the item</param>
    public void PushFirst(T item)
    {
        data.AddFirst(item);
    }

    /// <summary>
    /// removes and returns the element at the end of the Deque
    /// </summary>
    public T PopLast()
    {
        var lastItem = data.Last;
        data.RemoveLast();
        return lastItem.Value;
    }

    /// <summary>
    /// removes and returns the element at the beginning of the Deque
    /// </summary>
    public T PopFirst()
    {
        var firstItem = data.First;
        data.RemoveFirst();
        return firstItem.Value;
    }

    /// <summary>
    /// returns the element at the end of the Deque without removing it
    /// </summary>
    public T PeekLast()
    {
        return data.Last.Value;
    }

    /// <summary>
    /// returns the element at the beginning of the Deque without removing it
    /// </summary>
    public T PeekFirst()
    {
        return data.First.Value;
    }

    /// <summary>
    /// clears the Deque. It will be empty after this operation completes
    /// </summary>
    public void Clear()
    {
        data.Clear();
    }

    /// <summary>
    /// returns true if this collection contains the specified element
    /// </summary>
    /// <param name="item">the specified element</param>
    public bool Contains(T item)
    {
        return data.Contains(item);
    }
}
