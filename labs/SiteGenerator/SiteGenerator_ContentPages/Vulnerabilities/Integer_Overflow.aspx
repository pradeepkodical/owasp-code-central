<%@  Language="c#"  Debug="true" ValidateRequest="false" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - Integer Overflow</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>Integer Overflow</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td><b>Integer Overflow</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td>Price for a bag o' junk?</td>
                            <td><asp:TextBox ID="price" runat="server">100</asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ValidationExpression="[0-9]*" Width="209px" ControlToValidate="price">The price must be a number</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:Label ID="setPrice" runat="server" Visible="false"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 29px">&nbsp;</td>
                            <td style="width: 322px; height: 29px">
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="159px" Height="27px" Text="Check out" OnClick="btnLoginAdminSection_Click"></asp:Button>                              
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
        try
        {
            unchecked
            {
                Int32 newPrice = Int32.Parse(price.Text);
                setPrice.Text = (newPrice * 100).ToString();
            }
        }
        catch
        {
            setPrice.Text = "Oh we don't want to have you pay that much, try again (say 1009993333)";
        }
        setPrice.Visible = true;
    }  
    
</script>

