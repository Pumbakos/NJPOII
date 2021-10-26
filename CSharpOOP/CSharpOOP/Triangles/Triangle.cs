using System;

namespace CSharpOOP.Triangles
{
    public abstract class Triangle
    {
        protected double a { get; init;}
        protected double b { get; init;}
        protected double c { get; init;}

        protected Triangle()
        {
        }

        protected Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Field()
        {
            var p = (a+b+c)/2.0;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }

        public double Perimeter()
        {
            return a + b + c;
        }

        public override string ToString()
        {
            return $"A:{a} B:{b} C:{c}";
        }
    }
}