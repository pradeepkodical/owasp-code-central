<%@ Control Language="c#" AutoEventWireup="false" Codebehind="selectPage.ascx.cs" Inherits="beretta.Web.selectPage" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>



						
						
<br>
<h1>View Raw Form Submission  </h1>



						<br>
<span class=normal>
When constructing Payloads it can be useful to modify existing form submissions. <br><br>
Enter the url you wish to view the form submission data in the text box below and click the get site button. <br>
When the site is retrieved click a submit button on its page and the form submission contents will be redirected and displayed.
</span>
<br><br>


<span class=normal>Url: &nbsp;</span>
<asp:TextBox ID="txtUrl" Runat="server" Width="500">http://www.google.com</asp:TextBox>
&nbsp;
<asp:Button ID="cmdGet" Text="Get Site" Runat="server"></asp:Button>
<br><br>
</form>




<br><br>


<asp:Panel ID=panelRetrievedSite Visible=False Runat=server>

<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD>
<br>						
<asp:Panel ID="panelHtml" Runat="server"></asp:Panel>

<br>
</td>
</tr>
</table>
</td>
</tr>
</table>
</asp:Panel>