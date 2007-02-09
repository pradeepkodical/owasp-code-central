<%@  Language="c#"  %>
<%@Import Namespace="System.IO" %>

<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - Show Directories</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
         Show Directories</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td>
                    <b> Show Directories</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="lblDirectoryQuestion" runat="server" Width="178px" CssClass="label1">Directory To List</asp:Label>
                            </td>
                            <td style="width: 322px">
                                <asp:TextBox ID="txtDirectoryToList" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="1" Width="300px">C:\</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 29px">
                                &nbsp;</td>
                            <td style="width: 322px; height: 29px">
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="159px" Height="27px" Text="Show" OnClick="btnLoginAdminSection_Click"></asp:Button>     
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                           <pre>                                <asp:Label ID="lblDirectoryList" runat="server" Width="503px" CssClass="label1"></asp:Label>
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
        lblDirectoryList.Text = "";
        foreach (string di in Directory.GetDirectories(txtDirectoryToList.Text))
       {
           lblDirectoryList.Text += di + "<br/>";
       };    
    }  
    
</script>

