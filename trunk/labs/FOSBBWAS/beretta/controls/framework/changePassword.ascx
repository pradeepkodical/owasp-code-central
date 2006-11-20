<%@ Control Language="c#" AutoEventWireup="false" Codebehind="changePassword.ascx.cs" Inherits="sourceControl.controls.changePassword" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<h1>Change Password</h1>

<table width=600>
	
	<asp:Panel ID="panelError" Runat="server">
	<tr>
		<td>
			
			&nbsp;
			<BR>
				<asp:Label id="lblError" Runat="server" CssClass="error"></asp:Label>
				
				<BR>
			
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
	</tr>
	</asp:Panel>
	
	<tr>
		<td>
			&nbsp;<span class="normal">Existing Password:</span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtExistingPassword" TextMode="Password" Width="300" Runat="server"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;<span class="normal">Password:</span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtPassword" TextMode="Password" Width="300" Runat="server"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;<span class="normal">Confirm Password:</span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtConfirmPassword" TextMode="Password" Width="300" Runat="server"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;<asp:Button ID="cmdChangePassword" Runat="server" text="Change"></asp:Button>
			&nbsp;
			<asp:Button ID="cmdReset" Runat="server" text="Reset"></asp:Button>
		</td>
	</tr>
	
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
	</tr>
</table>
