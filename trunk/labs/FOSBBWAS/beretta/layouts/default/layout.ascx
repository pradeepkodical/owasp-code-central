<%@ Control Language="c#" AutoEventWireup="false" Codebehind="layout.ascx.cs" Inherits="sourceControl.layouts.defaultLayout.layout" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<head>
<title>My Projects</title>
<link rel="stylesheet" type="text/css"  href='<%=  siteRoot + "layouts/default/devcafe.css" %>' title="default" />
<link rel="alternate stylesheet" type="text/css"  href='<%=  siteRoot + "layouts/silverbear/devcafesilverbear.css" %>' title="silverbear" />
<script type="text/javascript" src="./common/js/styleswitcher.js"></script>
</head>

<body>

<div id="hdrbox">
<div id="hdr"></div>
</div>


<div id="smallcontainer">
<div id="themesbox">
<p class="small">Choose a theme:</p>
<a href="#" onclick="setActiveStyleSheet('default'); return false;" title="Default Theme"><img src="./common/images/defaulttheme.gif" class="themebtn" alt="Default Theme" /></a>
<a href="#" onclick="setActiveStyleSheet('silverbear'); return false;" title="Silverbear Theme"><img src="./common/images/silverbeartheme.gif" class="themebtn" alt="Silverbear Theme" /></a>
</div>

<div id="userdiv">
<p class="small">Welcome:</p>
<p class="user"><asp:Label ID=lblUser Runat=server></asp:Label></p>
<input type="reset" onclick="javascript:window.location='./default.aspx?action=logoff'" class="smallbtn" value="Logout" />

</div>

<div id="rightcol">
<!-- General Devcafe Links -->
<ul id="rightmenu">
<li><a href="">help</a></li>
<li><a href="">support</a></li>
<li><a href="">news</a></li>
<li><a href="">upgrade</a></li>
</ul>
</div>
</div>

<div id="leftcol">

<!-- Main Menu -->


<ul id="nav-menu">
<li><a href="./default.aspx?pageId=13">Change Password</a></li>
</ul>

<asp:Panel ID=panelAdmin Runat=server>
<ul id="nav-menu1">
<li><a href="./default.aspx?pageId=4">Manage Users</a></li>
</ul>

<ul id="nav-menu2">
<li><a href="./default.aspx?pageId=10">System Events</a></li>
</ul>

<ul id="nav-menu3">
<li><a href="./default.aspx?pageId=10">Manage Config</a></li>
</ul>

<ul id="nav-menu4">
<li><a href="./default.aspx?pageId=10">Manage Hosts</a></li>
</ul>

</asp:Panel>

<ul id="nav-menu">
<li><a href="./default.aspx?action=logoff">Logoff</a></li>
</ul>

<div id="versiondiv">
<p class="faint">version: 0.1</p>
</div>
</div>

<div id="content">
<asp:Panel ID=panelPlaceHolder Runat=server></asp:Panel>
</div>



<div id="copyrightbar">
<span class="faint"> 2005- Devcafe </span>
</div>

</body>
</html>









