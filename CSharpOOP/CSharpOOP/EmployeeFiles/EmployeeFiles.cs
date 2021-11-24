using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace CSharpOOP.EmployeeFiles
{
    [Serializable()]
    public class EmployeeFiles<T> where T : IEmployee
    {
        private List<T> Employees { get; }

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

        public bool Save(IWrapper wrapper, List<IEmployee> employee)
        {
            return wrapper.Save(employee);
        }
    }
}