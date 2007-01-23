<%@ Page Language="C#" %>

<script runat="server">
        
    [System.Runtime.InteropServices.DllImport("Advapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    public static extern int RevertToSelf();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        
        string nameBefore = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        int apiCallResult = RevertToSelf();

        if (apiCallResult == 0)
        {
            Response.Write("RevertToSelf() API call failed.");
        }
        else
        {
            string nameAfter = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            if (nameBefore == nameAfter)
            {
                Response.Write("<Alert:Yellow>\r\n");
                Response.Write("RevertToSelf() API call succeeded. However, the identity used did not change.");
            }
            else
            {
                Response.Write("<Alert:Red>\r\n");
                Response.Write("RevertToSelf() API call succeeded. The identity used changed from '" + nameBefore + "' to '" + nameAfter + "'.");
            }
        }
    }  
</script>

