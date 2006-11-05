using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Owasp.SiteGenerator.utils
{
    class processes
    {
            public static void createProcess(string strProcessToCreate, string strArguments)                
            {
                Process pProcess = new Process();
                pProcess.StartInfo.FileName = strProcessToCreate;
                pProcess.StartInfo.Arguments = strArguments;
                pProcess.Start();
            }
    }
}
