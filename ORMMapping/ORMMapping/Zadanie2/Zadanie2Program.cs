using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ORMMapping.Zadanie1;
using Configuration = NHibernate.Cfg.Configuration;

namespace ORMMapping.Zadanie2
{
    public static class EmployeeConfigurator
    {
        public static void SetShift(int value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings["Shift"] == null)
                {
                    settings.Add("Shift", value.ToString());
                }
                else
                {
                    settings["Shift"].Value = value.ToString();
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public static int GetShift()
        {
            try
            {
                var result = ConfigurationManager.AppSettings["Shift"] ?? "-1";
                return Convert.ToInt32(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return -1;
            }
        }
    }

    public class SqlConfig
    {
        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, true);
        }

        public static ISessionFactory CreateSessionFactory(params Type[] mappingTypes)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile("database.sqlite"))
                .Mappings(m =>
                {
                    foreach (var mappingType in mappingTypes)
                        m.FluentMappings.Add(mappingType);
                })
                .ExposeConfiguration(BuildSchema) //Call of ours BuildSchema
                .BuildSessionFactory();
        }
    }

    public static class CaesarShift
    {
        private static char Shift(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;

            var offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char) ((((ch + key) - offset) % 26) + offset);
        }

        public static string Encode(string input, int key)
        {
            var output = string.Empty;

            foreach (char ch in input)
                output += Shift(ch, key);

            return output;
        }

        public static string Decode(string input, int key)
        {
            return Encode(input, 26 - key);
        }
    }

    public enum EmployeeType
    {
        Employee,
        Manager,
        CEO,
        CTO
    }

    public interface IWrapper
    {
        const string Path = "";
        bool Save(List<IEmployee> data);
    }

    public class SqlWrapper : IWrapper
    {
        public bool Save(List<IEmployee> data)
        {
            if (data == null) return false;

            var sessionFactory = Config.CreateSessionFactory(typeof(EmployeeMap));
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            {
                data.ForEach(e =>
                {
                    if (session.Get<IEmployee>(e.IdNumber) != null) session.Save(e);
                });
                transaction.Commit();
                return true;
            }
        }
    }

    public class JsonWrapper : IWrapper
    {
        public bool Save(List<IEmployee> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                File.WriteAllText(IWrapper.Path + "employeeFiles.json", json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Troubles during file saving :(");
            }

            Console.WriteLine("File saved!");
            return true;
        }
    }

    public class TxtWrapper : IWrapper
    {
        public bool Save(List<IEmployee> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                File.WriteAllText(IWrapper.Path + "employeeFiles.txt", json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Troubles during file saving :(");
            }

            Console.WriteLine("File saved!");
            return true;
        }
    }

    public class XmlWrapper : IWrapper
    {
        public bool Save(List<IEmployee> data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<IEmployee>));
                TextWriter fileStream = new StreamWriter(IWrapper.Path + "employeeFiles.xml");
                serializer.Serialize(fileStream, data);
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("File saved!");
            return true;
        }
    }

    public interface IEmployee
    {
        public void Show();
        public bool IsMatch(IEmployee employee);
        public bool Validate();
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType Type { get; set; }
        public string Born { get; set; }
        public int Age { get; set; }

        protected internal static bool IsValid(IEmployee t)
        {
            if (t == null)
            {
                return false;
            }

            if (t.Age <= 0 || string.IsNullOrEmpty(t.FirstName) || string.IsNullOrEmpty(t.LastName)
                || string.IsNullOrEmpty(t.Born) || string.IsNullOrEmpty(t.IdNumber) ||
                string.IsNullOrEmpty(t.Type.ToString()))
            {
                return false;
            }

            return true;
        }
    }

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
            Console.WriteLine(ToString());
        }

        public bool IsMatch(IEmployee employee)
        {
            return FirstName.Equals(employee.FirstName) && LastName.Equals(employee.LastName)
                                                        && Born.Equals(employee.Born) && Age == employee.Age 
                                                        && Type.Equals(employee.Type);
        }

        public bool Validate()
        {
            return IEmployee.IsValid(this);
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

    public class EmployeeMap : ClassMap<IEmployee>
    {
        public EmployeeMap()
        {
            Table("Employee");
            Id(x => x.IdNumber);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Type).CustomType<EmployeeType>();
            Map(x => x.Age);
            Map(x => x.Born);
        }
    }
}