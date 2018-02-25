using System;
using PunClient.DataServices;
using PunClient.Transports;
using PunClient.PunWebService;

namespace PunClient
{
    class Program
    {
        private static PunDataService _service;

        static void Main(string[] args)
        {
            _service = new PunDataService();
            string input = "";
            while (input.ToUpper() != "Q")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("L) List puns");
                Console.WriteLine("#) Show specific pun");
                Console.WriteLine("N) Enter a new pun");
                Console.WriteLine("Q) Quit");
                Console.Write("Please enter a command: ");
                input = Console.ReadLine().ToUpper();
                int index = 0;
                if (input == "L")
                {
                    ListPuns();
                }
                else if (input == "N")
                {
                    EnterPun();
                }
                else if (Int32.TryParse(input, out index))
                {
                    ShowPun(index);
                }
            }
        }

        private static void ShowPun(int index)
        {
            var pun = _service.GetPunByID(index);
            Console.WriteLine("{0}) {1}:", pun.PunID, pun.Title);
            Console.WriteLine("{0}", pun.Joke);
            Console.WriteLine("---------------");
            Console.WriteLine("E) Edit pun");
            Console.WriteLine("D) Delete pun");
            Console.WriteLine("C) Continue");
            Console.Write("Please enter a command: ");
            var input = Console.ReadLine().ToUpper();
            if (input == "E")
            {
                EditPun(index);
            }
            else if (input == "D")
            {
                DeletePun(index);
            }
        }

        private static void DeletePun(int index)
        {
            Console.WriteLine("---------------");
            Console.Write("Are you sure you want to delete this pun? (Y/N) ");
            var input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                _service.DeletePun(index);
            }
        }

        private static void EditPun(int index)
        {
            Console.WriteLine("---------------");
            Console.Write("Name of pun? ");
            var name = Console.ReadLine();
            Console.Write("Pun? ");
            var joke = Console.ReadLine();
            var pun = new PunClient.PunWebService.Pun
            {
                PunID = index,
                Title = name,
                Joke = joke
            };
            _service.UpdatePun(pun);
        }

        private static void EnterPun()
        {
            Console.WriteLine("---------------");
            Console.Write("Name of pun? ");
            var name = Console.ReadLine();
            Console.Write("Pun? ");
            var joke = Console.ReadLine();
            var pun = new PunClient.PunWebService.Pun
            {
                Title = name,
                Joke = joke
            };
            _service.CreatePun(pun);
        }

        static void ListPuns()
        {
            var puns = _service.GetPuns();
            foreach (var pun in puns)
            {
                Console.WriteLine("{0}) {1}", pun.PunID, pun.Title);
            }
            Console.WriteLine("---------------");
        }
    }
}
