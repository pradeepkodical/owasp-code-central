<%@  Language="c#" %>
<% @Import Namespace="System.IO" %>
<!-- Begin_Default_Vulnerability_HTML_code -->
<html>
<head>
    <title>SiteGenerator - Write File on Server</title>
    <link rel="stylesheet" type="text/css" href="/style.css">
</head>
<body>
    <!--#include virtual="\SiteGenerator_Banner.html" -->
    <h3>
        Write File on Server</h3>
    <hr />
    <form runat="server">
        <table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
            <tr bgcolor="#d2dae4">
                <td>
                    <b>Write File on Server</b></td>
            </tr>
            <tr>
                <td height="100">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:Label>
                    <table border="0" cellpadding="6">
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="lbl" runat="server" Width="178px" CssClass="label1">Target File Name</asp:Label>
                            </td>
                            <td style="width: 322px">
                                <asp:TextBox ID="txtTargetFileName" runat="server" CssClass="txtBox2" TextMode="SingleLine"
                                    TabIndex="1" Width="300px"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" ForeColor="Silver" Text="C:\SiteGenerator.test.txt"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 130px" valign="top">
                                <asp:Label ID="Label1" runat="server" CssClass="label1" Width="178px">File Contents</asp:Label>
                            </td>
                            <td style="width: 322px">
                                &nbsp;<asp:TextBox ID="txtFileContents" runat="server" Height="101px" Width="300px">Hello World (SiteGenerator Test)</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 130px; height: 29px">
                                &nbsp;</td>
                            <td style="width: 322px; height: 29px">
                                <asp:Button ID="btnLoginAdminSection" TabIndex="2" runat="server" CssClass="butnstyle2"
                                    Width="159px" Height="27px" Text="Write File" OnClick="btnLoginAdminSection_Click">
                                </asp:Button>
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
       WriteFileContent(txtTargetFileName.Text,txtFileContents.Text);
       lblErrorMessage.Text = "File " + txtTargetFileName.Text + "  sucessfully Created"; 
    }
    
    public static void WriteFileContent(string strFile,string strFileContent)
        {
            if (File.Exists(strFile))
            {                
                File.Delete(strFile);
            }
            using (FileStream fs = File.Create(strFile))
            {
                Byte[] info =
                    new UTF8Encoding(true).GetBytes(strFileContent);

                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }
</script>

