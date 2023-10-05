namespace _253504_dmi_Lab5.Interfaces
{
    interface ICustomCollectioin<T>
    {
        // Индексатор коллекции (без тела)
        T this[int index] { get; set; }

        void Reset();

        bool MoveNext();

        T Current();
        int Count { get; }

        void Add(T item);

        void Remove(T item);

        void RemoveCurrent();
    }
}