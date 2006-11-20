<%@ Control Language="c#" AutoEventWireup="false" Codebehind="passwordAttackControl.ascx.cs" Inherits="beretta.Web.passwordAttackControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD>
						
<table width="600">
	<tr>
		<td>
			<span class="normal"><strong>Password Dictionary Attack</strong>
				<br>
				<br>
				<asp:Label ID="lblTitleMessage" CssClass="normal" Runat="server"></asp:Label>
			</span>
			<br>
			
			<span class="normal">Saved Password Attack Sessions: &nbsp;
			<asp:DropDownList ID="dropDownPasswordAttackSessions" Width=200 Runat="server"></asp:DropDownList>
			&nbsp; 
			<asp:Button id="cmdStart" Runat="server" Text="Start Attack"></asp:Button>
			<br>
			<br>
			<asp:Panel ID=panelResults Runat=server Visible=False>
			<span class="normal"><strong>Results:</strong></span><br>
			<asp:Label ID="lblAttackResults" CssClass="normal" Runat="server"></asp:Label>
			</asp:Panel>
		</td>
	</tr>
</table>


<br><br>

</td>
</tr>
</table>
</td>
</tr>
</table>
