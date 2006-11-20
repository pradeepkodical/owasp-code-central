<HTML>

<%Privilege = "100002.203"%>
<!--#include file ="checkprivilege.asp"-->

<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
ALID = Request.QueryString("Key")

Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "SELECT AccessLevelName, Active FROM SecAccessLevel WHERE " + ALID
set rst = dbobj.Execute(strSQL)

ALName		= rst("AccessLevelName")
Active		= rst("Active")

rst.close
%>

<script language="JavaScript">

function SubmitForm() {
  var UsedIDs = new Array();
  var Used = 0;
  
  txt = document.forms.ALInfo.UsedIDs.value;
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
    if (document.forms.ALInfo.ALName.value.toLowerCase() == UsedIDs[i].toLowerCase())
      Used = 1;
  }
  if (Used && document.forms.ALInfo.ALName.value.toLowerCase() != "<%=ALName%>".toLowerCase())
    window.alert("This access level name has already been used.  Please type in a unique name.");
  else if (document.forms.ALInfo.ALName.value.length == 0)
    window.alert("You must enter an access level name.");
  else {
    document.forms.ALInfo.submit();
    window.alert("Access level information updated.");
    document.location.href = "selectAL.asp";
  }
}

</script>

<BODY>

<FORM name="ALInfo" METHOD="post" target="tabhidden" action="updateAL.asp">

<TABLE valign=middle height=100% align=center><tr><td>
  <TABLE border=0 align=center valign=middle>
    <tr><td>
      <b>Access Level Name:</b>
      <img src="./images/white.gif" width=20 height=1>
    </td><td>
      <INPUT type=text size=25 name="ALName" value="<%=ALName%>">
    </td></tr><tr><td colspan=2 align=center height=30>
      <INPUT class="CheckBox" name="Active" type="checkbox"
        <%if Active="True" then%>
          CHECKED
        <%end if%>
        >
      Active
    </tr></td><tr><td colspan=2 align=center height=50 valign=bottom>
      <INPUT type="hidden" name="ID" value="<%=ALID%>">
      <%
      strSQL	= "SELECT AccessLevelName FROM SecAccessLevel"
      set rst = dbobj.Execute(strSQL)
      %>
      <INPUT type="hidden" name="UsedIDs" value="<%do until rst.eof%>,<%=rst("AccessLevelName")%><%rst.movenext()%><%loop%>">
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