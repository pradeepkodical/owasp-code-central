using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for processes.
	/// </summary>
	public class processes
	{
		public processes()
		{
		}

		public static bool executeProcessWithParams(string stringPathToFileToExecute,string stringArguments,bool bShowCmdWindow, ref bool bCancelProcessExecution)
		{			
			bCancelProcessExecution = false;
			try 
			{
				Process pProcess = new Process();
			
				pProcess.StartInfo.Arguments = stringArguments;
				pProcess.StartInfo.FileName = stringPathToFileToExecute;
				if (bShowCmdWindow) 				
					pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;									
				else				
					pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;									
				pProcess.Start();
				while (! pProcess.HasExited)
				{
					pProcess.Refresh();
					Thread.Sleep(100);
					Application.DoEvents();
					if (bCancelProcessExecution)
					{
						pProcess.Kill();
						MessageBox.Show("Process execution canceled");
						return false;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);	
				return false;
			}
		}
	}
}
