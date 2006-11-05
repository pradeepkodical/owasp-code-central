<%@  Language="c#" %>
<%@Import Namespace="System.IO" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - Show File Contents</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body alink="#00">
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
        Show File Contents</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td>
                    <b>Show File Contents</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="lbl" runat="server" Width="178px" CssClass="label1">Which File Do You want to see</asp:Label>
                            </td>
                            <td style="width: 322px">
                                <asp:TextBox ID="txtFileToFetch" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="1" Width="300px">C:\WINDOWS\system32\drivers\etc\hosts</asp:TextBox>                                 
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 29px">
                                &nbsp;</td>
                            <td style="width: 322px; height: 29px">
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="159px" Height="27px" Text="Show File Contents" OnClick="btnLoginAdminSection_Click"></asp:Button>                              
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                           <pre>                                <asp:Label ID="lblFileContents" runat="server" Width="503px" CssClass="label1">[File Contents]</asp:Label>
                                &nbsp;
                            </pre> 
                        </tr> 
                    </table>
                    <asp:Label ID="Label1" runat="server" ForeColor="Silver" Text="f:\_research\wwwroot\hacmeBank_v2.15\hacmeBank_v2\HacmeBank_v2_Website\web.config "></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>

<script runat="server">
   
     
    protected void btnLoginAdminSection_Click(object sender, System.EventArgs e)
    {      
        lblFileContents.Text = Server.HtmlEncode(GetFileContent(txtFileToFetch.Text));             
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

