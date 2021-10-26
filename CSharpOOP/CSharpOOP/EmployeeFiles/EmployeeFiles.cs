using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace CSharpOOP.EmployeeFiles
{
    [Serializable()]
    public class EmployeeFiles<T> where T : IEmployee, new()
    {
        private List<T> Employees { get; }

        private const string Path =
            "C:\\Users\\Pumbakos\\Desktop\\NJPOII\\CSharpOOP\\CSharpOOP\\EmployeeFiles\\output\\";

        public EmployeeFiles(List<T> employees)
        {
            Employees = employees;
        }

        public bool AddEmployee(T employee)
        {
            if (employee.Validate())
            {
                Employees.Add(employee);
                return true;
            }

            return false;
        }

        public bool RemoveEmployee(T employee)
        {
            return Employees.Remove(employee);
        }

        public void Show()
        {
            Employees.ForEach(e => e.Show());
        }

        public List<T> Validate()
        {
            var invalid = new List<T>();
            foreach (var employee in Employees)
            {
                if (!IEmployee.IsValid(employee))
                    invalid.Add(employee);
            }

            return invalid;
        }

        public List<T> Find(string data)
        {
            return GetAttribute(data, Employees);
        }

        private struct ReturnPair
        {
            public bool Matched;
            public T Employee;
        }

        private ReturnPair Match(ref string attr, T e)
        {
            if (attr.Equals(e.IdNumber) ||
                attr.Equals(e.FirstName) ||
                attr.Equals(e.LastName) ||
                attr.Equals(e.Born) ||
                attr.Equals(e.Type.ToString()) ||
                attr.Equals(e.Age.ToString()))
            {
                return new ReturnPair {Matched = true, Employee = e};
            }

            return new ReturnPair {Matched = false, Employee = default};
        }

        private List<T> GetAttribute(string attr, List<T> list)
        {
            List<T> retList = new();
            foreach (var e in list)
            {
                var returnPair = Match(ref attr, e);
                if (returnPair.Matched)
                    retList.Add(returnPair.Employee);
            }

            return retList;
        }

        public bool Save(FileFormat format)
        {
            switch (format)
            {
                case FileFormat.Json:
                {
                    try
                    {
                        var json = JsonSerializer.Serialize(Employees);
                        File.WriteAllText(Path + "employeeFiles.json", json);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Troubles during file saving :(");
                    }

                    Console.WriteLine("File saved!");
                    return true;
                }
                    break;
                case FileFormat.Txt:
                {
                    try
                    {
                        var json = JsonSerializer.Serialize(Employees);
                        File.WriteAllText(Path + "employeeFiles.txt", json);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Troubles during file saving :(");
                    }

                    Console.WriteLine("File saved!");
                    return true;
                }
                case FileFormat.Xml:
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(List<T>));
                        TextWriter fileStream = new StreamWriter(Path + "employeeFiles.xml");
                        serializer.Serialize(fileStream, Employees);
                        fileStream.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        //throw; ?
                    }

                    Console.WriteLine("File saved!");
                    return true;
                }
            }

            return false;
        }
    }
}