using System;

namespace PracticalWork4_Fam1_Fam2
{
    public static class MathFunctions
    {
        public static double ComputeFirst(double x, double y, double z)
        {
            if (x + 1 == 0)
                throw new DivideByZeroException("x + 1 не должно быть равно 0.");
            if (x + y == 0)
                throw new DivideByZeroException("|x+y| не должен быть равен 0.");
            if (Math.Abs(Math.Sin(z)) < 1e-10)
                throw new DivideByZeroException("sin(z) не должен быть равен 0.");

            double term1 = (y / (x + 1)) * Math.Pow(Math.Abs(y - 2), 1.0 / 3.0);
            double term2 = (x + y / 2) / (2 * Math.Abs(x + y)) * Math.Pow(x + 1, -1.0 / Math.Sin(z));
            return term1 + term2;
        }
        /// <param name="x"
        /// <param name="funcType"
        public static double ComputeSecond(double x, int funcType)
        {
            double f;
            if (funcType == 0)
                f = Math.Sinh(x);
            else if (funcType == 1)
                f = x * x;
            else if (funcType == 2)
                f = Math.Exp(x);
            else
                throw new ArgumentException("Неверный тип функции", nameof(funcType));

            return f * Math.Sin(x) + Math.Cos(x);
        }
        public static double ComputeThird(double x, double b)
        {
            return (Math.Pow(x, 2.5) - b) * Math.Log(x * x + 12.7);
        }
    }
}