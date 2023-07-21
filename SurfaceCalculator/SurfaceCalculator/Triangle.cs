using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfaceCalculator.Model
{
    /// <summary>
    /// Класс описывающий треугольник
    /// </summary>
    public class Triangle : ISurface
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public double A { get => _a; }
        public double B { get => _b; }
        public double C { get => _c; }

        /// <summary>
        /// Конструктор для любого треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle(double a, double b, double c)
        {
            ThrowOnError(a, b, c);

            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// Конструктор для прямоугольного треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="isRight"></param>
        public Triangle(double a, double b)
        {
            double c = Math.Sqrt(a * a + b * b);

            ThrowOnError(a, b, c);

            _a = a;
            _b = b;
            _c = c;
        }

        /// <summary>
        /// Вычисляет площадь по формуле Герона
        /// </summary>
        /// <returns></returns>
        public double GetSurface()
        {
            if(IsRight(out var a, out var b, out var c))
            {
                return a * b / 2;
            }

            double s = (_a + _b + _c) / 2;
            return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
        }

        /// <summary>
        /// Определяет является ли треугольник прямоугольным и задает стороны в правильной последовательности
        /// </summary>
        /// <returns></returns>
        public bool IsRight()
        {
            if (Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2))
            {
                return true;
            }

            if (Math.Pow(_a, 2) + Math.Pow(_c, 2) == Math.Pow(_b, 2))
            {
                return true;
            }

            if (Math.Pow(_b, 2) + Math.Pow(_c, 2) == Math.Pow(_a, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет является ли треугольник прямоугольным и задает стороны 
        /// в правильной последовательности если результатом является истина
        /// </summary>
        /// <returns></returns>
        public bool IsRight(out double a, out double b, out double c)
        {
            a = _a;
            b = _b;
            c = _c;

            if(Math.Pow(_a, 2) + Math.Pow(_b, 2) == Math.Pow(_c, 2))
            {
                return true;
            }

            if (Math.Pow(_a, 2) + Math.Pow(_c, 2) == Math.Pow(_b, 2))
            {
                b = _c;
                c = _b;
                return true;
            }

            if (Math.Pow(_b, 2) + Math.Pow(_c, 2) == Math.Pow(_a, 2))
            {
                a = _b;
                b = _c;
                c = _a;
                return true;
            }

            return false;
        }

        private void ThrowOnError(double a, double b, double c)
        {
            var exceptions = new List<Exception>(); 
            if(a <= 0)
            {
                exceptions.Add(new ArgumentOutOfRangeException($"{nameof(a)} should be greater than zero"));
            }

            if(b <= 0)
            {
                exceptions.Add(new ArgumentOutOfRangeException($"{nameof(b)} should be greater than zero"));
            }

            if(c <= 0)
            {
                exceptions.Add(new ArgumentOutOfRangeException($"{nameof(c)} should be greater than zero"));
            }

            if(a > b + c)
            {
                exceptions.Add(new ArgumentOutOfRangeException($"{nameof(a)} is greater than sum of {nameof(b)} and {nameof(c)}"));
            }

            if(b > a + c)
            {
                exceptions.Add(new ArgumentOutOfRangeException($"{nameof(b)} is greater than sum of {nameof(a)} and {nameof(c)}"));
            }

            if (c > a + b)
            {
                exceptions.Add(new ArgumentOutOfRangeException($"{nameof(c)} is greater than sum of {nameof(b)} and {nameof(a)}"));
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
