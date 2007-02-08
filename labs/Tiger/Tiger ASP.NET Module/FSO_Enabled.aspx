<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        
        object wshObject = null;
        
        try
        {
            wshObject = Activator.CreateInstance(Type.GetTypeFromProgID("Scripting.FileSystemObject"));
        }
        catch { }

        string comment = null;

        if (wshObject != null)
            comment = "The FSO (Scripting.FileSystemObject) object has been suscessfully created.";
        else
            comment = "The FSO (Scripting.FileSystemObject) object could not be created.";

        if (wshObject != null)
            Response.Write("<Alert:Red>\r\n");

        Response.Write(comment);
    }       
</script>
