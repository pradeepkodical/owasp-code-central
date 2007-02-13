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
        Response.ContentType = "text/plain"; // Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        
        string[] drives = null;
        try
        {
            // Let's first try to enumerate logical drives
            drives = Environment.GetLogicalDrives();
        }
        catch
        {
            // That failed, but we can still try every possible drive letter...
            drives = new string[] { "A:\\", "B:\\", "C:\\", "D:\\", "E:\\", "F:\\", "G:\\", "H:\\", "I:\\", "J:\\", "K:\\", "L:\\", "M:\\", "N:\\", "O:\\", "P:\\", "R:\\", "S:\\", "T:\\", "U:\\", "V:\\", "W:\\", "X:\\", "Y:\\", "Z:\\" }; 
        }

        int drivesSucceeded = 0;

        string fileName = null;
        string fullPath = null;

        string message = "";
        string messageLine = "";
        
        foreach (string drive in drives)
        {
            messageLine = "";
            
            fileName = System.IO.Path.GetRandomFileName();
            fullPath = System.IO.Path.Combine(drive, fileName);
            bool createSuccess = CreateFile(fullPath);
            if (createSuccess)
            {
                drivesSucceeded++;
                messageLine = drive + " - succesfully created";

                bool writeSuccess = WriteToFile(fullPath);
                if (writeSuccess)
                {
                    if (writeSuccess) messageLine += ", written to";
                    bool readSuccess = ReadFile(fullPath);
                    if (readSuccess) messageLine += ", read from";
                }

                bool deleteSuccess = DeleteFile(fullPath);
                if (deleteSuccess) messageLine += " and deleted";

                messageLine += " a file in the volume root.";
            }
            else
            {
                messageLine = drive + " - failed to create a file in the volume root.";
            }
            
            if (message != "") message += "\r\n";
            message += messageLine;
        }
        
        if (drivesSucceeded != 0)
            Response.Write("<Alert:Red>\r\n");

        Response.Write(message);    
    }

    protected bool CreateFile(string fullPath)
    {
        bool success = false;

        System.IO.FileStream fs = null;

        try
        {
            fs = System.IO.File.Create(fullPath);
            success = true;
        }
        catch { }
        finally
        {
            if (fs != null) fs.Close();
        }

        return success;
    }

    protected bool WriteToFile(string fullPath)
    {
        bool success = false;

        System.IO.FileStream fs = null;

        try
        {
            fs = System.IO.File.Open(fullPath, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite | System.IO.FileShare.Delete);
            fs.WriteByte(42);

            success = true;
        }
        catch { }
        finally
        {
            if (fs != null) fs.Close();
        }

        return success;
    }

    protected bool ReadFile(string fullPath)
    {
        int number = 0;

        System.IO.FileStream fs = null;

        try
        {
            fs = System.IO.File.Open(fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite | System.IO.FileShare.Delete);
            number = fs.ReadByte();
        }
        catch { }
        finally
        {
            if (fs != null) fs.Close();
        }

        return (number == 42);
    }

    protected bool DeleteFile(string fullPath)
    {
        bool success = false;

        try
        {
            System.IO.File.Delete(fullPath);
            success = true;
        }
        catch { }

        return success;
    }
</script>