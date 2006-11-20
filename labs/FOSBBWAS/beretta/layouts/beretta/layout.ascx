<%@ Control Language="c#" AutoEventWireup="false" Codebehind="layout.ascx.cs" Inherits="sourceControl.layouts.defaultLayout.layoutSB" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

	<link rel="stylesheet" type="text/css"  href='<%=  siteRoot + "layouts/beretta/beretta.css" %>' title="default" >




<body>

<div id="container">
<div id="hdr">
<img src='<%=  siteRoot + "layouts/beretta/images/hdr.jpg" %>' />
</div>

<div id="bar">Logged in as: 
	<asp:Label CssClass=bar id="lblUser" 
					Runat="server"></asp:Label>
</div>

<table>
	<tr>
		<td height=480>
		
	

<div id="left">
<ul id="nav">
<li><a href="./default.aspx?pageId=42">Manage Sessions</a></li>
</ul>
<ul id="nav">
<li><a href="./default.aspx?pageId=48">Test Payload</a></li>
</ul>
<ul id="nav">
<li><a href="./default.aspx?pageId=47">View form submission</a></li>
</ul>
<ul id="nav">
<li><a href="./default.aspx?pageId=50">Analyze Form</a></li>
</ul>

<br />
<ul id="nav">
<li><a href="./default.aspx?pageId=41">Manage Payloads</a></li>
</ul>
<ul id="nav">
<li><a href="./default.aspx?pageId=43">Manage Signatures</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=44">Manage Usernames</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=40">Manage Passwords</a></li>
</ul>



<ul id="nav">
<li><a href="./default.aspx?pageId=38">Encoding</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=49">Ip Encoding</a></li>
</ul>

<br />


<ul id="nav">
<li><a href="./default.aspx?pageId=25">Change Password</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=26">My Details</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=27">Manage Users</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=28">Manage Roles</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=29">Manage Config</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=30">Manage Hosts Allow</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=31">Manage Modules</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=32">Manage List Groups</a></li>
</ul>

<ul id="nav">
<li><a href="./default.aspx?pageId=35">System Events</a></li>
</ul>
<br/>

<ul id="nav">
<li><a href="./default.aspx?pageId=51">About</a></li>
</ul>



<ul id="nav">
<li><a target=_blank href="http://www.owasp.org">OWASP</a></li>
</ul>

<br/>

<ul id="nav">
<li><a href="./default.aspx?action=logoff">Log out</a></li>
</ul>
</div>


	</td>
	
		<td valign=top>
		
		

<div id="content">

	
			
				<asp:Panel ID="panelPlaceHolder" Runat="server">
	</asp:Panel>

		
	
	</div>
	
	</td>
		
		<td>
		
		</td>
	</tr>
</table>

	<br><br>
</body>			
				
					
