using Consola.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Consola
{
    internal class LinQ
    {
        /// <summary>
        /// Recorre todos los metodos de esta intancia y los ejecuta
        /// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate?view=net-7.0
        /// </summary>
        public void Start()
        {
            MethodInfo[] methods = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                if (method.ReturnType == typeof(void) && method.GetParameters().Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(method.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    method.Invoke(this, null); // Ejecutar la función en esta instancia
                    Console.WriteLine("\n");
                }
            }
        }

        /// <summary>
        /// Aggregate se usa para comparar un VALOR EXTERNO con los valores de una LISTA
        /// </summary>
        internal void Aggregate()
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

        /// <summary>
        /// All se usa principalmente para evaluar si TODOS los valores de la lista COINCIDEN con la CONDICION
        /// </summary>
        public void All()
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

        /// <summary>
        /// Any sirve para verificar si tiene POR LO MENOS 1 elemento el ARRAY x
        /// </summary>
        internal void Any()
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
                Console.Write(name + "; ");
            }
        }

        /// <summary>
        /// Append sirve para agregar elementos a una lista ADEMAS podes GUARDARLOS o NO
        /// </summary>
        internal void Append()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4 };

            // Agrega el numero 5, NO LO GUARDA
            numbers.Append(5);
            Console.WriteLine(string.Join(", ", numbers));

            // Concatena la lista con el metodo
            Console.WriteLine(string.Join(", ", numbers.Append(5)));

            // Guardamos el resultado de Append
            List<int> newNumbers = numbers.Append(5).ToList();
            Console.WriteLine(string.Join(", ", newNumbers));

            // Resultado
            // 1, 2, 3, 4
            // 1, 2, 3, 4, 5
            // 1, 2, 3, 4, 5
        }

        /// <summary>
        /// Average sirve para CALCULAR un PROMEDIO, de una lista de nemeros
        /// </summary>
        internal void Average()
        {
            long?[] longs = { null, 10007L, 37L, 399846234235L };

            Console.WriteLine("En promedio el resultado fue: {0}.", longs.Average());

        }

        /// <summary>
        /// Concat se encarga de CONCATENAR strings proviniete de VARIAS LISTAS
        /// </summary>
        internal void Concat()
        {
            Pet[] cats = Pet.GetCats();
            Pet[] dogs = Pet.GetDogs();

            IEnumerable<string> query =
                cats.Select(cat => cat.Name).Concat(dogs.Select(dog => dog.Name));

            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Contains determina SI EXISTE un elemento en particular que contenga esa palabra
        /// </summary>
        internal void Contains()
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            string fruit = "mango";

            bool hasMango = fruits.Contains(fruit);

            Console.WriteLine(
                "En el array {0} '{1}'.",
                hasMango ? "EXISTE" : "NO EXISTE",
                fruit);
        }

        /// <summary>
        /// Count sirve para contar la cantidad de elementos en una coleccion
        /// </summary>
        internal void Count()
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            try
            {
                Console.WriteLine($"Existen {fruits.Count()} frutas en la coleccion.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The count is too large to store as an Int32.");
                Console.WriteLine("Try using the LongCount() method instead.");
            }
        }

        /// <summary>
        /// Distinct filtra de las lista los datos REPETIDOS, esto se puede hacer con objetos tipos clases
        /// </summary>
        internal void Distinct()
        {
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

            IEnumerable<int> distinctAges = ages.Distinct();

            Console.WriteLine("Distinct ages:");

            foreach (int age in distinctAges)
            {
                Console.WriteLine(age);
            }
        }

        /// <summary>
        /// Distinct2: filtra los distintos del tipo PRODUCT (Importante: agregar los metodos necesarios para que funcione Equals(Product other) & GetHashCode() )
        /// </summary>
        internal void Distinct2()
        {
            Product[] products =
            {
                new Product { Name = "apple", Code = 9 },
                new Product { Name = "orange", Code = 4 },
                new Product { Name = "apple", Code = 9 },
                new Product { Name = "apple", Code = 10 },
                new Product { Name = "lemon", Code = 12 }
            };

            IEnumerable<Product> noduplicates = products.Distinct();

            foreach (var product in noduplicates) Console.WriteLine(product.Name + " " + product.Code);
        }
    }
}
