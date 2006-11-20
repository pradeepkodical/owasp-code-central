<HTML>

<%Privilege = "100002.102"%>
<!--#include file ="checkprivilege.asp"-->

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")
%>

<link rel='stylesheet' type='text/css' href="./css/list.css">

<script language="JavaScript">

function SubmitForm() {
  var UsedIDs = new Array();
  var Used = 0;
  
  txt = document.forms.GroupAdd.UsedIDs.value;
  start = 1;
  finish = 1;
  index = 0;
  while (start <= txt.length) {
    while (txt.substring(finish, finish + 1) != "," && finish <= txt.length)
      finish++;
    UsedIDs[index] = txt.substring(start, finish);
    index++;
    finish++;
    start = finish;
  }

  for (i = 0; i < UsedIDs.length; i++) {
    if (document.forms.GroupAdd.GroupName.value.toLowerCase() == UsedIDs[i].toLowerCase())
      Used = 1;
  }

  if (Used)
    window.alert("This group name has already been used.  Please type in a unique name.");
  else if (document.forms.GroupAdd.GroupName.value == "")
    window.alert("Enter a name first.");
  else {
    if (window.confirm('You are about to add the group "' + document.forms.GroupAdd.GroupName.value + '". Groups cannot be deleted. Are you sure you want to proceed?')) {
      document.forms.GroupAdd.submit();
      window.alert("Group added.");
      document.location.href = "selectgroup.asp";
    }
  }
}

</script>

<BODY>

<FORM name="GroupAdd" METHOD="post" target="tabhidden" action="addgroup.asp">

<TABLE border=0 width=80% height=100% align=center valign=center>
  <tr><td height=30%>
  </tr></td><tr><td>
    <img src="./images/white.gif" width=1 height=10>
  </tr></td><tr><td>
    <b>Group Name:</b>
  </td><td>
    <INPUT type=text size=25 name="GroupName" value="">
  </tr></td><tr><td></td><td align=left>
    <%
    strSQL	= "SELECT GroupName FROM SecGroup"
    set rst = dbobj.Execute(strSQL)
    %>
    <INPUT type="hidden" name="UsedIDs" value="<%do until rst.eof%>,<%=rst("GroupName")%><%rst.movenext()%><%loop%>">
    <%rst.close%>
    <INPUT onclick="SubmitForm();" class="SelectButton" name="Submit" type="Button" value="Add This Group">
  </td></tr>
  <tr><td height=30%></tr><td>
</table>

</BODY>

<%
set rst=nothing
dbobj.Close 
set dbobj=nothing
%>

</HTML>