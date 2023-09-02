namespace Interface
{
    interface ICustomCollectioin<T>
    {
        // Индексатор коллекции (без тела)
        T this[int index] { get; set; }

        void Reset();

        void Next();

        T Current();
        int Count { get; }

        void Add(T item);

        void Remove(T item);

        T RemoveCurrent();
    }
}