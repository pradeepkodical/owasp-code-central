<HTML>

<%Privilege = "100002.204"%>
<!--#include file ="checkprivilege.asp"-->

<!--

This page is a bit more complex because the privileges are all members of modules.
Thus, the dragger.asp file had to be somewhat customised, and for this page we use
mod_dragger.asp.  In mod_dragger.asp the tables that contain the information on the
modules are accessed directly and cannot be controlled from this file.

-->

<BODY bgcolor="CECECE">

<table align=center valign=center width=100% height=100%>
  <tr><td>
    <font face="arial" size=-1 color="000033"><center><i>Loading . . . </i><center></font>
  </tr></td>
</table>

<form name="Dragger" method="Post" action="mod_dragger.asp">

  <script language="JavaScript">

  // Colours and Positioning

  writer	= 'BackColour		= "#C3C9CE";'
		+ 'ShadeColour		= "#a3a9aE";'
		+ 'LightColour		= "#E0E5E9";'
		+ 'SelectColour		= "#739DbE";'
		+ 'OverColour		= "#83ADCE";'
		+ 'TextColour		= "#000000";'
		+ 'TextOverColour	= "#ffffff";'
		+ ''
		+ 'SourceTop		= 65;'
		+ 'SourceLeft		= 35;'
		+ 'DestTop		= 65;'
		+ 'DestLeft		= 280;'
		+ 'ListHeight		= 190;'
		+ 'ListWidth		= 180;'
		+ 'ButtonTop		= 130;'
		+ 'ButtonLeft		= 232;'
		+ 'SubmitLeft		= 216;'
		+ 'SubmitTop		= 300;';

  document.writeln('<INPUT type="hidden" name="Tests" value=\'' + writer + '\'>');

  </script> 

  <INPUT type="hidden" name="ThisUrl"			value="mapALprivileges.asp">
  <INPUT type="hidden" name="ConnStr"			value="<%=Application("SecurityConnStr")%>">
  <INPUT type="hidden" name="Group"			value="<%=Request.QueryString("Group")%>">
  <INPUT type="hidden" name="Module"			value="<%=Request.QueryString("Module")%>">
  <INPUT type="hidden" name="SubmitUrl"			value="mapper.asp">
  <INPUT type="hidden" name="SubmitCaption"		value="Update">
  <INPUT type="hidden" name="Arrange1"			value="Access Level">
  <INPUT type="hidden" name="Arrange2"			value="Privilege">
  <INPUT type="hidden" name="Arrange1icon"		value="./images/accesslevel.gif">
  <INPUT type="hidden" name="Arrange2icon"		value="./images/privileges.gif">
  <INPUT type="hidden" name="Arrange1icondeactive"	value="./images/daccesslevel.gif">
  <INPUT type="hidden" name="Arrange2icondeactive"	value="./images/dprivileges.gif">
  <%if Request.QueryString("Arrange") = 1 or Request.QueryString("Arrange") = "" then%>
    <INPUT type="hidden" name="ItemTable"		value="SecPrivilege">
    <INPUT type="hidden" name="GroupTable"		value="SecAccessLevel">
    <INPUT type="hidden" name="JoinerTable"		value="SecJoinPrivAL">
    <INPUT type="hidden" name="ItemIDField"		value="PKID">
    <INPUT type="hidden" name="ItemNameField"		value="Privilege">
    <INPUT type="hidden" name="ItemActiveField"		value="">
    <INPUT type="hidden" name="GroupIDField"		value="ID">
    <INPUT type="hidden" name="GroupNameField"		value="AccessLevelName">
    <INPUT type="hidden" name="GroupActiveField"	value="Active">
    <INPUT type="hidden" name="JoinerIDField"		value="ID">
    <INPUT type="hidden" name="JoinerItemField"		value="PrivilegeID">
    <INPUT type="hidden" name="JoinerGroupField"	value="ALID">
    <INPUT type="hidden" name="OutListCaption"		value="Doesn't Belong">
    <INPUT type="hidden" name="InListCaption"		value="Belongs">
    <INPUT type="hidden" name="Arrange"			value="1">
    <INPUT type="hidden" name="SubmitMessage"		value="This access level has now been updated.">
  <%else%>
    <INPUT type="hidden" name="ItemTable"		value="SecAccessLevel">
    <INPUT type="hidden" name="GroupTable"		value="SecPrivilege">
    <INPUT type="hidden" name="JoinerTable"		value="SecJoinPrivAL">
    <INPUT type="hidden" name="ItemIDField"		value="ID">
    <INPUT type="hidden" name="ItemNameField"		value="AccessLevelName">
    <INPUT type="hidden" name="ItemActiveField"		value="Active">
    <INPUT type="hidden" name="GroupIDField"		value="PKID">
    <INPUT type="hidden" name="GroupNameField"		value="Privilege">
    <INPUT type="hidden" name="GroupActiveField"	value="">
    <INPUT type="hidden" name="JoinerIDField"		value="ID">
    <INPUT type="hidden" name="JoinerItemField"		value="ALID">
    <INPUT type="hidden" name="JoinerGroupField"	value="PrivilegeID">
    <INPUT type="hidden" name="OutListCaption"		value="Doesn't Have Privilege">
    <INPUT type="hidden" name="InListCaption"		value="Has Privilege">
    <INPUT type="hidden" name="Arrange"			value="2">
    <INPUT type="hidden" name="SubmitMessage"		value="These access levels have now been updated.">
  <%end if%>
</form>

<script language="JavaScript">
  document.forms.Dragger.submit();
</script>

</BODY>

</HTML>