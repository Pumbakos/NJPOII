using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CSharpOOP.EmployeeFiles
{
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
}