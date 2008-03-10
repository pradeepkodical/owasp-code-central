using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Owasp.Osg.Controller.Utilities
{
    static class SiteTemplateManager
    {
        public static string[] GetTemplateFileNames()
        {
            string templateFolderPath = null;

            try
            {
                templateFolderPath = System.Configuration.ConfigurationManager.AppSettings["ProjectTemplatesFolderPath"];
            }
            catch { }

            if (string.IsNullOrEmpty(templateFolderPath))
                templateFolderPath = "Project Templates";

            try
            {
                if (!System.IO.Path.IsPathRooted(templateFolderPath))
                    templateFolderPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, templateFolderPath);

                return Directory.GetFiles(templateFolderPath, "*.osgt", SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return null;
            }
        }
    }
}
