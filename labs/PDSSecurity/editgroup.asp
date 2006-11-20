<HTML>

<%Privilege = "100002.103"%>
<!--#include file ="checkprivilege.asp"-->


<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
GroupID = Request.QueryString("Key")

Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "SELECT GroupName, Active FROM SecGroup WHERE " + GroupID
set rst = dbobj.Execute(strSQL)

GroupName	= rst("GroupName")
Active		= rst("Active")

rst.close
%>

<script language="JavaScript">

function SubmitForm() {
  var UsedIDs = new Array();
  var Used = 0;
  
  txt = document.forms.GroupInfo.UsedIDs.value;
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
    if (document.forms.GroupInfo.GroupName.value.toLowerCase() == UsedIDs[i].toLowerCase())
      Used = 1;
  }
  if (Used && document.forms.GroupInfo.GroupName.value.toLowerCase() != "<%=GroupName%>".toLowerCase())
    window.alert("This group name has already been used.  Please type in a unique name.");
  else if (document.forms.GroupInfo.GroupName.value.length == 0)
    window.alert("You must enter a group name.");
  else {
    document.forms.GroupInfo.submit();
    window.alert("Group information updated.");
    document.location.href = "selectgroup.asp";
  }
}

</script>

<BODY>

<FORM name="GroupInfo" METHOD="post" target="tabhidden" action="updategroup.asp">

<TABLE valign=middle height=100% align=center><tr><td>
  <TABLE border=0 align=center valign=middle>
    <tr><td>
      <b>Group Name:</b>
      <img src="./images/white.gif" width=20 height=1>
    </td><td>
      <INPUT type=text size=25 name="GroupName" value="<%=GroupName%>">
    </td></tr><tr><td colspan=2 align=center height=30>
      <INPUT class="CheckBox" name="Active" type="checkbox"
        <%if Active="True" then%>
          CHECKED
        <%end if%>
        >
      Active
    </tr></td><tr><td colspan=2 align=center height=50 valign=bottom>
      <INPUT type="hidden" name="ID" value="<%=GroupID%>">
      <%
      strSQL	= "SELECT GroupName FROM SecGroup"
      set rst = dbobj.Execute(strSQL)
      %>
      <INPUT type="hidden" name="UsedIDs" value="<%do until rst.eof%>,<%=rst("GroupName")%><%rst.movenext()%><%loop%>">
      <%rst.close%>
      <INPUT onclick="SubmitForm();" class="SelectButton" name="Submit" type="Button" value="Update User Settings">
    </td></tr>
  </TABLE>
</td></tr></TABLE>

 </BODY>

<%
set rst=nothing
dbobj.Close 
set dbobj=nothing
%>


</HTML>