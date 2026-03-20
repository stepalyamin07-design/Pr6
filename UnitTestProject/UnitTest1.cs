using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalWork4_Fam1_Fam2;

namespace UnitTestProject
{
    /// <summary>
    /// Содержит демонстрационный тест для ознакомления с методами класса Assert.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Проверяет  арифметическую операцию 2+2 с использованием различных методов Assert.
        /// </summary>
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

    /// <summary>
    /// Содержит набор модульных тестов для трёх математических функций из Практической работы 4 .
    /// </summary>
    [TestClass]
    public class BasicFunctionTests
    {
        /// <summary>
        /// Тестирует метод ComputeFirst при x = 0, y = 1, z = π/2.
        /// Ожидаемое значение равно 1.25. Дополнительно проверяет, что результат положителен и не равен нулю.
        /// </summary>
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

        /// <summary>
        /// Тестирует метод ComputeSecond с выбором типа функции sh(x) (funcType = 0) при x = 0.
        /// Ожидаемое значение равно 1.0. Также проверяем, что результат конечен и положителен.
        /// </summary>
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

        /// <summary>
        /// Тестирует метод ComputeThird при x = 4, b = 2.
        /// Ожидаемое значение вычисляется аналитически с использованием стандартных математических функций.
        /// Дополнительно проверяем, что результат не является бесконечностью, не равен нулю и положителен.
        /// </summary>
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
