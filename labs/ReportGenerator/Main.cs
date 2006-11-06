using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web;


namespace Owasp.VulnReport
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public class Main_Class
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            VulnReportHelpers.setBaseDirBasedOnExecutionEnvironment();
            VulnReportHelpers.confirmExistenceOfRequiredFilesAndFolders();
            bool bByPassSplashPage = false; // Set this to true to bypass the Splash page (useful when in development mode)

            frmSplashPage sp = new frmSplashPage(bByPassSplashPage);
            if (bByPassSplashPage || (sp.ShowDialog() == DialogResult.OK)) {
                OrgBasePaths obp = OrgBasePaths.GetPaths();
                obp.initiatePaths(); 
                Application.Run(new PenTest_Reporter());
            }
		}
	}

}
