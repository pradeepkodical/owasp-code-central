using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Owasp.SiteGenerator.utils
{
    public class files
    {

        public static string GetFileContent(string strFile)
        {
            try
            {
                FileStream fs = File.OpenRead(strFile);
                if (fs == null)
                    return string.Empty;
                StreamReader sr = new StreamReader(fs);
                if (sr == null)
                    return string.Empty;
                string strContent = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                return strContent;
            }
            catch
            {
                return "";
            }
        }

        public static void WriteFileContent(string strFile, string strFileContent)
        {
            try
            {
                if (File.Exists(strFile))
                {
                    File.Delete(strFile);
                }
                using (FileStream fs = File.Create(strFile))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes(strFileContent);

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
