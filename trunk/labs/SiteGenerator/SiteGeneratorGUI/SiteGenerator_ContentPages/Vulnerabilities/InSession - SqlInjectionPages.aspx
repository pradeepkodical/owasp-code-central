<%@  Language="c#" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - In Session - Sql Injection Pages</title>
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
        <ul>
            <li><a href="ViaSession_DataValidation_SqlInjection_Basic.aspx?user_id=1">SqlInjection Basic
            </a></li>
            <li><a href="ViaSession_DataValidation_SqlInjection_Medium.aspx?user_id=1">SqlInjection Medium
            </a></li>
            <li><a href="ViaSession_DataValidation_SqlInjection_Advanced.aspx?user_id=1">SqlInjection
                Advanced </a></li>            
        </ul>
       <br /> 
         <asp:Button ID="Button1" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="106px" Height="20px" Text="Logout" OnClick="btnLogout_Click"></asp:Button>
                                    
        <%                                                      
            }
            else
            {       
        %>
            You are Not Logged in, <a href= "InSession - Login.aspx">please use this form to Login</a>         
        <%
            }
        %>
    </form>
</body>
</html>

<script runat="server">    
    protected void btnLogout_Click(object sender, System.EventArgs e)
    {
        Session["LoggedIn"] = "";
    } 
</script>

