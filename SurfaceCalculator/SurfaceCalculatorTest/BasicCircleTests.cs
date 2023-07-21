using SurfaceCalculator;
using SurfaceCalculator.Model;

namespace SurfaceCalculatorTest
{
    public class BasicCircleTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Circle_SurfaceOfOne_ReturnsPI()
        {
            ISurface circle = new Circle(1);

            double area = circle.GetSurface();

            Assert.That(area, Is.EqualTo(Math.PI));
        }

        [Test]
        public void Circle_SurfaceOfZero_ReturnsZero()
        {
            ISurface circle = new Circle(0);

            double area = circle.GetSurface();

            Assert.That(area, Is.EqualTo(0));
        }

        [Test]
        public void Circle_SurfaceOfNegative_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
        }
    }
}