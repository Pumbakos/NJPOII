using System;

namespace CSharpOOP.Triangles
{
    public class TriangleProgram
    {
        public void Run()
        {
            Console.WriteLine("\nCreating equilateral triangle with side of it equal to '4.1'...");
            var equilateralTriangle = new EquilateralTriangle(4.1);
            Console.WriteLine("Perimeter: " + equilateralTriangle.Perimeter());
            Console.WriteLine("Field: " + equilateralTriangle.Field());
            
            Console.WriteLine("\nCreating right triangle with side of it equal to '6.0' and base equal to '4.0' ...");
            var rightTriangle = new RightTriangle(6.0, 4.0);
            Console.WriteLine("Perimeter: " + rightTriangle.Perimeter());
            Console.WriteLine("Field: " + rightTriangle.Field());
            
            Console.WriteLine("\nCreating isosceles triangle with first side of it equal to '3.0' and second equal to '4.0'...");
            var isoscelesTriangle = new IsoscelesTriangle(3.0, 4.0);
            Console.WriteLine("Perimeter: " + isoscelesTriangle.Perimeter());
            Console.WriteLine("Field: " + isoscelesTriangle.Field());
        }
    }
}