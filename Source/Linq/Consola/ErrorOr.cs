using System;

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

    public static class UseErrorOr
    {
        public static ErrorOr<int> Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                return ErrorOr<int>.Failure("Division by zero");
            }

            return ErrorOr<int>.Success(numerator / denominator);
        }


        public static void Start()
        {
            int valor1, valor2;
            Console.WriteLine(" ");
            Console.Write("Ingrese el primer valor:");
            valor1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            Console.Write("Ingrese el segundo valor:");
            valor2 = Convert.ToInt32(Console.ReadLine());

            var result1 = Divide(valor1, valor2);
            if (result1.IsError)
            {
                Console.WriteLine($"Error: {result1.ErrorMessage}");
            }
            else
            {
                Console.WriteLine($"Result: {result1.Value}");
            }

        }
    }



}
