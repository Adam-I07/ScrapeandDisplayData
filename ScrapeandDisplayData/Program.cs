using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using HtmlAgilityPack;
using CsvHelper;

namespace ScrapeandDisplayData
{
    /*This program goes to the wikipedia page of England and scrapes all the main topics talked about
     * and caches the data is a csv file ready to be viewied by the user*/
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb webPage = new HtmlWeb();
            HtmlDocument url = webPage.Load("https://en.wikipedia.org/wiki/England");

            var TopicNames = url.DocumentNode.SelectNodes("//span[@class='toctext']");

            var topics = new List<Row>();
            foreach (var item in TopicNames)
            {
                topics.Add(new Row { topicNames = item.InnerText });
            }
            using (var writer = new StreamWriter("C:/Users/adami/source/repos/ScrapeandDisplayData/example.csv"))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(topics);
                }
            }

        }
    }
    
    public class Row
    {
        public string topicNames { get; set; }
    }
}
