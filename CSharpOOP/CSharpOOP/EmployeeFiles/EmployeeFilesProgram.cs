using System.Collections.Generic;
using System;

namespace CSharpOOP.EmployeeFiles
{
    public class EmployeeFilesProgram
    {
        private static List<Employee> _employees = new();

        public void Run()
        {
            Console.WriteLine("\nGenerating employees data...");
            var employee = new Employee("dfb8d156-97e6-47c3-925a-bcf77094e49a", "Loaf", "Birth", 19,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            var employee2 = new Employee("c7077674-efe9-419a-bb29-fbb6959cccd5", "Loaf", "Birth", 19,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            var employee3 = new Employee("1137ca8b-d188-413b-ae96-fe7a2770c522", "", "", 33,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            var employee4 = new Employee("9a240592-4093-4ce0-8bd8-b2cc53aa6957", "", "print", 65,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            var employee5 = new Employee("8bbc7ee0-d41c-40a1-b9ed-539489330825", "immense", "", 90,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            var employee6 = new Employee("e5654a6c-30f8-459f-a80d-91a409ddeddf", "", "", 4,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            var employee7 = new Employee("55c32e73-0934-4e33-9d62-596a3fd3a238", "Weave", "Death", 51,
                "1994-04-03T15:32:16.000", EmployeeType.Employee);

            Console.WriteLine("\nCreating file...");
            _employees.Add(employee);
            _employees.Add(employee2);
            _employees.Add(employee3);
            _employees.Add(employee4);
            _employees.Add(employee5);
            _employees.Add(employee6);
            _employees.Add(employee7);

            EmployeeFiles<Employee> employeeFiles = new(_employees);

            Console.WriteLine("\nAre first two employees same person?: " + employee.IsMatch(employee2));

            var invalidEmployyes = employeeFiles.Validate();
            if (invalidEmployyes.Capacity == 0)
                Console.WriteLine("\nALL USERS VALID");
            else
            {
                Console.WriteLine("\nINVALID EMPLOYEE IDs:");
                foreach (var validatedEmployee in invalidEmployyes)
                {
                    Console.WriteLine("- " + validatedEmployee.IdNumber);
                }
            }

            Console.WriteLine("\nShowing valid employees...");
            foreach (var e in _employees)
            {
                if (IEmployee.IsValid(e))
                    Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nFinding Employee with ID: dfb8d156-97e6-47c3-925a-bcf77094e49a ...");
            var foundEmployeesById = employeeFiles.Find("dfb8d156-97e6-47c3-925a-bcf77094e49a");
            foreach (var e in foundEmployeesById)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nFinding Employee who are named 'Loaf' ...");
            var foundEmployeeByName = employeeFiles.Find("Loaf");
            foreach (var e in foundEmployeeByName)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nSaving EmployeeFiles to JSON format ...");
            employeeFiles.Save(FileFormat.Json);

            Console.WriteLine("\nSaving EmployeeFiles to TXT format ...");
            employeeFiles.Save(FileFormat.Txt);
            
            Console.WriteLine("\nSaving EmployeeFiles to XML format ...");
            employeeFiles.Save(FileFormat.Xml);
        }
    }
}