using System;
using ConsoleApp.DataBase;
using ConsoleApp.Pruebas;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var DB_TEST = new DB_TEST();
            //var personas = DB_TEST.ObtenerPersonas();

            // new ListFind();

            Console.ReadKey();

            // Folder.Create();

            bool noCargoDatos = true;
            while(noCargoDatos)
            {
                Console.WriteLine("Ingrese usuario: ");
                string usuario = Console.ReadLine();

                Console.WriteLine("Ingrese password: ");
                string pass = Console.ReadLine();

                if (usuario != null && pass != null)
                {
                    noCargoDatos = false;
                }
            }
        }
    }
}
