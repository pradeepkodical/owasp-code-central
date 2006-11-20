<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ipEncoding.ascx.cs" Inherits="beretta.Web.ipEncoding" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<h1>IP Encoding
</h1>
<span class="ipAddress">Address</span><br>
<asp:TextBox ID="txtIp1" Width="50" MaxLength="3" Runat="server"></asp:TextBox>
.
<asp:TextBox ID="txtIp2" Width="50" MaxLength="3" Runat="server"></asp:TextBox>
.
<asp:TextBox ID="txtIp3" Width="50" MaxLength="3" Runat="server"></asp:TextBox>
.
<asp:TextBox ID="txtIp4" Width="50" MaxLength="3" Runat="server"></asp:TextBox>
<br><br>
<span class="ipAddress">Encoding</span><br>
<asp:DropDownList ID="dropDownEncoding" Width="250" Runat="server">
	<asp:ListItem Value="0">Octet</asp:ListItem>
	<asp:ListItem Value="1">Hex</asp:ListItem>
	<asp:ListItem Value="2">DWORD</asp:ListItem>
</asp:DropDownList>
<asp:button ID="cmdConvert" Runat="server" Text="Convert"></asp:button>
<br>
<br>
<asp:TextBox ID="txtResult" Runat="server" Width="320"></asp:TextBox>
