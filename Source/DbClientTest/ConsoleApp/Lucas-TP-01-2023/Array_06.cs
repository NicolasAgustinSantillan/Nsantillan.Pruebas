using System;

namespace ConsoleApp.Lucas_TP_01_2023
{
    public class Array_06
    {
        public Array_06()
        {
            var listaPersonas = this.CargarPersonas();

            listaPersonas = this.OrdenarPorEdad(listaPersonas);

            this.ImprimirPorPantalla(listaPersonas);

            Console.ReadKey();
        }

        private string[,] CargarPersonas()
        {
            var listaPersonas = new string[5, 3];
            for (int fila = 0; fila < 5; fila++)
            {
                Console.Write("ingrese el nombre: ");
                listaPersonas[fila, 0] = Console.ReadLine();
                Console.Write("ingrese el apellido: ");
                listaPersonas[fila, 1] = Console.ReadLine();
                Console.Write("ingrese la edad: ");
                listaPersonas[fila, 2] = Console.ReadLine();
            }

            return listaPersonas;
        }

        private string[,] OrdenarPorEdad(string[,] listaPersonas)
        {
            int filaMayorEdad = 0, edadMayor;
            string[,] listaPersonasOrdenadas = new string[5, 3];

            for (int filaAsignar = 0; filaAsignar < 5; filaAsignar++)
            {
                edadMayor = 0;
                for (int filaBuscar = 0; filaBuscar < 5; filaBuscar++)
                {
                    int edad = Convert.ToInt32(listaPersonas[filaBuscar, 2]);
                    if (edad > edadMayor)
                    {
                        filaMayorEdad = filaBuscar;
                        edadMayor = edad;
                    }
                }

                // Ordeno por persona con mas edad
                listaPersonasOrdenadas[filaAsignar, 0] = listaPersonas[filaMayorEdad, 0];
                listaPersonasOrdenadas[filaAsignar, 1] = listaPersonas[filaMayorEdad, 1];
                listaPersonasOrdenadas[filaAsignar, 2] = listaPersonas[filaMayorEdad, 2];

                // Elimino el registro encontrado
                listaPersonas[filaMayorEdad, 0] = "";
                listaPersonas[filaMayorEdad, 1] = "";
                listaPersonas[filaMayorEdad, 2] = "-1";
            }

            // Retorno las personas ordenadas
            return listaPersonasOrdenadas;
        }

        private void ImprimirPorPantalla(string[,] listaPersonas)
        {
            Console.WriteLine("\n==========================================");
            for (int fila = 0; fila < 5; fila++)
            {
                Console.WriteLine($"{listaPersonas[fila, 1]}, {listaPersonas[fila, 0]} {listaPersonas[fila, 2]}");
            }
            Console.WriteLine("==========================================");
        }
    }
}
