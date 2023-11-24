using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class StreamService<T>
    {
        public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
        {
            progress.Report($"Writing from data to thread {Thread.CurrentThread.ManagedThreadId} has started");

            lock ( stream )
            {
                JsonSerializer.Serialize(stream, data);
            }
            /*await Task.Delay(3000);*/
            progress.Report($"Writing from data to thread {Thread.CurrentThread.ManagedThreadId} has ended");
        }

        public async Task CopyFromStreamAsync(Stream stream, string fileName, IProgress<string> progress)
        {
            progress.Report($"Copying of data from the file in thread {Thread.CurrentThread.ManagedThreadId} has started");
            await using (var file = File.OpenWrite(fileName))
            {
                stream.Position = 0;
                lock(stream)
                {
                    stream.CopyToAsync(file);
                }
            }
            progress.Report($"Copying of data from the file in thread {Thread.CurrentThread.ManagedThreadId} is ended");

        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
        {
            List<T> filtredObjects = new List<T>();
            using (var file = File.OpenRead(fileName))
            {
                filtredObjects = JsonSerializer.Deserialize<List<T>>(file);
            }
            return filtredObjects.Where(filter).Count();
        }
    }
}
