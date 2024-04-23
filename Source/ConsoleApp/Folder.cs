using System;
using System.IO;

namespace ConsoleApp
{
    public class Folder
    {
        public static void Create()
        {
            string directorioBase = @"C:\Users\Nicolas\OneDrive\Casa"; // Cambia esto a la ruta que desees

            for (int i = 1; i <= 360; i++)
            {
                string nombreCarpeta = i.ToString("D3") + "-Cuota";
                string rutaCarpeta = Path.Combine(directorioBase, nombreCarpeta);

                // Verificar si la carpeta ya existe antes de crearla
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                    Console.WriteLine("Creada carpeta: " + rutaCarpeta);
                }
                else
                {
                    Console.WriteLine("La carpeta ya existe: " + rutaCarpeta);
                }
            }

            Console.WriteLine("Proceso completado.");
        }
    }
}
