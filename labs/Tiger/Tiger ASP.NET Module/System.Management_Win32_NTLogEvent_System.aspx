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
                "SELECT * FROM Win32_NTLogEvent WHERE Logfile='System'");

            string recordNumber = "";
            foreach (System.Management.ManagementObject queryObj in searcher.Get())
            {
                recordNumber = queryObj["RecordNumber"].ToString();  // We're reading the name just to make sure we're able to do so
                break; // we don't actually want to iterate through all elements of the collection
            }

            Response.Write("<Alert:Red>\r\n");
            Response.Write("Successfully read the record '" + recordNumber + "' from the 'System' event log.");
        }
        catch
        {
            Response.Write("Failed to read the 'System' event log.");
        }
    }       
</script>
