using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Pruebas
{
    public class Hash254
    {
        public Hash254(string hash254)
        {
            string hash = ComputeSHA256(hash254);
            Console.WriteLine(hash);
        }

        static string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            // Inicializar un objeto hash SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calcular el hash de la cadena dada
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Convierte la matriz de bytes a formato de cadena
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
    }
}
