using System;
using System.Collections.Generic;
using System.Xml.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace CSharpOOP.EmployeeFiles
{
    [Serializable()]
    public class Employee : IEmployee
    {
        public Employee(string idNumber, string firstName, string lastName, int age, string born, EmployeeType type)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Born = born;
            Type = type;
        }

        public Employee()
        {
        }

        public void Show()
        {
            System.Console.WriteLine(ToString());
        }

        public bool IsMatch(IEmployee employee)
        {
            return FirstName.Equals(employee.FirstName) && LastName.Equals(employee.LastName)
                                                        && Born.Equals(employee.Born) && Age == employee.Age &&
                                                        Type.Equals(employee.Type);
        }

        public bool Validate()
        {
            if (IEmployee.IsValid(this))
                return true;
            return false;
        }

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Born { get; set; }
        public EmployeeType Type { get; set; }

        public override string ToString()
        {
            return $"{Type}: {FirstName} {LastName}, age {Age}, born: {Born}, ID: {IdNumber}";
        }
    }
}