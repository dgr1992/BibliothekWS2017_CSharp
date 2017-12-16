using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothekWS2017_CSharp.Media
{
    public class Book
    {
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string isbn { get; set; }
        public long releaseDate { get; set; }
        public string publisher { get; set; }
        public string author { get; set; }

        public override string ToString()
        {
            TimeSpan time = TimeSpan.FromMilliseconds(releaseDate);
            DateTime date = new DateTime(1970, 1, 1) + time;

            return "---------------------\n" +
                   "id : " + id + "\n" +
                   "titel : " + title + "\n" +
                   "type : " + type + "\n" +
                   "isbn : " + isbn + "\n" +
                   "releaseDate : " + date.ToString("dd.MM.yyyy") + "\n" +
                   "publisher : " + publisher + "\n" +
                   "author : " + author + "\n" +
                   "---------------------";
        }
    }
}
