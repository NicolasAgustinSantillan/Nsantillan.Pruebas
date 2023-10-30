using System;
using ConsoleApp.DataBase;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var DB_TEST = new DB_TEST();
            var personas = DB_TEST.ObtenerPersonas();

            Console.ReadKey();

            Console.WriteLine("Hola mundo :D");
        }
    }
}
