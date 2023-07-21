using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfaceCalculator.Model
{
    public class Circle : ISurface
    {
        private readonly double _radius;
        
        public Circle(double radius)
        {
            ThrowOnError(radius);

            _radius = radius;
        }

        public double GetSurface()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        private void ThrowOnError(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "Radius should be greater than or equals to zero");
            }
        }
    }
}
