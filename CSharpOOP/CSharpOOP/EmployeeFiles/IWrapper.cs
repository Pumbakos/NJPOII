using System.Collections.Generic;

namespace CSharpOOP.EmployeeFiles
{
    public interface IWrapper
    {
        const string Path =
            "C:\\Users\\Pumbakos\\Desktop\\NJPOII\\CSharpOOP\\CSharpOOP\\EmployeeFiles\\output\\";
        bool Save(List<IEmployee> data);
    }
}