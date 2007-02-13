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

