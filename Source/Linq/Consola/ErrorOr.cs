using System;
using System.Threading;
using System.Threading.Tasks;

namespace Consola
{
    public class ErrorOr<T>
    {
        public bool IsError { get; }
        public T Value { get; }
        public string ErrorMessage { get; }

        private ErrorOr(T value)
        {
            IsError = false;
            Value = value;
            ErrorMessage = null;
        }

        private ErrorOr(string errorMessage)
        {
            IsError = true;
            Value = default; // default value for type T
            ErrorMessage = errorMessage;
        }

        public static ErrorOr<T> Success(T value)
        {
            return new ErrorOr<T>(value);
        }

        public static ErrorOr<T> Failure(string errorMessage)
        {
            return new ErrorOr<T>(errorMessage);
        }
    }

    public static class Util
    {
        public const string ErrorMessage = "Error";
        internal static Task<ErrorOr<T>> RunInBackground<T>(Func<T> value, string error = ErrorMessage)
        {
            return Task.Run(() =>
            {
                try
                {
                    T result = value.Invoke();
                    return Task.FromResult(ErrorOr<T>.Success(result));
                }
                catch (Exception ex)
                {
                    return Task.FromResult(ErrorOr<T>.Failure($"{error} => {ex.Message}"));
                }
            });
        }

        internal static Task<ErrorOr<int>> RunInBackground(Action value, string error = ErrorMessage) 
        {
            return Task.Run(() =>
            {
                try
                {
                    value();
                    return Task.FromResult(ErrorOr<int>.Success(1));
                }
                catch (Exception ex)
                {
                    return Task.FromResult(ErrorOr<int>.Failure($"{error} => {ex.Message}"));
                }
            });
        }
    }

    public static class Calculadora
    {
        /// <summary>
        /// RunInBackground: Se ejecuta en otro Hilo
        /// For: Cuando termine recién ahi va a imprimir los resultados 
        /// division: debe terminar sus tareas para que el hilo principal pueda seguir con su lógica
        /// </summary>
        public static void Start()
        {
            int valor1, valor2;
            var division = Util.RunInBackground(() =>
            {
                Console.WriteLine(" ---------- División ---------- ");
                Console.WriteLine("Ingrese el primer valor:");
                valor1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" ");
                Console.WriteLine("Ingrese el segundo valor:");
                valor2 = Convert.ToInt32(Console.ReadLine());
                return valor1 / valor2;
            }, "Error al dividir");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Soy un subproceso");
            }

            // Se frena el hilo principal hasta que no termine la division
            if (division.Result.IsError)
            {
                Console.WriteLine(division.Result.ErrorMessage);
                return;
            }

            Console.WriteLine($"Resultado de la division: {division.Result.Value:0.00}");
        }
    }



}
