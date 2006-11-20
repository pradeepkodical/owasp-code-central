<%@ Control Language="c#" AutoEventWireup="false" Codebehind="layout.ascx.cs" Inherits="sourceControl.layouts.defaultLayout.layoutSB" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<HEAD>
	<title>My Projects</title>
	<link rel="stylesheet" type="text/css"  href='<%=  siteRoot + "layouts/beretta/beretta.css" %>' title="default" >
</HEAD>
<body>
	<table width="100%" cellpadding="0" cellspacing="0" border="0">
		<tr bgcolor="#E5E5E5" cellpadding="0" cellspacing="0" valign=top>
			
		
			
			<td valign=top width=350>
			
						<img src="./common/images/image.gif">
						&nbsp; &nbsp;
						
						
			</td>
			
			<td align=left valign=middle>
				<img src="./common/images/title.gif">
			</td>
		</tr>
	</table>
	
	

	<table cellspacing="0" cellpadding="0" height="97%">
		<tr>
		
			<td width=191 valign=top>  
				<table cellpadding=0 cellspacing=0 width=100%>
					<tr>
						<td bgcolor=#FFFF00 height=30> 
							&nbsp;
						</td>
					</tr>
					
					<tr>
						<td height=700 bgcolor=#AEAEAE valign=top> 
							
							<br>
							
							<img src="./common/images/arrow.gif" border=0> &nbsp; <asp:hyperlink text="Home" Font-Name=arial Font-Size=10 ForeColor=#ffffff Runat=server></asp:hyperlink>
							<hr>
							
								<img src="./common/images/arrow.gif" border=0> &nbsp; <asp:hyperlink text="News" Font-Name=arial Font-Size=10 ForeColor=#ffffff Runat=server ID="Hyperlink1" NAME="Hyperlink1"></asp:hyperlink>
							<hr>
							
							
								<img src="./common/images/arrow.gif" border=0> &nbsp; <asp:hyperlink text="Updates" Font-Name=arial Font-Size=10 ForeColor=#ffffff Runat=server ID="Hyperlink2" NAME="Hyperlink2"></asp:hyperlink>
							<hr>
							
							
								<img src="./common/images/arrow.gif" border=0> &nbsp; <asp:hyperlink text="Downloads" Font-Name=arial Font-Size=10 ForeColor=#ffffff Runat=server ID="Hyperlink3" NAME="Hyperlink2"></asp:hyperlink>
							<hr>
							
							
								<img src="./common/images/arrow.gif" border=0> &nbsp; <asp:hyperlink text="Support" Font-Name=arial Font-Size=10 ForeColor=#ffffff Runat=server ID="Hyperlink4" NAME="Hyperlink2"></asp:hyperlink>
							<hr>
							
							
								<img src="./common/images/arrow.gif" border=0> &nbsp; <asp:hyperlink text="Contact" Font-Name=arial Font-Size=10 ForeColor=#ffffff Runat=server ID="Hyperlink5" NAME="Hyperlink2"></asp:hyperlink>
							<hr>
						</td>
					</tr>
				</table>
			</td>
		
					
			
		
			<td valign="top" width=90% bgcolor="#ffffff">
				<table width=100% cellpadding=0 cellspacing=0>
					<tr width=100%>
						<td bgcolor=#BBD7FF height=30 width=100%>
						&nbsp; &nbsp; 
						<asp:Label Runat=server Font-Name=arial Font-Bold=True ForeColor=#ffffff>Home</asp:Label>
						&nbsp;
						</td>
					</tr>
					
					<tr width=100%>
						<td valign=top>
							<asp:Panel ID="panelPlaceHolder" Runat="server"></asp:Panel>
						</td>
					</tr>
				
				</table>	
				
			</td>
		</tr>
	</table>

	
	
	<asp:Panel Runat=server Visible=False>
	Beretta Welcome:
				<asp:Label ID="lblUser" Runat="server"></asp:Label>
				<!-- Main Menu -->
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=25">Change Password</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=26">My Details</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=27">Manage Users</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=28">Manage Roles</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=29">Manage Config</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=30">Manage Hosts Allow</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=31">Manage Modules</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=32">Manage List Groups</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=34">Manage Tabs</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=35">System Events</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=37">Display Form Submission</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=38">Encoding</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=39">Manage Password Attack Config</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=40">Manage Passwords</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=41">Manage Payloads</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=42">Manage Sessions</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=43">Manage Signatures</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=44">Manage Usernames</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=45">Password Attack Control</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=46">Record Session</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=47">Select Page</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?pageId=48">Test Payload</a></li>
				</ul>
				<ul id="nav-menu">
					<li>
						<a href="./default.aspx?action=logoff">Logoff</a></li>
				</ul>
				
					<asp:image id="imgLoginOff" runat="server" />
							<asp:HyperLink ID="lnkLoginOff" Font-Bold="True" CssClass="normal" ForeColor="#ffffff" Font-Underline="True"
								text="Login" NavigateUrl="~/default.aspx?action=login" Runat="server" />
	</asp:Panel>
