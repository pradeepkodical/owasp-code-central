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
        /// <summary>
        /// Note: the bRedirectOutput is not fully implemented
        /// </summary>
        /// <param name="stringPathToTempFile"></param>
        /// <param name="stringPathToXMLfile"></param>
        /// <param name="stringPathToXSLfile"></param>
        /// <param name="bShowResults"></param>
        /// <param name="bCancelPdfReportGeneration"></param>
        /// <param name="bRedirectOutput"> I added this parameter since its inclusion disabled the StandardOutput and StandardError being shown</param>
        /// <returns></returns>
        public static string processFiles(string stringPathToTempFile, string stringPathToXMLfile, string stringPathToXSLfile, bool bShowResults, ref bool bCancelPdfReportGeneration, bool bRedirectOutput)
		{			
			bCancelPdfReportGeneration = false;
			try 
			{                
				Process pProcess = new Process();
				pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.RedirectStandardError = true;
				pProcess.StartInfo.UseShellExecute = false;                               
				
				pProcess.StartInfo.Arguments = "/xslt2   \""+stringPathToXSLfile+"\" /in \""+stringPathToXMLfile+"\"";
                if (bRedirectOutput)
                    pProcess.StartInfo.Arguments += "  /out \"" + stringPathToTempFile + "\"";
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
                pProcess.ErrorDataReceived += new DataReceivedEventHandler(pProcess_ErrorDataReceived);
                bool bProcessStartResult = pProcess.Start();
                StreamReader srProcessStOut = pProcess.StandardOutput;
                StreamReader srProcessStErr = pProcess.StandardError;
				                
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
                string strProcessOutputAndErr  = srProcessStOut.ReadToEnd() + srProcessStErr.ReadToEnd();                

                return strProcessOutputAndErr;				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);	
				return ex.Message;
			}
		}

        static void pProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }
	}
}
