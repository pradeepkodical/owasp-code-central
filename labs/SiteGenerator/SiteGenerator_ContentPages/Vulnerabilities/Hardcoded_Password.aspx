<%@  Language="c#"  Debug="true" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - Hard-Coded Password</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>Hard-Coded Password</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td><b>Hard-Coded Password</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td>Password:</td>
                            <td><asp:TextBox ID="password" runat=server /></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:Label ID="userMessage" runat="server" Visible="false"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 29px">&nbsp;</td>
                            <td style="width: 322px; height: 29px">
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="159px" Height="27px" Text="Login" OnClick="btnLoginAdminSection_Click"></asp:Button>                              
                            </td>
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
        if (password.Text == "password")
        {
            userMessage.Text = "Congratulations you are now logged in";
            userMessage.Visible = true;
        }
        else
        {
            userMessage.Text = "Wrong password the password is 'password'";
            userMessage.Visible = true;
        }
    }  
    
</script>

