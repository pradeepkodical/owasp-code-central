using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Owasp.SiteGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigurationManager.AppSettings["ContentPagesRoot"] = Path.GetFullPath(
                Path.Combine(Environment.CurrentDirectory, @"..\SiteGenerator_ContentPages"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGui());
        }
    }
}