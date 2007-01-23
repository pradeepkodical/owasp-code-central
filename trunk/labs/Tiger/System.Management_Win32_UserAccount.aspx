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
                new System.Management.ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_UserAccount");

            int userCount = 0;
            string userAccountList = "";
            
            foreach (System.Management.ManagementObject queryObj in searcher.Get())
            {
                if (userAccountList != "") userAccountList += ", ";
                userAccountList += queryObj["Name"].ToString();
                userCount++;
            }

            Response.Write("<Alert:Red>\r\n");
            Response.Write("Successfully enumerated user accounts:\r\n" + userAccountList);
        }
        catch
        {
            Response.Write("Failed to enumerate user accounts.");
        }
    }       
</script>