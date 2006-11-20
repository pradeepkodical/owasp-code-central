<HTML>

<%Privilege = "100002.10"%>
<!--#include file ="checkprivilege.asp"-->

<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
UserID = Request.QueryString("Key")

Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "SELECT UserName, email, Password, PasswordExpiry, " _
		& "DeactivateOnExpiry, Active, PasswordHint, HintResponse FROM SecUser WHERE " + UserID
set rst = dbobj.Execute(strSQL)

UserName	= rst("UserName")
Email		= rst("email")
Password	= rst("Password")
PasswordExp	= rst("PasswordExpiry")
Deactivate	= rst("DeactivateOnExpiry")
Active		= rst("Active")
Hint		= rst("PasswordHint")
HintAnswer	= rst("HintResponse")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='AllowPasswordHint';"
set rst = dbobj.Execute(strSQL)
HintSetting	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='EasyPassword';"
set rst = dbobj.Execute(strSQL)
EasyPassword	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='MinPasswordLength';"
set rst = dbobj.Execute(strSQL)
MinPassword	= rst("ParamValue")

rst.close
%>

<script language="JavaScript">

function SubmitForm() {
  var UsedIDs = new Array();
  var Used = 0;
  
  txt = document.forms.UserInfo.UsedIDs.value;
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
    if (document.forms.UserInfo.UserName.value.toLowerCase() == UsedIDs[i].toLowerCase())
      Used = 1;
  }
  if (Used && document.forms.UserInfo.UserName.value.toLowerCase() != "<%=UserName%>".toLowerCase())
    window.alert("This user name has already been used.  Please type in a unique name.");
  else if (document.forms.UserInfo.Password.value != document.forms.UserInfo.Password2.value)
    window.alert("You must type the same password into the 'Confirm Password' field.");
  else if (document.forms.UserInfo.Password.value == "")
    window.alert("You must enter a password.");
  <%if EasyPassword=0 then%>
    else if (document.forms.UserInfo.Password.value.toLowerCase() == document.forms.UserInfo.UserName.value.toLowerCase())
      window.alert("You cannot use your user name as your password.");
  <%end if%>
  else if (document.forms.UserInfo.Password.value.length < <%=MinPassword%>)
    window.alert("Your password must contain at least <%=MinPassword%> characters.");
  else if (document.forms.UserInfo.PasswordExp.value == "")
    window.alert("You must enter a valid expiry date.");
  else if (document.forms.UserInfo.UserName.value == "")
    window.alert("You must enter a user name.");
  <%if HintSetting=1 or HintSetting=2 then%> 
    else if (document.forms.UserInfo.Hint.value == "" || document.forms.UserInfo.Hint.value == "-none-")
      window.alert("You must enter a password hint.");
  <%end if%>
  <%if HintSetting=2 then%>
    else if (document.forms.UserInfo.HintAnswer.value == "" || document.forms.UserInfo.HintAnswer.value == "-none-")
      window.alert("You must enter a response to the password hint.");
  <%end if%>
  else {
    document.forms.UserInfo.submit();
    window.alert("User information updated.");
    document.location.href = "selectuser.asp";
  }
}

</script>

<BODY>

<FORM name="UserInfo" METHOD="post" target="tabhidden" action="updateuser.asp">

<TABLE align=center border=0 width=90%>
  <tr><td>
    <img src="./images/white.gif" width=1 height=10>
  </tr></td><tr><td>
    <b>User Name:</b>
  </td><td>
    <INPUT type=text size=25 name="UserName" value="<%=UserName%>">
  </td></tr><tr><td>
    <img src="./images/white.gif" width=1 height=10>
  </tr></td><tr><td>
    E-Mail:
  </td><td>
    <INPUT type=text size=25 name="Email" value="<%=Email%>">
  </tr></td><tr><td>
    Password:
  </td><td>
    <INPUT type=password size=25 name="Password" value="<%=Password%>">
  </tr></td><tr><td>
    Confirm Password:
  </td><td>
    <INPUT type=password size=25 name="Password2" value="<%=Password%>">
  </tr></td><tr><td>
    Password Expiry:
  </td><td>
    <INPUT type=text size=25 name="PasswordExp" value="<%=PasswordExp%>">
  </tr></td><tr><td>
    Password Hint:
  </td><td>
    <INPUT type=text size=25 name="Hint" value="<%=Hint%>">
  </tr></td><tr><td>
    <%if HintSetting <> 1 then%>Password Response:<%end if%>
  </td><td>
    <INPUT 
      <%if HintSetting = 1 then%>
        type="hidden"
      <%else%>
        type="text"
      <%end if%> size=25 name="HintAnswer" value="<%=HintAnswer%>">
  </tr></td><tr><td height=8>
  </tr></td><tr><td colspan=2 align=left width=100%>
    <INPUT class="Checkbox" name="Deactivate" type="checkbox"
      <%if Deactivate="True" then%>
        CHECKED
      <%end if%>
      >
    Deactivate on Expiry
    <img src="./images/white.gif" width=40 height=1>
    <INPUT class="CheckBox" name="Active" type="checkbox"
      <%if Active="True" then%>
        CHECKED
      <%end if%>
      >
    Active
  </tr></td><tr><td height=10>
  </tr></td><tr><td colspan=2 align=center>
    <INPUT type="hidden" name="ID" value="<%=UserID%>">
    <%
    strSQL	= "SELECT UserName FROM SecUser"
    set rst = dbobj.Execute(strSQL)
    %>
    <INPUT type="hidden" name="UsedIDs" value="<%do until rst.eof%>,<%=rst("UserName")%><%rst.movenext()%><%loop%>">
    <%rst.close%>
    <INPUT onclick="SubmitForm();" class="SelectButton" name="Submit" type="Button" value="Update User Settings">
  </td></tr>
</table>

<div style='left: 400; top: 166; position: absolute; visibility: visible;'>
    <A class="Button" HREF="#" onClick="window.dateField = document.UserInfo.PasswordExp;calendar = window.open('./PDSCal/pdscal.htm','cal','WIDTH=200,HEIGHT=230')"><IMG SRC="./PDSCal/cal1.gif" BORDER=0 height=26 width=28 alt="(mm/dd/yyyy) Click for popup calendar."></A>
</div>
</BODY>

<%
set rst=nothing
dbobj.Close 
set dbobj=nothing
%>


</HTML>