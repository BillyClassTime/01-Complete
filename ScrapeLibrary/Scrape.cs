using System.IO;
using System.Net;

namespace ScrapeLibrary
{
    internal class Scrape
    {
        public string ScrapeWebpage(string url)
        {
            return GetWebpage(url);
        }

        public string ScrapeWebpage(string url, string filepath)
        {
            string reply = GetWebpage(url);

            File.WriteAllText(filepath, reply);
            return reply;
        }

        private string GetWebpage(string url)
        {
            WebClient client = new WebClient();
            var myWordCount = new WordCount();
            var content = client.DownloadString(url);
            content += $"THAT'S ALL FOLKS!!!-Quantity:{myWordCount.CountWords(content)}";

            return content;
        }
        private class WordCount
        {
            public int CountWords(string stringToCount)
            {
                var quantityWords = stringToCount.Length;
                return quantityWords;
            }
        }

    }
}
