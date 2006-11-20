<HTML>
<HEAD>

<TITLE> Password Hint</TITLE>

<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

UserName = Request.QueryString("UserName")
Answer   = Request.Form("answer")

if Answer = "" then
  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='PasswordCaseSensative';"
  set rst 	= dbobj.Execute(strSQL)
  PasswordCase	= rst("ParamValue")
  
  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='UsernameCaseSensative';"
  set rst 	= dbobj.Execute(strSQL)
  UsernameCase	= rst("ParamValue")

  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='AllowPasswordHint';"
  set rst 	= dbobj.Execute(strSQL)
  HintSetting	= rst("ParamValue")

  strSQL  = "SELECT UserName, PasswordHint FROM SecUser"
  set rst = dbobj.Execute(strSQL)

  do until rst.eof
    if UsernameCase = 1 then
      if UserName = rst("UserName") then
        PasswordHint = rst("PasswordHint")
        UserMatch = 1
      end if
    else
      if LCase(UserName) = LCase(rst("UserName")) then
        PasswordHint = rst("PasswordHint")
        UserMatch = 1
      end if
    end if
    rst.movenext()
  loop
else
  Password = "."
  strSQL  = "SELECT Password, HintResponse FROM SecUser WHERE UserName='" & UserName & "';"
  set rst = dbobj.Execute(strSQL)

  if LCase(Answer) = LCase(rst("HintResponse")) then
    Password = rst("Password")
  end if
end if

set rst=nothing
dbobj.Close 
set dbobj=nothing
%>

<script language="JavaScript">

  function SubmitForm() {
    if (document.forms.Checker.answer.value == "")
      window.alert("You must enter an answer.");
    else
      document.forms.Checker.submit();
  }

</script>

</HEAD

<BODY>

<table align=center valign=center height=100% width=100%><tr><td align=center>
  <table width=250>
    <%if Password = "." then%>
      <tr><td align=center>
        That answer is incorrect.<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%elseif Password <> "" then%>
      <tr><td align=center>
        Your password is "<%=Password%>".<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%elseif HintSetting=0 then%>
      <tr><td align=center>
        The password hint system has been disabled.  Contact the system administrator for help on retrieving your password.<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%elseif UserMatch <> 1 then%>
      <tr><td align=center>
        The user "<%=UserName%>" does not exist.<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%elseif HintSetting=1 then%>
      <tr><td align=center>
        Your hint is:  "<%=PasswordHint%>"<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%else%>
      <FORM name="Checker" METHOD="post" action="passwordhint.asp?UserName=<%=UserName%>">
        <tr valign=top><td>
          <b>Question:</b>
        </td><td>
          "<%=PasswordHint%>"
        </td></tr><tr><td>
          <b>Answer:</b>
        </td><td>
          <input class="text" name="answer" value="">
        </td></tr><tr><td colspan=2 align=middle>
          <br><input class="SelectButton" type="button" onclick="SubmitForm()" value="Submit">
        </tr></td>
      </FORM>
    <%end if%>
  </table>
  </form>
</td></tr></table>

</BODY>

</HTML>