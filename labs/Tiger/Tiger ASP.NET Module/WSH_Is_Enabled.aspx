<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        
        object wshObject = null;
        
        try
        {
            wshObject = Activator.CreateInstance(Type.GetTypeFromProgID("WSCRIPT.SHELL"));
        }
        catch { }

        string comment = null;

        if (wshObject != null)
            comment = "The WSH (WSCRIPT.SHELL) object has been suscessfully created.";
        else
            comment = "The WSH (SWSCRIPT.SHELL) object could not be created.";

        if (wshObject != null)
            Response.Write("<Alert:Red>\r\n");

        Response.Write(comment);
    }       
</script>
