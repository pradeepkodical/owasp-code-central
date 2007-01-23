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
                "SELECT * FROM Win32_Service");
            
            System.Management.ManagementObjectCollection results = searcher.Get();

            int serviceCount = 0;
            string tempName = "";
            foreach (System.Management.ManagementObject queryObj in searcher.Get())
            {
                tempName = queryObj["Name"].ToString(); // We're reading the name just to make sure we're able to do so
                serviceCount++;
            }

            Response.Write("<Alert:Red>\r\n");
            Response.Write("Successfully enumerated " + serviceCount.ToString() + " services.");
        }
        catch
        {
            Response.Write("Failed to enumerate services.");
        }
    }       
</script>
