using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW1
{
    public class CollectionGeneric<T> : IEnumerable<T> where T : IComparable
    {
        private T[] _data = new T[10];
        private int _count = 0;
        public int Count()
        {
            return _count;
        }
        public void Sort()
        {
            Array.Sort(_data, 0, _count);
        }
        public void Add(T item)
        {
            if (_count == _data.Length)
            {
                Array.Resize(ref _data, _data.Length * 2);
            }
            _data[_count] = item;
            _count++;
        }
        public void SetDefaultAt(int index)
        {
            if (index < _count)
            {
                _data[index] = default(T);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionGenericEnumerator<T>(_data, _count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class CollectionGenericEnumerator<T> : IEnumerator<T>
        {
            private T[] _data;
            private int _index = -1;
            private int _count;
            public CollectionGenericEnumerator(T[] data, int count)
            {
                _data = data;
                _count = count;
            }
            public T Current
            {
                get
                { 
                    return _data[_index];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _data = null;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
