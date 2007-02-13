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
