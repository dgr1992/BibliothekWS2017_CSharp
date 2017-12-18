using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothekWS2017_CSharp.Media;
using BibliothekWS2017_CSharp.RemoteClasses;
using Newtonsoft.Json;

namespace BibliothekWS2017_CSharp
{
    public class RestClientController
    {
        private RestClient _client;

        /// <summary>
        /// Creates a new instance of a HTTP client for the given URL and the expected data type to be received
        /// </summary>
        /// <param name="url">URL to the web service. Example: http://test.at/test/ add a / at the end of the URL</param>
        /// <param name="dataType">Expected data type from the web service. Example: application/json </param>
        public RestClientController(String url, String dataType)
        {
            _client = new RestClient(url, dataType);
        }

        /// <summary>
        /// Requests all books
        /// </summary>
        /// <returns>Array of all books</returns>
        public Book[] GetAllBooks()
        {
            //Get data from webservice as json string
            String jsonObjectArray = _client.Get("getAllBooks").Result;

            //Convert the json string to objects
            Book[] books = JsonConvert.DeserializeObject<Book[]>(jsonObjectArray);

            return books;
        }

        /// <summary>
        /// Search for books matching the given book
        /// </summary>
        /// <param name="book">Book with title or director or asin set</param>
        /// <returns>All books that have a match with the book sent</returns>
        public Book[] SearchForBook(Book book)
        {
            //Perform the put request
            String jsonObjectArray = _client.Put("searchBooks", book).Result;

            //Convert the json string to objects
            Book[] books = JsonConvert.DeserializeObject<Book[]>(jsonObjectArray);

            return books;
        }

        /// <summary>
        /// Search for dvds matching the given dvd
        /// </summary>
        /// <param name="dvd"></param>
        /// <returns>All dvds that have a match with the dvd sent</returns>
        public Dvd[] SearchForDvd(Dvd dvd)
        {
            //Perform the put request
            String jsonObjectArray = _client.Put("searchDvds", dvd).Result;

            //Convert the json string to objects
            Dvd[] dvds = JsonConvert.DeserializeObject<Dvd[]>(jsonObjectArray);

            return dvds;
        }


        /// <summary>
        /// Rent a medium by customer number and copy number
        /// </summary>
        /// <param name="customernumber">Customers personal identification number</param>
        /// <param name="copynumber">Copy number of the medium to rent</param>
        /// <returns>String with message "Successful rented" or "Rent failed"</returns>
        public String RentMedium(String customernumber, String copynumber){
            
            Rental rental = new Rental();
            rental.customerNumber=customernumber;
            rental.copyNumber=copynumber;

            //Perform the put request
            String jsonObjectArray = _client.Put("rentMedium",rental).Result;

            //Convert the json string to objects
            //String rentedMessage = JsonConvert.DeserializeObject<String>(jsonObjectArray);

            if(jsonObjectArray == null){
                return "Rent failed";
            }
            
            if(jsonObjectArray.Contains("SUCCESS")){
                return "Successful rented";
            } else {
                return "Rent failed";
            }
        }

        public Boolean Login(UserAccount user){
            
            String jsonObjectArray = _client.Put("authenticateUser",user).Result;

            Boolean loginStatus = JsonConvert.DeserializeObject<Boolean>(jsonObjectArray);
            
            return loginStatus;
        }

    }
}
