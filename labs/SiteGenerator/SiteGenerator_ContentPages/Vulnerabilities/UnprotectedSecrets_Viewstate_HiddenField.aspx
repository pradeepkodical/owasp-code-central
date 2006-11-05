<%@  Language="c#" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - DataValidation : SQL Injection : Advanced</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
        DataValidation : SQL Injection : Advanced</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td>
                    <b>Admin Section Login</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td>
                                <asp:Label ID="lblChallenge" runat="server" Width="117px" CssClass="label1">Challenge</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChallenge" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="1" Enabled="False">123312345</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblResponse" runat="server" Width="117px" CssClass="label1">Response</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtResponse" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="106px" Height="20px" Text="Login" OnClick="btnLoginAdminSection_Click"></asp:Button>
                                <asp:Label ID="lblResponseValue" runat="server" Visible="False">ResponseValue</asp:Label>
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

        if (txtResponse.Text.Trim() == lblResponseValue.Text.Trim())
        {            
            lblErrorMessage.Text = "Correct Response. You are now Logged in.";
            txtChallenge.Visible = false;
            txtResponse.Visible = false;
            lblChallenge.Visible = false;
            lblResponse.Visible = false;
            btnLoginAdminSection.Visible = false;
        }
        else
        {
            lblErrorMessage.Text = "Wrong Response, Please try again.";
            allocatedRamdomNumberToTextBox();
        }
    }

    private void allocatedRamdomNumberToTextBox()
    {
        int iAdminSectionKey = 123456789;
        txtChallenge.Text = new Random().Next().ToString();
        // the response is the Challenge XORed with the AdminSectionKey				
        lblResponseValue.Text = (Int64.Parse(txtChallenge.Text) ^ iAdminSectionKey).ToString();
        Response.Write("<div style=\"COLOR: #f0f0f0;LEFT: 1px; POSITION: absolute; TOP: 1px\">" + lblResponseValue.Text + "</div>");
    }
</script>

