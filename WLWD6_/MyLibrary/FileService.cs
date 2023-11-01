using System.Text.Json;
using MyLibrary.Interfaces;
using Newtonsoft.Json;

namespace MyLibrary
{
    public class FileService<T> : IFileService<T>
    {
        IEnumerable<T> IFileService<T>.ReadFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
                return list;
            }
        }

        void IFileService<T>.SaveData(IEnumerable<T> data, string fileName)
        {
            string json = JsonConvert.SerializeObject(data.ToList());
            File.WriteAllText(fileName, json);
        }
    }
}
