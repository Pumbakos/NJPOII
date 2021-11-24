using System;
using System.Configuration;

namespace CSharpOOP.EmployeeFiles
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
}