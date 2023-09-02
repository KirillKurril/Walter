using Interface;

namespace Collection
{
    class MyCustomCollection<T> : ICustomCollectioin<T>
    {
        private T[]? _items = null;

        private int _currentIndex = -1;

        public MyCustomCollection(int capacity)
        {
            _items = new T[capacity];

            _currentIndex = 0;
        }
        T this[int index] 
        {
            get
            {
                if (_currentIndex >= 0 && _currentIndex < _items.Length)
                {
                    return _items[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (_currentIndex >= 0 && _currentIndex < _items.Length)
                {
                    _items[index] = value;
                }
                throw new IndexOutOfRangeException();
            }

        void Reset();

        void Next();

        T Current();
        int Count { get; }

        void Add(T item);

        void Remove(T item);

        T RemoveCurrent();
    }
}
