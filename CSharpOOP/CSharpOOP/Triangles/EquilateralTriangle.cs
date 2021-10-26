using System;

namespace CSharpOOP.Triangles
{
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double a) : base(a, a, a)
        {
            base.a = a;
            base.b = a;
            base.c = a;
        }

        public new double Field()
        {
            return (Math.Pow(a, 2) * Math.Sqrt(3)) / 4;
        }

        public new double Perimeter()
        {
            return base.Perimeter();
        }
    }
}