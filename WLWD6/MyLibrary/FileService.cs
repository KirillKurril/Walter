using System.Text.Json;
using MyLibrary.Interfaces;

namespace MyLibrary
{
    public class FileService<T> : IFileService<T>
    {
        IEnumerable<T> IFileService<T>.ReadFile(string fileName)
        {
            string json = File.ReadAllText(fileName);
            List<T> list = JsonSerializer.Deserialize<List<T>>(json);
            return list ?? new List<T>();
        }

        void IFileService<T>.SaveData(IEnumerable<T> data, string fileName)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);
        }
    }
}
