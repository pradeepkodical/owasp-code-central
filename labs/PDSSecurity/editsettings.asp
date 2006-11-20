<HTML>

<%Privilege = "100001.10"%>
<!--#include file ="checkprivilege.asp"-->

<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
UserID = Request.QueryString("Key")

Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='AllowPasswordHint'"
set rst = dbobj.Execute(strSQL)
Hint	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='DefaultPasswordExpiry'"
set rst = dbobj.Execute(strSQL)
Expiry	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='EasyPassword'"
set rst = dbobj.Execute(strSQL)
Easy	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='MinPasswordLength'"
set rst = dbobj.Execute(strSQL)
Length	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='PasswordCaseSensative'"
set rst = dbobj.Execute(strSQL)
PassCase= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='PendingPasswordChange'"
set rst = dbobj.Execute(strSQL)
Pending	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='ReusePassword'"
set rst = dbobj.Execute(strSQL)
Reuse	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='UsernameCaseSensative'"
set rst = dbobj.Execute(strSQL)
UserCase= rst("ParamValue")



rst.close
%>

<script language="JavaScript">

  function SubmitForm() 
  {
    if (!parseInt(document.forms.Settings.Expiry.value))
      window.alert('You must enter an integer into the "Password Expiry" field.');
    else if (parseInt(document.forms.Settings.Expiry.value) > 500)
      window.alert('Enter a number less than 500 into the "Password Expiry" field.');
    else if (!parseInt(document.forms.Settings.PLength.value))
      window.alert('You must enter an integer into the "Password Length" field.');
    else if (parseInt(document.forms.Settings.PLength.value) > 13)
      window.alert('Enter a number 12 or less into the "Password Length" field.');
    else if (!parseInt(document.forms.Settings.Pending.value))
      window.alert('You must enter an integer into the "Number of days before . . ." field.');
    else if (parseInt(document.forms.Settings.Pending.value) >= document.forms.Settings.Expiry.value)
      window.alert('The value of "Number of days before . . . " cannot (logically!) be greater than that of the "Password Expiry".');
    else {
      document.forms.Settings.Hint.value = getChecked(document.forms.Settings.aHint);
      document.forms.Settings.Easy.value = getChecked(document.forms.Settings.aEasy);
      document.forms.Settings.Reuse.value = getChecked(document.forms.Settings.aReuse);
      document.forms.Settings.PassCase.value = getChecked(document.forms.Settings.aPassCase);
      document.forms.Settings.UserCase.value = getChecked(document.forms.Settings.aUserCase);
      document.forms.Settings.submit();
      window.alert("Global settings updated.");
    }
  }

  function getChecked(radio) {
    for (i = 0; i < radio.length; i++) {
      if (radio[i].checked == true)
        return i;
    }
  }

</script>

<BODY>

<FORM name="Settings" METHOD="post" target="tabhidden" action="updatesettings.asp">

<TABLE border=0 width=95% align=center cellpadding=0 cellspacing=0>
  <tr><td colspan=2>
    <img src="./images/white.gif" height=20 width=1>
  </td></tr><tr class="EvenRow"><td colspan=2>
    <b> Password Hint Method: </b><br>
    <INPUT class="EvenRow" type="radio" name="aHint" <%if Hint=0 then%>CHECKED<%end if%>> None
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="EvenRow" type="radio" name="aHint" <%if Hint=1 then%>CHECKED<%end if%>> Hint
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="EvenRow" type="radio" name="aHint" <%if Hint=2 then%>CHECKED<%end if%>> Question-Response
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="EvenRow" type="radio" name="aHint" <%if Hint=3 then%>CHECKED<%end if%>> Optional
  </td></tr><tr class="EvenRow"><td height=5 colspan=2>
  </td></tr><tr class="OddRow"><td colspan=2>
    <b> Default Password Expiry Time: </b>
    <img src="./images/white.gif" width=5 height=1>
    <INPUT type="Text" name="Expiry" size=3 value="<%=Expiry%>"> days
  </td></tr><tr class="OddRow"><td height=5 colspan=2>
  </td></tr><tr class="EvenRow"><td colspan=2>
    <b> Minimum Password Length: </b>
    <img src="./images/white.gif" width=5 height=1>
    <INPUT type="Text" name="PLength" size=2 value="<%=Length%>"> characters
  </td></tr><tr class="EvenRow"><td height=5 colspan=2>
  </td></tr><tr class="OddRow"><td width=70%>
    <b> Number of days before expiry that user is prompted to change password:</b>
  </td><td width=30%>
    <INPUT type="Text" name="Pending" size=2 value="<%=Pending%>"> days
  </td></tr><tr class="OddRow"><td height=5 colspan=2>
  </td></tr><tr class="EvenRow"><td colspan=2>
    <b> Can password be the same as user name? </b><br>
    <INPUT class="EvenRow" type="radio" name="aEasy" <%if Easy=0 then%>CHECKED<%end if%>> No
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="EvenRow" type="radio" name="aEasy" <%if Easy=1 then%>CHECKED<%end if%>> Yes
  </td></tr><tr class="EvenRow"><td height=5 colspan=2>
  </td></tr><tr class="OddRow"><td colspan=2>
    <b> Can a user recycle his most recent password? </b><br>
    <INPUT class="OddRow" type="radio" name="aReuse" <%if Reuse=0 then%>CHECKED<%end if%>> No
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="OddRow" type="radio" name="aReuse" <%if Reuse=1 then%>CHECKED<%end if%>> Yes
  </td></tr><tr class="OddRow"><td height=5 colspan=2>
  </td></tr><tr class="EvenRow"><td colspan=2>
    <b> Is the password case-sensitive? </b><br>
    <INPUT class="EvenRow" type="radio" name="aPassCase" <%if PassCase=0 then%>CHECKED<%end if%>> No
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="EvenRow" type="radio" name="aPassCase" <%if PassCase=1 then%>CHECKED<%end if%>> Yes
  </td></tr><tr class="EvenRow"><td height=5 colspan=2>
  </td></tr><tr class="OddRow"><td colspan=2>
    <b> Is the username case-sensitive? </b><br>
    <INPUT class="OddRow" type="radio" name="aUserCase" <%if UserCase=0 then%>CHECKED<%end if%>> No
    <img src="./images/white.gif" width=5 height=1>
    <INPUT class="OddRow" type="radio" name="aUserCase" <%if UserCase=1 then%>CHECKED<%end if%>> Yes
  </td></tr><tr><td height=10 colspan=2>
  </td></tr><tr><td colspan=2 align=center>
    <INPUT type="Hidden" name="Hint">
    <INPUT type="Hidden" name="Easy">
    <INPUT type="Hidden" name="Reuse">
    <INPUT type="Hidden" name="PassCase">
    <INPUT type="Hidden" name="UserCase">
    <INPUT class="SelectButton" type="Button" name="SubmitButton" onclick="SubmitForm()" value="Update System Settings">
  </td></tr>
</table>

</BODY>

<%
set rst=nothing
dbobj.Close 
set dbobj=nothing
%>


</HTML>