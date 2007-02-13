<%--
Tiger ASP.NET Module
Copyright (C) 2007 Boris Maletic

This program is free software; you can redistribute it and/or modify it under 
the terms of the GNU General Public License as published by the Free Software Foundation;
either version 2 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program;
if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
--%>

<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
       
        System.Diagnostics.Process process = null;
        bool success = false;
        string fileToExecute = "";
        bool useShell = false;
        
        try
        {
            fileToExecute = Request.QueryString["file"];
            useShell = (Request.QueryString["useshell"] != null);
        }
        catch {}
        
        try
        {
            process = new System.Diagnostics.Process();
            //process.StartInfo.Arguments = "";
            process.StartInfo.FileName = fileToExecute;
            process.StartInfo.UseShellExecute = useShell; 
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            
            success = process.Start();
        }
        catch { }

        int? exitCode = null;
        
        if (success)
        {
            try
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit();
                }

                exitCode = process.ExitCode;
                
                process.Dispose();
            }
            catch {}
        }

        if (success)
        {
            Response.Write("<Alert:Red>\r\n");
            Response.Write("Successfully executed the '" + fileToExecute + "' file. ");
            if (exitCode != null)
                Response.Write("Exit code was '" + exitCode.ToString() + "'");
                
        }
        else
        {
            Response.Write("Failed to execute the '" + fileToExecute + "' file.");
        }
    }       
</script>
