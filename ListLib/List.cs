using System;

namespace ListLib
{
    public class List
    {

        private int _size;
        private int _capacity;
        private int[] _list;

        public int Length
        {
            get => _size;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("List Length must be greater than 0");
                }
                _size = value;
                _capacity = _size;
            }

        }

        public List()
        {
            _size = 0;
            _capacity = 5;
            _list = new int[_capacity];
        }
        public List(int length)
        {
            Length = length;
            _list = new int[_capacity];
        }

        public List(int[] mylist)
        {
            Length = mylist.Length;
            _list = mylist;
        }

        public void PushBack(int newElement)
        {

            if (++_size >= _capacity)
            {
                ListUpdate();
            }

            _list[_size] = newElement;

        }

        public void PushForward(int newElement)
        {
            InsertByIndex(0, newElement);
        }

        public void InsertByIndex(int index, int newElement)
        {
            if (index < 0 || index > ++_size)
            {
                throw new ArgumentException("index is outside the bounds of list");
            }

            if (_size >= _capacity)
            {
                ListUpdate();
            }

            for (int i = _size; i > index; --i)
            {
                _list[i] = _list[i - 1];
            }

            _list[index] = newElement;

        }

        public void PopBack()
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            --_size;
        }

        public void PopForward()
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int i = 0; i < _size; ++i)
            {
                _list[i] = _list[i + 1];
            }

            --_size;
        }

        public void PopByIndex(int index)
        {
            if (index < 0 || index > ++_size)
            {
                throw new ArgumentException("index is outside the bounds of list");
            }

            for (int i = index; i < _size; --i)
            {
                _list[i] = _list[i + 1];
            }

            --_size;
        }

        public void DeleteLast_n_Elements(int n)
        {
            if (n > +_size)
            {
                throw new ArgumentException("n is greater than the bounds of list");
            }

            if (n < 0)
            {
                throw new ArgumentException("n must be greater than 0");
            }

            _size -= n;
        }

        public void DeleteFirst_n_Elements(int n)
        {
            if (n > +_size)
            {
                throw new ArgumentException("n is greater than the bounds of list");
            }

            if (n < 0)
            {
                throw new ArgumentException("n must be greater than 0");
            }

            for (int i = 0; i < n; ++i)
            {
                PopForward();
            }
        }

        public void Delete_n_ElementsFromIndex(int index, int n)
        {
            if (index < 0 || index > ++_size)
            {
                throw new ArgumentException("index is outside the bounds of list");
            }

            if (n > +_size)
            {
                throw new ArgumentException("n is greater than the bounds of list");
            }

            if (n < 0)
            {
                throw new ArgumentException("n must be greater than 0");
            }

            for (int i = 0; i < n; ++i)
            {
                PopByIndex(index);
            }
        }

        public int GetElementByIndex(int index)
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            if (index < 0 || index > ++_size)
            {
                throw new ArgumentException("index is outside the bounds of list");
            }

            return _list[index];
        }

        public int GetIndexOfElement(int element)
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            int index = -1;
            for (int i = 0; i < _size; ++i)
            {
                if (_list[i] == element)
                {
                    index = i;
                    break;
                }

            }

            if (index == -1)
            {
                throw new ArgumentException("No element in list");
            }

            return index;
        }

        public void ChangeElementByIndex(int index, int element)
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            if (index < 0 || index > ++_size)
            {
                throw new ArgumentException("index is outside the bounds of list");
            }

            _list[index] = element;
        }

        public void ListReverse()
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int i = 0; i < _size / 2; i++)
            {
                Swap(ref _list[i], ref _list[_size - i - 1]);
            }
        }

        public int IndexOfMinElement()
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            int index = 0;
            for (int i = 0; i < _size; i++)
            {
                if (_list[i] < _list[index])
                {
                    index = i;
                }
            }

            return index;
        }

        public int IndexOfMaxElement()
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            int index = 0;
            for (int i = 0; i < _size; i++)
            {
                if (_list[i] < _list[index])
                {
                    index = i;
                }
            }

            return index;
        }

        public int MinElement()
        {
            return _list[IndexOfMinElement()];
        }

        public int MaxElement()
        {
            return _list[IndexOfMaxElement()];
        }

        public void BubbleSort(Func<int, int, bool> CompareMethod)
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int i = 0; i < _size - 1; ++i)
            {
                for (int j = 0; i < _size - j - 1; ++j)
                {
                    if (!CompareMethod(_list[j], _list[j + 1]))
                    {
                        Swap(ref _list[j], ref _list[j + 1]);
                    }
                }
            }
        }

        public void SelectionSort(Func<int, int, bool> CompareMethod)
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int i = 0; i < _size - 1; i++)
            {
                int index = i;
                for (int j = i + 1; j < _size; j++)
                {
                    if (CompareMethod(_list[j], _list[index]))
                    {
                        index = j;
                    }
                }

                if (i != index)
                {
                    Swap(ref _list[i], ref _list[index]);
                }

            }
        }

        public void InsertionSort(Func<int, int, bool> CompareMethod)
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            for (int i = 1; i < _size; ++i)
            {
                int temp = _list[i];
                int j = i - 1;
                while (j >= 0 && (CompareMethod(_list[j], temp) == false))
                {
                    _list[j + 1] = _list[j--];
                }

                _list[j + 1] = temp;
            }
        }

        public void DeleteFirstElement(int element)
        {
            PopByIndex(GetIndexOfElement(element));
        }

        public void DeleteAllElements(int element)
        {
            int count = 0;
            for (int i = 0; i < _size; ++i)
            {
                if (_list[i] == element)
                {
                    ++count;
                }
            }

            while (count > 0)
            {
                PopByIndex(GetIndexOfElement(element));
                --_size;
                --count;

            }
        }
        public void InsertListBack(int[] list)
        {
            for (int i = 0; i < list.Length; ++i)
            {
                PushBack(list[i]);
            }
        }

        public void InsertListForward(int[] list)
        {
            for (int i = 0; i < list.Length; ++i)
            {
                PushForward(list[i]);
            }
        }

        public void InsertListByIndex(int index, int[] list)
        {
            for (int i = index; i < index + list.Length; ++i)
            {
                InsertByIndex(i, list[i - index]);
            }
        }

        public void PrintList()
        {
            if (_size == 0)
            {
                throw new ArgumentException("List is empty");
            }

            foreach (int i in _list)
            {
                Console.Write($"{ i }  ");
            }
        }

        private void ListUpdate()
        {
            _capacity *= 2;
            int[] newList = new int[_capacity];
            for (int i = 0; i < _size; ++i)
            {
                newList[i] = _list[i];
            }

            _list = newList;
        }

        public static void Swap(ref int a, ref int b)
        {
            if (a != b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
        }

        public static bool Greater(int a, int b)
        {
            return a > b;
        }

        public static bool Less(int a, int b)
        {
            return a < b;
        }
    }
}
