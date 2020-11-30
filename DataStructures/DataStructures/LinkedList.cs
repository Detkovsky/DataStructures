using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedList
    {

        public int Length { get; private set; }

        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int[] array)
        {
            Length = array.Length;
            if (Length != 0)
            {
                _root = new Node(array[0]);
                Node crt = _root;
                for (int i = 1; i < Length; i++)
                {
                    crt.Next = new Node(array[i]);
                    crt = crt.Next;
                }
            }
            else
            {
                _root = null;
            }
        }

        public int this[int index]
        {
            get
            {
                CheckIndexOutOfRangeException(index);
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                CheckIndexOutOfRangeException(index);
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public void AddToTail(int value)
        {
            Node crt = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                crt = crt.Next;
            }

            Node tmp = new Node(value);
            if (Length != 0)
            {
                crt.Next = tmp;
            }
            else
            {

                _root = tmp;
            }
            Length++;
        }

        

        public void AddToHead(int value)
        {
            Node tmp = new Node(value);
            tmp.Next = _root;
            _root = tmp;
            Length++;
        }

        

        public void AddByIndex(int value, int index)
        {
            CheckIndexOutOfRangeException(index);
            if (index != 0)
            {
                Node crt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crt = crt.Next;
                }
                Node tmp = new Node(value);
                tmp.Next = crt.Next;
                crt.Next = tmp;
                Length++;
            }
            else
            {
                AddToHead(value);
            }
        }

        

        public void RemoveLastElement (int amount = 1)
        {
            if (Length > amount)
            {
                Length -= amount;
            }
            else
            {
                Length = 0;
            }
        }

        public void DeleteFirstElement(int amount = 1)
        {
            if (Length > amount)
            {
                Node crt = _root;
                for (int i = 0; i < amount - 1; i++)
                {
                    crt = crt.Next;
                }
                _root = crt.Next;
                Length -= amount;
            }
            else
            {
                Length = 0;
            }
        }

        public void DeleteByIndex(int index, int size = 1)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                DeleteFirstElement(size);
            }
            else
            {
                Node crt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crt = crt.Next;
                }

                if (size < Length - index)
                {
                    Node tmp = crt;
                    for (int i = 0; i < size; i++)
                    {
                        crt = crt.Next;
                    }
                    tmp.Next = crt.Next;
                    Length -= size;
                }
                else
                {
                    Length = index;
                }
            }
        }

        public int ReturnIndex(int element)
        {
            Node crt = _root;
            for (int i = 0; i < Length; i++)
            {
                if (crt.Value == element)
                {
                    return i;
                }
                crt = crt.Next;
            }
            throw new Exception("There is no this value index");
        }

        public void Reverse()
        {
            if (Length == 0)
            {
                return;
            }
            Node oldRoot = _root;
            Node tmp;
            while (oldRoot.Next != null)
            {
                tmp = oldRoot.Next;
                oldRoot.Next = tmp.Next;
                tmp.Next = _root;
                _root = tmp;
            }
        }
        
        private void CheckEmpty()
        {
            if (Length == 0)
            {
                throw new Exception("Empty array");
            }
        }

        public int FindMaxValue()
        {
            CheckEmpty();
            Node crt = _root;
            int max = crt.Value;
            for (int i = 0; i < Length - 1; i++)
            {
                crt = crt.Next;
                if (crt.Value > max)
                {
                    max = crt.Value;
                }
            }
            return max;
        }

        public int FindMinValue()
        {
            CheckEmpty();
            Node crt = _root;
            int min = crt.Value;
            for (int i = 0; i < Length - 1; i++)
            {
                crt = crt.Next;
                if (crt.Value < min)
                {
                    min = crt.Value;
                }
            }
            return min;
        }

        public int FindIndexOfMinValue()
        {
            CheckEmpty();
            Node crt = _root;
            int min = crt.Value;
            int minIndex = 0;
            for (int i = 0; i < Length - 1; i++)
            {
                crt = crt.Next;
                if (crt.Value < min)
                {
                    min = crt.Value;
                    minIndex = i + 1;
                }
            }
            return minIndex;
        }

        public int FindIndexOfMaxValue()
        {
            
            Node crt = _root;
            int max = crt.Value;
            int maxIndex = 0;
            for (int i = 0; i < Length - 1; i++)
            {
                crt = crt.Next;
                if (crt.Value > max)
                {
                    max = crt.Value;
                    maxIndex = i + 1;
                }
            }
            return maxIndex;
        }

        public void SortFromMinToMax()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (this[j] < this[j - 1])
                    {
                        int k = this[j];
                        this[j] = this[j - 1];
                        this[j - 1] = k;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void SortFromMaxToMin()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (this[j] > this[j - 1])
                    {
                        int k = this[j];
                        this[j] = this[j - 1];
                        this[j - 1] = k;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        
        public void AddToTail(int[] addArray)
        {
            Node crt = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                crt = crt.Next;
            }
            LinkedList linkedList = new LinkedList(addArray);
            if (Length != 0)
            {
                crt.Next = linkedList._root;
            }
            else
            {

                _root = linkedList._root;
            }

            Length += addArray.Length;
        }

        public void AddToHead(int[] addArray)
        {
            LinkedList linkedList = new LinkedList(addArray);
            Node crt = linkedList._root;
            for (int i = 0; i < addArray.Length - 1; i++)
            {
                crt = crt.Next;
            }
            if (addArray.Length != 0)
            {
                crt.Next = _root;
                _root = linkedList._root;
            }
            Length += addArray.Length;
        }

        public void DeleteFirstValue(int value)
        {
            try
            {
                int index = ReturnIndex(value);
                DeleteByIndex(index);
            }
            catch
            {
            }
        }

        public void DeleteAllValue(int value)
        {
            if (Length == 0)
            {
                return;
            }
            Node crt = _root;
            Node tmp = crt;
            while (tmp.Next != null)
            {
                if (crt.Value == value)
                {
                    if (_root.Value == crt.Value)
                    {
                        _root = crt.Next;
                    }
                    else
                    {
                        tmp.Next = crt.Next;
                    }
                    Length--;
                }
                else
                {
                    tmp = crt;
                }
                crt = crt.Next;
            }

        }

        private void CheckIndexOutOfRangeException(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

        }
    }
}

