using System;
using System.Linq;

namespace Consola
{
    internal class LinQ
    {
        /// <summary>
        /// Su uso es para comparar un VALOR EXTERNO con los valores de una LISTA
        /// </summary>
        internal static void Aggregate()
        {
            string valueExternal = "SuperBanana";
            string[] listFruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            // Determinar si SuperBanana es el MAS LARGO de la LISTA fruits
            string longestName =
                listFruits.Aggregate(valueExternal,
                                (longest, next) =>
                                    next.Length > longest.Length ? next : longest,
                                // Return the final result as an upper case string.
                                fruit => fruit.ToUpper());

            Console.WriteLine(
                "La fruta mas larga es: {0}.",
                longestName);

            // El resultado es passionfruit, en caso de que SUPERBANANA fuera mas largo seria la longestName
        }

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

            Console.WriteLine("{0} mascontas comienzan con 'B'.", allStartWithB ? "TODAS" : "NO todas");
        }
    }
}
