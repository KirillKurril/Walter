using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class StreamService<T>
    {
        public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data/*, IProgress<string> progress*/)
        {

            await Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("МЕНЯ ЕБАЛИ ТУ ТУН ТУН");
            });
            
        }

        public async Task CopyFromStreamAsync(Stream stream, string filename, IProgress<string> progress)
        {

        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<T, bool> filter)
        {
            return 0;
        }
    }
}
