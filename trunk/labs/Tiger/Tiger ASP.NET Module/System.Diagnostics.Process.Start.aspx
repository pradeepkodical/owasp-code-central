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
