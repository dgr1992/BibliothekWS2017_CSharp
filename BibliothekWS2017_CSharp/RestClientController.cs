using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothekWS2017_CSharp.Media;
using Newtonsoft.Json;

namespace BibliothekWS2017_CSharp
{
    public class RestClientController
    {
        private RestClient _client;

        public RestClientController(String url, String dataType)
        {
            _client = new RestClient(url, dataType);
        }

        public Book[] GetAllBooks()
        {
            //Get data from webservice as json string
            String jsonObjectArray = _client.Get("getAllBooks").Result;

            //Convert the json string to objects
            Book[] books = JsonConvert.DeserializeObject<Book[]>(jsonObjectArray);

            return books;
        }

        public Book[] SearchForBook(Book book)
        {
            //Convert to a jsonObject
            String jsonObject = JsonConvert.SerializeObject(book);

            //Mack the call
            String jsonObjectArray = _client.Put("searchBooks", jsonObject).Result;

            //Convert the json string to objects
            Book[] books = JsonConvert.DeserializeObject<Book[]>(jsonObjectArray);

            return books;
        }
    }
}
