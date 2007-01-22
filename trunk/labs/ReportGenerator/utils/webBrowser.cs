using System;
using System.Windows.Forms;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for webBrowser.
	/// </summary>
	public class webBrowser
	{
		public webBrowser()
		{
		}

		public static void openFileInWebBrowser(AxSHDocVw.AxWebBrowser axWBtoUse, string strPathToFileToOpen)
		{
			axWBtoUse.Visible= true;
			object ipNull = IntPtr.Zero;
			axWBtoUse.Navigate(strPathToFileToOpen,ref ipNull,ref ipNull,ref ipNull,ref ipNull);
		}

        public static void openFileInWebBrowser(WebBrowser wbWBtoUse, string strPathToFileToOpen)
        {
            wbWBtoUse.Visible = true;
            wbWBtoUse.Navigate(strPathToFileToOpen);
        }
	}
}
