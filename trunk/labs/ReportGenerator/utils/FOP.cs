using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for FOP.
	/// </summary>
	public class FOP
	{
		public static bool genereteAndCreatePDF(string stringPathToTempPdfFile,string stringPathToPDFEngine,string stringPathToXMLfile,string stringPathToXSL_FO_file,bool bShowFOPResults, ref bool bCancelPdfReportGeneration)
		{			
			bCancelPdfReportGeneration = false;
			try 
			{
				Process objFOP_XSLFO_Process = new Process();
			
				objFOP_XSLFO_Process.StartInfo.Arguments = " -xsl  \""+stringPathToXSL_FO_file+"\" -xml \""+stringPathToXMLfile+"\"  -pdf \""+stringPathToTempPdfFile +"\"";

				if (bShowFOPResults) 
				{
					objFOP_XSLFO_Process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
					objFOP_XSLFO_Process.StartInfo.FileName = stringPathToPDFEngine + "\\fop_Custom_with_pause.bat";
				}
				else
				{
					objFOP_XSLFO_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					objFOP_XSLFO_Process.StartInfo.FileName = stringPathToPDFEngine + "\\fop_custom.bat";
				};

                if (File.Exists(objFOP_XSLFO_Process.StartInfo.FileName))
                {
                    objFOP_XSLFO_Process.Start().ToString();
                    while (!objFOP_XSLFO_Process.HasExited)
                    {
                        objFOP_XSLFO_Process.Refresh();
                        Thread.Sleep(100);
                        Application.DoEvents();
                        if (bCancelPdfReportGeneration)
                        {
                            objFOP_XSLFO_Process.Kill();
                            MessageBox.Show("Fop Creation process terminated");
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("The FOP engine can not be found at: " + objFOP_XSLFO_Process.StartInfo.FileName);
                    return false;
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);	
				return false;
			}
		}
	}
}
