using WLWD4.Entities;

namespace WLWD4.Interfaces
{
    interface IFileService<T> where T : class
    {
        IEnumerable<T> ReadFile(string fileName);
        void SaveData(IEnumerable<T> data, string fileName);
        void DirectoryInit();
        Dictionary<string, string> GetFilesInfo();
        void FillFiles();
        void Sort(Dictionary<string, List<T>> fileData);
    }
}
