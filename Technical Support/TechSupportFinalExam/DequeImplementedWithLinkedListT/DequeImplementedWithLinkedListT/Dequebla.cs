//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace FiratAtagun.DataStructures
//{
//    public class MyDeque<T> : IEnumerable
//    {

//        private LinkedList<T> deque;

//        public MyDeque()
//        {
//            deque = new LinkedList<T>();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns>The number of elements in the Deque</returns>
//        public int Count()
//        {
//            return deque.Count;
//        }

//        public void PushLast(int item)
//        {
//            deque.AddLast(item);
//        }

//        public void PushFirst(int item)
//        {
//            deque.AddFirst(item);
//        }

//        public int PopLast()
//        {
//            var lastItem = deque.Last;
//            deque.RemoveLast();
//            return lastItem.Value;
//        }

//        public int PopFirst()
//        {
//            var firstItem = deque.First;
//            deque.RemoveFirst();
//            return firstItem.Value;
//        }

//        public int PeekLast()
//        {
//            return deque.Last.Value;
//        }

//        public int PeekFirst()
//        {
//            return deque.First.Value;
//        }

//        public bool Contains(int item)
//        {
//            return deque.Contains(item);
//        }

//        public void Clear()
//        {
//            deque.Clear();
//        }

//        #region IEnumerable Members

//        public IEnumerator GetEnumerator()
//        {
//            return new MyDeckEnumerator(deque);
//        }

//        #endregion

//        #region IEnumerable Members

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }

//        #endregion

//        private class MyDeckEnumerator : IEnumerator
//        {

//            private readonly LinkedList<int> data;
//            private LinkedListNode<int> CurrentItem;

//            public MyDeckEnumerator(LinkedList<int> linkedList)
//            {
//                data = linkedList;
//            }

//            #region IEnumerator Members

//            public int Current
//            {
//                get { return CurrentItem.Value; }
//            }

//            #endregion

//            #region IDisposable Members

//            public void Dispose()
//            {
//                // throw new NotImplementedException();
//            }

//            #endregion

//            #region IEnumerator Members

//            object System.Collections.IEnumerator.Current
//            {
//                get { return CurrentItem.Value; }
//            }

//            public bool MoveNext()
//            {
//                if (CurrentItem != data.Last)
//                {
//                    if (CurrentItem == null)
//                    {
//                        CurrentItem = data.First;
//                        return true;
//                    }
//                    CurrentItem = CurrentItem.Next;
//                    return true;
//                }
//                return false;
//            }

//            public void Reset()
//            {
//                CurrentItem = data.First;
//            }

//            #endregion
//        }
//    }
//}