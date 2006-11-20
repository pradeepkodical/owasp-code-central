<HTML>

<%Privilege = "100002.104"%>
<!--#include file ="checkprivilege.asp"-->

<BODY bgcolor="CECECE">

<table align=center valign=center width=100% height=100%>
  <tr><td>
    <font face="arial" size=-1 color="000033"><center><i>Loading . . . </i><center></font>
  </tr></td>
</table>

<form name="Dragger" method="Post" action="dragger.asp">

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
		+ 'SourceLeft		= 60;'
		+ 'DestTop		= 65;'
		+ 'DestLeft		= 290;'
		+ 'ListHeight		= 190;'
		+ 'ListWidth		= 150;'
		+ 'ButtonTop		= 130;'
		+ 'ButtonLeft		= 232;'
		+ 'SubmitLeft		= 218;'
		+ 'SubmitTop		= 300;';

  document.writeln('<INPUT type="hidden" name="Tests" value=\'' + writer + '\'>');

  </script> 

  <INPUT type="hidden" name="ThisUrl"			value="mapGroupAL.asp">
  <INPUT type="hidden" name="ConnStr"			value="<%=Application("SecurityConnStr")%>">
  <INPUT type="hidden" name="Group"			value="<%=Request.QueryString("Group")%>">
  <INPUT type="hidden" name="SubmitUrl"			value="mapper.asp">
  <INPUT type="hidden" name="SubmitCaption"		value="Update">
  <INPUT type="hidden" name="Arrange1"			value="Access Level">
  <INPUT type="hidden" name="Arrange2"			value="Group">
  <INPUT type="hidden" name="Arrange1icon"		value="./images/accesslevel.gif">
  <INPUT type="hidden" name="Arrange2icon"		value="./images/group.gif">
  <INPUT type="hidden" name="Arrange1icondeactive"	value="./images/daccesslevel.gif">
  <INPUT type="hidden" name="Arrange2icondeactive"	value="./images/dgroup.gif">
  <%if Request.QueryString("Arrange") = 1 or Request.QueryString("Arrange") = "" then%>
    <INPUT type="hidden" name="ItemTable"		value="SecGroup">
    <INPUT type="hidden" name="GroupTable"		value="SecAccessLevel">
    <INPUT type="hidden" name="JoinerTable"		value="SecJoinGroupAL">
    <INPUT type="hidden" name="ItemIDField"		value="ID">
    <INPUT type="hidden" name="ItemNameField"		value="GroupName">
    <INPUT type="hidden" name="ItemActiveField"		value="Active">
    <INPUT type="hidden" name="GroupIDField"		value="ID">
    <INPUT type="hidden" name="GroupNameField"		value="AccessLevelName">
    <INPUT type="hidden" name="GroupActiveField"	value="Active">
    <INPUT type="hidden" name="JoinerIDField"		value="ID">
    <INPUT type="hidden" name="JoinerItemField"		value="GroupID">
    <INPUT type="hidden" name="JoinerGroupField"	value="ALID">
    <INPUT type="hidden" name="OutListCaption"		value="No Access">
    <INPUT type="hidden" name="InListCaption"		value="Has Access">
    <INPUT type="hidden" name="Arrange"			value="1">
    <INPUT type="hidden" name="SubmitMessage"		value="This access level has now been updated.">
  <%else%>
    <INPUT type="hidden" name="ItemTable"		value="SecAccessLevel">
    <INPUT type="hidden" name="GroupTable"		value="SecGroup">
    <INPUT type="hidden" name="JoinerTable"		value="SecJoinGroupAL">
    <INPUT type="hidden" name="ItemIDField"		value="ID">
    <INPUT type="hidden" name="ItemNameField"		value="AccessLevelName">
    <INPUT type="hidden" name="ItemActiveField"		value="Active">
    <INPUT type="hidden" name="GroupIDField"		value="ID">
    <INPUT type="hidden" name="GroupNameField"		value="GroupName">
    <INPUT type="hidden" name="GroupActiveField"		value="Active">
    <INPUT type="hidden" name="JoinerIDField"		value="ID">
    <INPUT type="hidden" name="JoinerItemField"		value="ALID">
    <INPUT type="hidden" name="JoinerGroupField"	value="GroupID">
    <INPUT type="hidden" name="OutListCaption"		value="Not in Group">
    <INPUT type="hidden" name="InListCaption"		value="In Group">
    <INPUT type="hidden" name="Arrange"			value="2">
    <INPUT type="hidden" name="SubmitMessage"		value="This group has now been updated.">
  <%end if%>
</form>

<script language="JavaScript">
  document.forms.Dragger.submit();
</script>

</BODY>

</HTML>