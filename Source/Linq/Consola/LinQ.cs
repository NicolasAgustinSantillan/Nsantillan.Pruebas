﻿using Consola.dto;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("");
            // El resultado es passionfruit, en caso de que SUPERBANANA fuera mas largo seria la longestName
        }

        /// <summary>
        /// Su uso principal es de evaluar si TODOS los valores de la lista COINCIDEN con la CONDICION
        /// </summary>
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
            Console.WriteLine("");
        }

        /// <summary>
        /// Sirve para verificar si tiene POR LO MENOS 1 elemento el ARRAY x
        /// </summary>
        internal static void Any()
        {
            var people = new List<Person>()
            {
                new Person { LastName = "Haas",     Pets =  new Pet[] { new Pet { Name="Barley", Age=10 },
                                                            new Pet { Name="Boots", Age=14 },
                                                            new Pet { Name="Whiskers", Age=6 }}},
                new Person { LastName = "Fakhouri", Pets =  new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
                new Person { LastName = "Antebi",   Pets =  new Pet[] { }},
                new Person { LastName = "Philips",  Pets =  new Pet[] { new Pet { Name = "Sweetie", Age = 2},
                                                            new Pet { Name = "Rover", Age = 13}} }
            };

            // Filtramos por las personas que tiene POR LO MENOS 1 elemento el ARRAY PETS
            // SELECT seleccionamos el LastName
            IEnumerable<string> namesWherePets = people.Where(person => person.Pets.Any()).Select(peopleWithpPets => peopleWithpPets.LastName);

            Console.Write("Estas personas TIENEN mascotas: ");
            foreach (string name in namesWherePets)
            {
                Console.Write(name + " ; ");
            }
            Console.WriteLine("");
        }
    }
}
