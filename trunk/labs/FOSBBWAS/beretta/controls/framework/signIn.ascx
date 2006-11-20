<%@ Control Language="c#" AutoEventWireup="false" Codebehind="signIn.ascx.cs" Inherits="sourceControl.controls.signIn" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>



<div id="welcome"></div>
<div id="horiz">
<div id="loginbox">
<br><br>
<div id="leftbox">

<p class="logintext">

Please enter your username and password to login:<br><br></p>
</div>

<asp:Panel ID=panelMessage Runat=server Visible=False>
<br><br>
<asp:Label ID=lblMessage Runat=server Font-Name=verdana ForeColor=#ff0000 Font-Size=10></asp:Label>
<br>
</asp:Panel>

<div id="rightbox">

  
<table class="longin">
<tr>
<td>
	<h3>Username:</h3>
</td>
<td>
		<asp:TextBox ID="txtUsername" Runat="server" MaxLength=30 CssClass=inputBox Width="300"></asp:TextBox>
</td>
</tr>
<tr>
<td>	
	<h3>Password:</h3>
</td>
<td>
	<asp:TextBox ID="txtPassword" TextMode="Password" MaxLength=30 CssClass=inputBox Runat="server" Width="300"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2">
  <br />

      <asp:Button ID="cmdLogin" CssClass=button Runat="server" Text="Login"></asp:Button>
		  	<asp:Button ID="cmdReset"  CssClass=button  Runat="server" Text="Reset"></asp:Button>	
		
</td>
</tr>
</table>
</div>
</div>
</div>

</body>
</html>
















