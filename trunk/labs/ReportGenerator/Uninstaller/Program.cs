using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace Uninstaller
{
    class Program
    {
        static void Main()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            //delete FOP and ORG_CONFIG_FILES
             string orgConfigDir = "C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\ORG_CONFIG_FILES\\";
             string fopDir = "C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\FOP\\";
             if (File.Exists("C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\FOP.zip"))
             {
                 File.Delete("C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\FOP.zip");
             }
             if (File.Exists("C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\ORG_CONFIG_FILES.zip"))
             {    
                 File.Delete("C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\ORG_CONFIG_FILES.zip");
             }
             if (File.Exists("C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\AuthenticPlugin.zip")) 
             {    
                File.Delete("C:\\Program Files\\ABN AMRO\\OWASP_Report_Generator\\AuthenticPlugin.zip");
             }
             try
             {
                 if (Directory.Exists(orgConfigDir))
                 {
                     Directory.Delete(orgConfigDir, true);
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: Could not delete file: {0}", ex.Message);
             }
             try
             {
                 if (Directory.Exists(fopDir))
                 {
                     Directory.Delete(fopDir, true);
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: Could not delete file: {0}", ex.Message);
             }
            foreach (string argument in arguments)
            {
                string[] parameters = argument.Split('=');
                if (parameters[0].ToLower() == "/u")
                {
                    string productCode = parameters[1];
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = System.IO.Path.Combine(path, "msiexec.exe");
                    process.StartInfo.Arguments = string.Concat(" /x ", productCode);
                    process.Start();
                }
            }
        }


    }
}
