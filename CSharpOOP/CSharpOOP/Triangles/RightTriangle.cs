using System;

namespace CSharpOOP.Triangles
{
    public class RightTriangle : Triangle
    {
        public RightTriangle(double a, double b) : base()
        {
            base.a = a;
            base.b = b;
        }

        public new double Field()
        {
            return (a * b) / 2.0;
        }

        public new double Perimeter()
        {
            return a + b + Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));
        }
    }
}