using Calculadora.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class UnitTestCalculadora
    {
        [TestMethod]
        public void Test_Calcular_Suma()
        {
            //Arrange : Inicializar las variables
            int sumando1 = 2;
            int sumando2 = 3;

            //Act : llamar al metodo a testear
            int resultado = CalculadoraEjemplo.Suma(sumando1, sumando2);

            //Assert: comprobar el valor con el esperado.
            Assert.AreEqual(5, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Test_Calcular_Division()
        {
            //Arrange : Inicializar las variables
            int dividendo = 120;
            int divisor = 0;

            //Act : llamar al metodo a testear
            double resultado = CalculadoraEjemplo.Division(dividendo, divisor);

            //Assert: comprobar el valor con el esperado.
            Assert.AreEqual(10, resultado);
        }
    }

}
