using SurfaceCalculator.Model;
using SurfaceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfaceCalculatorTest
{
    public class BasicTriangleTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Triangle_123_ReturnsZero()
        {
            double actual = 0;

            ISurface triangle = new Triangle(1, 2, 3);

            double area = triangle.GetSurface();

            Assert.That(area, Is.EqualTo(actual));
        }

        [Test]
        public void Triangle_RightTriangle_CalculatesC()
        {
            double a = 10;
            double b = 15;

            double actualC = Math.Sqrt(a * a + b * b);
            Console.WriteLine(actualC);
            Triangle triangle = new Triangle(a, b);

            Assert.That(triangle.C, Is.EqualTo(actualC));
        }

        [Test]
        public void Triangle_A_IsGreaterThanSumOfTwo_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(5, 1, 2));
        }

        [Test]
        public void Triangle_B_IsGreaterThanSumOfTwo_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(1, 5, 2));
        }

        [Test]
        public void Triangle_C_IsGreaterThanSumOfTwo_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(1, 1, 7));
        }

        [Test]
        public void Triangle_A_IsZero_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(0, 1, 1));
        }

        [Test]
        public void Triangle_B_IsZero_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(1, 0, 1));
        }

        [Test]
        public void Triangle_C_IsZero_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(1, 1, 0));
        }

        [Test]
        public void Triangle_All_Zeroes_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(0, 0, 0));
        }

        [Test]
        public void Triangle_SurfaceOfNegative_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => new Triangle(-1, 1, 1));
        }
    }
}
