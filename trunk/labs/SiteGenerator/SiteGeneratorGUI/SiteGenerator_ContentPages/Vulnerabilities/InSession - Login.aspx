<%@  Language="c#" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - In Session - Login</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
        In Session - Login</h3>
    <hr />    
    <form runat="server">
        <% 
            if (Session["LoggedIn"] == "yes")
            {
                Response.Write("You Are Logged in <br/><br>");
                %>
               <asp:Button ID="Button1" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="106px" Height="20px" Text="Logout" OnClick="btnLogout_Click"></asp:Button>
                                   
                <%                                                      
            }
            else
            {
           %> 
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td>
                    <b> Login Page</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td>
                                <asp:Label ID="lblUsername" runat="server" Width="117px" CssClass="label1">User Name</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="1" Enabled="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPassword" runat="server" Width="117px" CssClass="label1">Password</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnLogin" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="106px" Height="20px" Text="Login" OnClick="btnLoginAdminSection_Click"></asp:Button>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
       <%
            }
            %> 
    </form>
</body>
</html>

<script runat="server">
    
    protected void btnLogout_Click(object sender, System.EventArgs e)
    {
        Session["LoggedIn"] = "no";
        txtPassword.Text = "";
        txtUsername.Text = "";
        lblErrorMessage.Text = "";
        txtPassword.Visible = true;
        txtUsername.Visible = true;
        lblPassword.Visible = true;
        lblUsername.Visible = true;
        btnLogin.Visible = true; 
        //Response.Redirect("InSession - Login.aspx"); 
    } 
    protected void btnLoginAdminSection_Click(object sender, System.EventArgs e)
    {
        if ((txtUsername.Text == "admin" && txtPassword.Text == "") ||
            (txtUsername.Text == "admin" && txtPassword.Text == "admin") ||
            (txtUsername.Text == "admin" && txtPassword.Text == "password") ||
            (txtUsername.Text == "test" && txtPassword.Text == "") ||
            (txtUsername.Text == "test" && txtPassword.Text == "test") ||
            (txtUsername.Text == "test" && txtPassword.Text == "password") ||
            (txtUsername.Text == "username" && txtPassword.Text == "") ||
            (txtUsername.Text == "username" && txtPassword.Text == "username") ||
            (txtUsername.Text == "username" && txtPassword.Text == "password") ||
            (txtUsername.Text == "a" && txtPassword.Text == "") ||
            (txtUsername.Text == "a" && txtPassword.Text == "a"))
        {
            Session["LoggedIn"] = "yes"; 
            lblErrorMessage.Text = "Login Credentals correct. You are now Logged in.";
            txtPassword.Visible = false;
            txtUsername.Visible = false;
            lblPassword.Visible = false;
            lblUsername.Visible = false;
            btnLogin.Visible = false;
        }
        else
        {
            lblErrorMessage.Text = "Wrong Response, Please try again.";
            Session["LoggedIn"] = "no";
        }            
    }

</script>

