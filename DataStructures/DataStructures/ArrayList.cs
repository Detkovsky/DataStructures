using System;

namespace DataStructures
{
    public class ArrayList
    {
        public int[] _array;
        
        public int Length { get; private set; }

        public ArrayList()
        {
            _array = new int[5];
            Length = 0;
        }
         
        public ArrayList(int value)
        {
            _array = new int[5];
            _array[0] = value;
            Length = 1;
        }
        
        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33)];
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            Length = array.Length;
        }
        
        //добавить в конец
        public void AddToTail(int value)
        {
            if (Length >= _array.Length)
            {
                RiseSize();
            }
            _array[Length] = value;
            Length++;
        }
        
        //увелить массив
        public void RiseSize(int size = 1)
        {
            int newLength = Length;
            while (newLength < Length + size)
            {
                newLength = (int)(1 + newLength * 1.33d);
                int[] newArray = new int[newLength];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;

            }
        }
        
        // добавление в начало
        public void AddToHead(int value)
        {
            if (Length >= _array.Length)
            {
                RiseSize();
            }
            Move(_array.Length);
            _array[0] = value;
            Length++;
        }
        
        private void Move(int quantity)
        {
            int[] newArray = new int[_array.Length];
            Array.Copy(_array, 0, newArray, quantity, Length);
            _array = newArray;
        }

        
        // добавить по индексу
        public void AddByIndex(int index, int value)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length >= _array.Length)
            {
                RiseSize();
            }
            Move(_array.Length);
            _array[index] = value;
            Length++;
        }

        
        // удалить посл значение
        public void DeleteLastValue()
        {
            if (Length >= _array.Length)
            {
                RiseSize();
            }
            Length = Length - 1;
        }
        
        // удалить первый эл-т
        public void DeleteFirstValue()
        {
            if (Length >= _array.Length)
            {
                RiseSize();
            }
            for (int i = 0; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length = Length - 1;
        }
        
        //удалить по инлексу
        public void DeleteByIndex(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Length--;
            }
        }
        
        // индекс по значению
        public int TakeIndex(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
        
        //изменить по индексу
        public void ChangeByIndex(int value, int tmp)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == value - 1)
                {
                    _array[i] = tmp;
                }
            }
            if (value > Length)
            {
                throw new IndexOutOfRangeException("");
            }

        }

        //реверс
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = a;
            }
        }

        // поиск максимального
        public int FindMaxElement()
        {
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        //поиск минимального
        public int FindMinElement()
        {
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }
        
        public int FindIndexOfMaxElement()
        {
            int indexMax = 0;
            int max=_array[0]; 
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }

        public int FindIndexOfMinElement()
        {
            int indexMin = 0;
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    indexMin = i;
                }
            }
            return indexMin;
        }

        //сортировка по возрастанию
        public void SortFromMinToMax()
        {
            for (int i = 1; i < Length; i++)
            {
                int j;
                int x = _array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] < x)
                        break;

                    _array[j + 1] = _array[j];
                }
                _array[j + 1] = x;
            }
        }
        
        //сортировка по убыванию
        public void SortFromMaxToMin()
        {
            for (int i = 1; i < Length; i++)
            {
                int j;
                int x = _array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] > x)
                        break;

                    _array[j + 1] = _array[j];
                }
                _array[j + 1] = x;
            }
        }
        
        //удаление N элементов из конца
        public void DeleteFromTail(int quantity)
        {
            Length = Length - quantity;
        }
        
        //добавление массива в начало
        public void AddToHead(int[] array)
        {
            if (Length + array.Length >= _array.Length)
            {
                RiseSize(array.Length);
            }
            Move(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            Length++;
        }
        
        //добавление массива в конец
        public void AddToTail(int[] array)
        {
            if (Length + array.Length >= _array.Length)
            {
                RiseSize(array.Length);
            }
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                _array[Length + count] = array[i];
                count++;
            }
            Length += array.Length;
        }
        
        //добавление массива по индексу
        public void AddRagneByIndex(int index, int[] array)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length + array.Length >= _array.Length)
            {
                RiseSize(array.Length);
            }
            Move(_array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                _array[i + index] = array[i];
            }
            Length += array.Length;
        }
    }

}


    

