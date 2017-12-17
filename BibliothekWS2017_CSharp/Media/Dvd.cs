using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothekWS2017_CSharp.Media
{
    public class Dvd
    {
        private string id { get; set; } = "";
        private string title { get; set; } = "";
        private string asin { get; set; } = "";
        private string releaseDate { get; set; } = "";
        private string publisher { get; set; } = "";
        private string director { get; set; } = "";

        public string getDateFormated()
        {
            long releaseDateLong = 0;
            long.TryParse(releaseDate, out releaseDateLong);

            TimeSpan time = TimeSpan.FromMilliseconds(releaseDateLong);
            DateTime date = new DateTime(1970, 1, 1) + time;

            return date.ToString("dd.MM.yyyy");
        }

        public override string ToString()
        {
            return "---------------------\n" +
                   "id : " + id + "\n" +
                   "titel : " + title + "\n" +
                   "asin : " + asin + "\n" +
                   "releaseDate : " + getDateFormated() + "\n" +
                   "publisher : " + publisher + "\n" +
                   "director : " + director + "\n" +
                   "---------------------";
        }
    }
}
