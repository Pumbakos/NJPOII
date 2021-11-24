using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CSharpOOP.EmployeeFiles
{
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
}