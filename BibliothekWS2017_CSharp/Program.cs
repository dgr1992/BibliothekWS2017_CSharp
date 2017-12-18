using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BibliothekWS2017_CSharp.Media;

namespace BibliothekWS2017_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClientController controller = new RestClientController("http://10.0.51.95:9000/BibliothekWS2017Server/", "application/json");

            Console.WriteLine("Get all Books");
            Book[] books = controller.GetAllBooks();
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            
            Console.WriteLine("================");
            Console.WriteLine("Search for the book \"Der kleine Hobbit\" with the string \"d\"");
            Book bookToSearch = new Book();
            bookToSearch.title = "d";
            books = controller.SearchForBook(bookToSearch);
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Console.Read();
            
        }
    }
}
