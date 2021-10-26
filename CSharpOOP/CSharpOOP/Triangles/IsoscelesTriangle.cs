using System;

namespace CSharpOOP.Triangles
{
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double a, double b) : base()
        {
            base.a = a;
            base.b = b;
            base.c = a;
        }

        public new double Field()
        {
            return Math.Pow(a, 2) / 2;
        }

        public new double Perimeter()
        {
            return base.Perimeter();
        }
    }
}