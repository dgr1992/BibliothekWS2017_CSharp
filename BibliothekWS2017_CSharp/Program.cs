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
            string url="";

            if (args.Length < 2)
            {
                System.Console.WriteLine("Please add url with -url \"url\"");
                return;
            } else {
                if(args[0].Contains("-url")){
                    url = args[1];   
                }
            }

            try
            {
                RestClientController controller = new RestClientController(url, "application/json");
            } catch (Exception ex)
            {
                Console.WriteLine("Connect to server faild.");
                return;
            }

            PrintWelcome();


        }

        private static void PrintWelcome(){
            Console.WriteLine("#####################################");
            Console.WriteLine("#                                   #");
            Console.WriteLine("#              Welcome              #");
            Console.WriteLine("#                                   #");
            Console.WriteLine("#####################################");
        }

        private static void Menu()
        {           
            bool inputValid = false;
            bool exitApplication = false;
            string input = "";
        
            while(!inputValid && exitApplication)
            {
                Console.WriteLine("Possible actions: ");
                Console.WriteLine("           - Enter \"b\" to search for books");
                Console.WriteLine("           - Enter \"d\" to search for dvds");
                Console.WriteLine("           - Enter \"l\" to login");
                Console.WriteLine("           - Enter \"e\" to exit");
                input = Console.ReadLine();
                if(input.Contains("b") || input.Contains("d") || input.Contains("l")){
                    switch(input){
                        case "b":
                            SearchForBook();
                        break;
                        case "d":
                            SearchForDvd();
                        break;
                        case "l":
                        break;
                        default:
                        break;
                    }
                } else if(input.Contains("e"))
                {

                }
            }
        }

        private static void SearchForBook()
        {
            
        }
        private static void SearchForDvd()
        {

        }

        private static void Login()
        {

        }
    }
}
