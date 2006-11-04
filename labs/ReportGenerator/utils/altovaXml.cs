using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for altovaXml.
	/// </summary>
	public class altovaXml
	{
		public altovaXml()
		{
		}

		public static string processFiles(string stringPathToTempFile,string stringPathToXMLfile,string stringPathToXSLfile,bool bShowResults, ref bool bCancelPdfReportGeneration)
		{			
			bCancelPdfReportGeneration = false;
			try 
			{
				Process pProcess = new Process();
				pProcess.StartInfo.RedirectStandardOutput = true;
				pProcess.StartInfo.UseShellExecute = false;				
				
				pProcess.StartInfo.Arguments = " /xslt2   \""+stringPathToXSLfile+"\" /in \""+stringPathToXMLfile+"\"  /out \""+stringPathToTempFile +"\"";
				
				Clipboard.SetDataObject(pProcess.StartInfo.Arguments);

				pProcess.StartInfo.FileName = @"C:\Program Files\Altova\AltovaXML2006\AltovaXML.exe";
				if (bShowResults) 
				{
					pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
					
				}
				else
				{
					pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				};
				pProcess.Start();
				StreamReader srProcessStOut = pProcess.StandardOutput;
				while (! pProcess.HasExited)
				{
					pProcess.Refresh();
					Thread.Sleep(100);
					Application.DoEvents();
					if (bCancelPdfReportGeneration)
					{
						pProcess.Kill();						
						return "AltovaXml Creation process terminated";						
					}
				}			
				string strProcessStout  = srProcessStOut.ReadToEnd();
				return strProcessStout;				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);	
				return ex.Message;
			}
		}
	}
}
