<%@ Page Language="C#" %>
<%@ Assembly Name="System.Management, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/plain"; // Response.ContentType = "text/plain";
        Response.ContentEncoding = System.Text.Encoding.UTF8;

        try
        {
            System.Management.ManagementObjectSearcher searcher =
                new System.Management.ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_LogicalDisk");

            string disks = "";
            
            foreach (System.Management.ManagementObject queryObj in searcher.Get())
            {
                if (disks != "") disks += ", ";
                disks += queryObj["Name"].ToString();
            }

            if (disks != "")
            {
                Response.Write("<Alert:Red>\r\n");
                Response.Write("Successfully enumerated logical disks: " + disks);
            }
        }
        catch
        {
            Response.Write("Failed to enumerate logical disks.");
        }
    }       
</script>
