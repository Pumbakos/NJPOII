using System;
using CSharpOOP.EmployeeFiles;
using CSharpOOP.Triangles;

namespace CSharpOOP
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var triangleProgram = new TriangleProgram();
            triangleProgram.Run();

            Console.WriteLine();
            Console.WriteLine();
            
            var employeeFilesProgram = new EmployeeFilesProgram();
            employeeFilesProgram.Run();
        }
    }
}