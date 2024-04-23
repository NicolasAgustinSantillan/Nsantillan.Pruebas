using System;
using System.Linq;

namespace Consola
{
    internal class LinQ
    {
        public static void All()
        {
            Pet[] pets = { new Pet { Name="Barley", Age=10 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=6 } };

            //Pet[] pets = { new Pet { Name="Barley", Age=10 },
            //       new Pet { Name="Boots", Age=4 },
            //       new Pet { Name="Butters", Age=6 } };


            // Se determina que TODA la lista de mascotas comienza con B
            bool allStartWithB = pets.All(pet => pet.Name.StartsWith("B"));

            Console.WriteLine("{0} pet names start with 'B'.", allStartWithB ? "All" : "Not all");
        }
    }
}
