using System;
using System.Text;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
namespace _01_Complete
{
    public class MyParallel
    {
        public static void Main()
        {
            Console.WriteLine("Starting");
            var c = new Counter();
            c.ProcessDirectory();
           
        }
        class Counter
        {
            ConcurrentDictionary<string, int> _wordCounts = new ConcurrentDictionary<string, int>();
            public Action<DirectoryInfo> ProcessDirectory()
            {
                return (dirInfo =>
                {
                    var files = dirInfo.GetFiles("*.cs").AsParallel<FileInfo>();
                    files.ForAll<FileInfo>(
                        fileInfo =>
                        {
                            var fileContent = File.ReadAllText(fileInfo.FullName);
                            var sb = new StringBuilder();
                            foreach (var val in fileContent)
                            {
                                sb.Append(char.IsLetter(val) ? val.ToString().ToLowerInvariant() : " ");
                            }
                            string[] wordInFile = sb.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var word in wordInFile)
                            {
                                _wordCounts.AddOrUpdate(word, 1, (s, n) => n + 1);
                                //int value;
                                //if (_wordCounts.TryGetValue(word, out value))
                                //{
                                //    _wordCounts[word] = value++;
                                //}
                                //else
                                //{
                                //    _wordCounts[word] = 1;
                                //}
                                //var value = _wordCounts.GetOrAdd(word, 0);
                                //_wordCounts[word] = value++;

                                
                            }
                        });
                    var diretories = dirInfo.GetDirectories().AsParallel<DirectoryInfo>();
                    diretories.ForAll<DirectoryInfo>(ProcessDirectory());
                });
            }
        }
    }
}