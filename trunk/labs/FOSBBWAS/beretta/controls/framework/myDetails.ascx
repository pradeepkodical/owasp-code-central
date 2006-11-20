<%@ Control Language="c#" AutoEventWireup="false" Codebehind="myDetails.ascx.cs" Inherits="sourceControl.controls.myDetails" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<h1>My Details
</h1>
<asp:ValidationSummary CssClass="error" Runat="server" DisplayMode="BulletList" HeaderText="The following errors occurred:"
	ID="Validationsummary1"></asp:ValidationSummary>
<asp:Panel ID="panelError" Runat="server">
	<asp:Label id="lblError" Runat="server" CssClass="error"></asp:Label>
</asp:Panel>
<table width="600">
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
		<td>
			&nbsp;</td>
		<td>
			&nbsp;
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			<span class="normal">Firstname: </span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtFirstname" Runat="server" Width="300"></asp:TextBox></td>
		<td>
			&nbsp;
			<asp:RequiredFieldValidator ControlToValidate="txtFirstName" CssClass="error" ErrorMessage="First name is blank"
				text="<" Runat="server" id="RequiredFieldValidator1"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			<span class="normal">Lastname: </span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtLastname" Runat="server" Width="300"></asp:TextBox></td>
		<td>
			&nbsp;
			<asp:RequiredFieldValidator ControlToValidate="txtLastname" CssClass="error" ErrorMessage="Last Name is blank"
				text="<" Runat="server" ID="Requiredfieldvalidator2"></asp:RequiredFieldValidator>
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			<span class="normal">Email: </span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtEmail" Runat="server" Width="300"></asp:TextBox></td>
		<td>
			&nbsp;
			<asp:RequiredFieldValidator ControlToValidate="txtEmail" CssClass="error" ErrorMessage="Email is blank" text="<"
				Runat="server" ID="Requiredfieldvalidator3"></asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator ID="valEmail" CssClass="error" ControlToValidate="txtEmail" ValidationExpression="^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"
				text="<" ErrorMessage="Invalid Email" Runat="server" />
		</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			<span class="normal">Organisation: </span>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:TextBox ID="txtOrganisation" Runat="server" Width="300"></asp:TextBox></td>
		<td>
			&nbsp;
			<asp:RequiredFieldValidator ControlToValidate="txtOrganisation" CssClass="error" ErrorMessage="Organisation is blank"
				text="<" Runat="server" ID="Requiredfieldvalidator4"></asp:RequiredFieldValidator>
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
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			<asp:Button ID="cmdAdd" Runat="server" Text="Add"></asp:Button>
			&nbsp;
			<asp:Button ID="cmdCancel" CausesValidation="False" Runat="server" Text="Cancel"></asp:Button>
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;</td>
	</tr>
	<tr>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;
		</td>
		<td>
			&nbsp;</td>
		<td>
			&nbsp;
		</td>
	</tr>
</table>
