using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Pruebas
{
    public class ListFind
    {
        public ListFind()
        {
            List<string> list = new List<string>();

            list.Add("Personas bloqueadas: \n\n");

            list.Add("Mauro\n");
            list.Add("Lucas\n");
            list.Add("Roberto\n");
            list.Add("Lautaro\n");

            list.Remove("Lucas\n");

            list.Remove("Toto");

            string pepe = "";

            foreach (string item in list)
            {
                pepe += item;
            }

            var boolean1 = list.Any(i => i == "Lucas\n");
            var boolean2 = list.Any(i => i == "Lautaro\n");
            Console.WriteLine(pepe);
            Console.ReadKey();
        }
    }
}
