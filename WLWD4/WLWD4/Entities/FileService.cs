using System.Text.Json;
using System.Text;
using WLWD4.Interfaces;

namespace WLWD4.Entities
{
    internal class FileService : IFileService<Computer>
    {
        private List<string> extensions = new List<string>() { ".txt", ".rtf", ".dat", ".inf" };

        private Encoding encoding = Encoding.UTF8;

        private string curDir;

        private Dictionary<string, string> fileInfo;
        public FileService(string _curDir) => (curDir, fileInfo) = (_curDir, new Dictionary<string, string>());  
        public IEnumerable<Computer> ReadFile(string fileName)
        {
            if(!File.Exists(fileName))
                throw new FileNotFoundException();

            using FileStream fileStream = new FileStream(fileName, FileMode.Open);
            using BinaryReader reader = new BinaryReader(fileStream);
            byte[] byte_repres = reader.ReadBytes((int)fileStream.Length);
            string json = encoding.GetString(byte_repres);

            IEnumerable<Computer> collection = JsonSerializer.Deserialize<IEnumerable<Computer>>(json);

            foreach (Computer member in collection)
                yield return member;
        }
        public void SaveData(IEnumerable<Computer> data, string fileName)
        {
            string json = JsonSerializer.Serialize(data);

            using FileStream fileStream = new FileStream(fileName, FileMode.Create);
            using BinaryWriter writer = new BinaryWriter(fileStream);
            byte[] byte_repres = encoding.GetBytes(json);
            writer.Write(byte_repres);

        }

        public void DirectoryInit()
        {
            if (Directory.Exists(curDir))
                Directory.Delete(curDir, true);

            Directory.CreateDirectory(curDir);

            for (int i = 0; i < 10; i++)
            {
                int randInd = new Random().Next(extensions.Count);
                string fileName 
                    = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extensions.ElementAt(randInd);
                string filePath = Path.Combine(curDir, fileName);
                File.Create(filePath).Close();
            }

        }

        public Dictionary<string, string> GetFilesInfo()
        {
            string[] files = Directory.GetFiles(curDir);

            

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string fileExtention = Path.GetExtension(file);
                fileInfo.Add(fileName, fileExtention);
            }

            return fileInfo;
        }

        public Dictionary<string, List<Computer>> GetFilesData()
        {
            string[] files = Directory.GetFiles(curDir);
            Dictionary<string, List<Computer>> filesData = new Dictionary<string, List<Computer>>();

            foreach (string file in files)
            {
                filesData.Add(Path.GetFileName(file), ReadFile(file).ToList());
            }
            return filesData;
        }


            private List<Computer> GenerateObjectList(int amount)
        {
            List<Computer> objList = new List<Computer>();

            for(int i = 0; i < amount; i++)
            {
                Guid uniqueId = Guid.NewGuid();
                int id = uniqueId.GetHashCode();
                bool isAdmin = id % 2 == 1;
                string name = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                Computer temp = new Computer(id, isAdmin, name);

                objList.Add(temp);
            }
            return objList;
        }
        public void FillFiles()
        {
            foreach (var file in fileInfo)
            {
                string oldPath = Path.Combine(curDir, file.Key + file.Value);
                string newPath = Path.Combine(curDir, file.Key.ToUpper() + file.Value);
                File.Move(oldPath, newPath);

                SaveData(GenerateObjectList(6), newPath);
                
            }
        }

        public void Sort(Dictionary<string, List<Computer>> fileData)
        {
            foreach (var file in fileData)
                fileData[file.Key] = file.Value.OrderBy(computer => computer.Name).ToList();
        }

    }
}
