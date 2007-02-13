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
