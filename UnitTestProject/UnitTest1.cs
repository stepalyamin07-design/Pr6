using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalWork4_Fam1_Fam2;

namespace UnitTestProject
{
    /// Содержит демо тест-пример из задания с методами Assert
    [TestClass]
    public class UnitTest1
    {
        /// Проверка основных арифметических операций и методов Assert
   
        [TestMethod]
        public void TestMethod1()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4);
            Assert.AreNotEqual(res, 5);
            Assert.IsFalse(res > 5);
            Assert.IsTrue(res < 5);
        }
    }

    /// Набор тестов для проверки трёх  функций в практической работе 4.

    [TestClass]
    public class BasicFunctionTests
    {
        /// Тестирует метод ComputeFirst при x = 0, y = 1, z = π/2.
        /// Ожидаемое значение: 1.25. еще проверяет, что результат положителен и не равен нулю.
 
        [TestMethod]
        public void TestFirstFunction()
        {
            double x = 0.0;
            double y = 1.0;
            double z = Math.PI / 2;
            double expected = 1.25;
            double actual = MathFunctions.ComputeFirst(x, y, z);

            Assert.AreEqual(expected, actual, 1e-10, "Ошибка в вычислении первой функции");
            Assert.AreNotEqual(0.0, actual, 1e-10, "Результат не должен быть равен 0");
            Assert.IsTrue(actual > 0, "Результат должен быть положительным");
        }

        /// Тестирует метод ComputeSecond с выбором sh(x) при x = 0.
        /// Ожидаемое значение: 1.0. еще проверяем, что результат конечен и положителен.
   
        [TestMethod]
        public void TestSecondFunction_Sh()
        {
            double x = 0.0;
            int funcType = 0;
            double expected = 1.0;
            double actual = MathFunctions.ComputeSecond(x, funcType);

            Assert.AreEqual(expected, actual, 1e-10, "Ошибка в вычислении второй функции");
            Assert.IsFalse(double.IsInfinity(actual), "Результат не должен быть бесконечностью");
            Assert.IsTrue(actual > 0, "Результат должен быть положительным");
        }

        /// Тестирует метод ComputeThird при x = 4, b = 2.
        /// что результат не является бесконечностью, не равен нулю и положителен.
 
        [TestMethod]
        public void TestThirdFunction()
        {
            double x = 4.0;
            double b = 2.0;
            double expected = (Math.Pow(x, 2.5) - b) * Math.Log(x * x + 12.7);
            double actual = MathFunctions.ComputeThird(x, b);

            Assert.AreEqual(expected, actual, 1e-10, "Ошибка в вычислении третьей функции");
            Assert.IsFalse(double.IsInfinity(actual), "Результат не должен быть бесконечностью");
            Assert.AreNotEqual(0.0, actual, 1e-10, "Результат не должен быть равен 0");
            Assert.IsTrue(actual > 0, "Результат должен быть положительным");
        }
    }
}