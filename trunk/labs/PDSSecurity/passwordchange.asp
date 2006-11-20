<HTML>
<HEAD>

<TITLE> Change Password</TITLE>

<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

UserName = Request.QueryString("UserName")
Current	= Request.Form("Current")
NewPass	= Request.Form("New1")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='UsernameCaseSensative';"
set rst 	= dbobj.Execute(strSQL)
UsernameCase	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='MinPasswordLength';"
set rst 	= dbobj.Execute(strSQL)
MinLength	= rst("ParamValue")

strSQL  = "SELECT UserName, Password FROM SecUser"
set rst = dbobj.Execute(strSQL)

do until rst.eof
  if UsernameCase = 1 then
    if UserName = rst("UserName") then
      Password = rst("Password")
      UserMatch = 1
    end if
  else
    if LCase(UserName) = LCase(rst("UserName")) then
       Password = rst("Password")
       UserMatch = 1
    end if
  end if
  rst.movenext()
loop

if Current <> "" then
  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='ReusePassword';"
  set rst 	= dbobj.Execute(strSQL)
  Reuse		= rst("ParamValue")

  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='EasyPassword';"
  set rst 	= dbobj.Execute(strSQL)
  Easy		= rst("ParamValue")

  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='DefaultPasswordExpiry';"
  set rst 	= dbobj.Execute(strSQL)
  ExpiryLength	= rst("ParamValue")

  strSQL	= "SELECT Password FROM SecUser WHERE UserName='" & UserName & "';"
  set rst	= dbobj.Execute(strSQL)
  if LCase(Current) <> LCase(rst("Password")) then
    BadPassword = 1
  elseif LCase(Current) = LCase(NewPass) and Reuse = 0 then
    BadReuse = 1
  elseif LCase(NewPass) = LCase(UserName) and Easy = 0 then
    BadEasy = 1
  else
    Cday = GetDay(Date())
    Cmonth = GetMonth(Date())
    Cyear = GetYear(Date())

    Cday = Cday + ExpiryLength

    while Cday > GetDaysInMonth(Cmonth,Cyear)
      Cday = Cday - GetDaysInMonth(Cmonth, Cyear)
      Cmonth = Cmonth + 1
      if Cmonth > 12 then
        Cyear = Cyear + 1
        Cmonth = 1
      end if
    wend

    Expiry = CStr(Cmonth) & "/" & CStr(Cday) & "/" & CStr(Cyear)

    strSQL	= "UPDATE SecUser SET Password='" & NewPass & "', PasswordExpiry='" & Expiry & "' WHERE UserName='" & UserName & "';"
    set rst	= dbobj.Execute(strSQL)
    Changed = 1
  end if
end if  

set rst=nothing
dbobj.Close 
set dbobj=nothing


function GetMonth(date)
  begin = 1
  finish = 1

  do until dummy = "/" or finish > len(date)
    finish = finish + 1
    dummy = Mid(date, finish, 1)
  loop

  GetMonth = CInt(Mid(Date, begin, finish - begin))
end function

function GetDay(date)
  begin = 1
  finish = 1

  do until mid(date, begin, 1) = "/" or begin > len(date)
    begin = begin + 1
  loop
  begin = begin + 1
  finish = begin
  do until mid(date, finish, 1) = "/" or finish > len(date)
    finish = finish + 1
  loop

  GetDay = CInt(mid(date, begin, finish - begin))
end function

function GetYear(date)
  begin = 1

  do until mid(date, begin, 1) = "/" or begin > len(date)
    begin = begin + 1
  loop
  begin = begin + 1
  do until mid(date, begin, 1) = "/" or begin > len(date)
    begin = begin + 1
  loop
  begin = begin + 1

  if CInt(mid(date, begin)) < 100 then
    GetYear = CInt(mid(date, begin)) + 2000
  else
    GetYear = CInt(mid(date, begin))
  end if
end function

function GetDaysInMonth(month, year)
  if month = 1 or month = 3 or month = 5 or month = 7 or month = 8 or month = 10 or month = 12 then
    days = 31
  elseif month = 4 or month = 6 or month = 9 or month = 11 then
    days = 30
  elseif month = 2 then
    if IsLeapYear(year) = true then
      days = 29
    else
      days = 28
    end if
  end if
  GetDaysInMonth = days
end function

function IsLeapYear (Year)
  if Year Mod 4 = 0 and (Year Mod 100 <> 0 or Year Mod 400 = 0) then
    IsLeapYear = true
  else
    IsLeapYear = false
  end if
end function
%>

<script language="JavaScript">

  function SubmitForm() {
    if (document.forms.Changer.Current.value == "" || document.forms.Changer.New1.value == "" || document.forms.Changer.New2.value == "")
      window.alert("You must fill in all the fields.");
    if (document.forms.Changer.New1.value != document.forms.Changer.New2.value)
      window.alert("You mistyped your new password in one of the fields.  Make sure that both fields are the same.");
    if (document.forms.Changer.New1.value.length < <%=MinLength%>)
      window.alert("Your new password must be at least <%=MinLength%> characters long.");
    else
      document.forms.Changer.submit();
  }

</script>

</HEAD

<BODY>

<table align=center valign=center height=100% width=100%><tr><td align=center>
  <table>
    <%if UserMatch <> 1 then%>
      <tr><td align=center>
        The user "<%=UserName%>" does not exist.<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%elseif BadPassword = 1 then%>
      <tr><td align=center>
        You have supplied an incorrect current password.<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%elseif Changed = 1 then%>
      <tr><td align=center>
        Your password has been updated.  Your password expiry date is now <%=Expiry%>.<br><br>
        <input class="SelectButton" type="button" onclick="window.close()" value="Close">
      </tr></td>
    <%else%>
      <FORM name="Changer" METHOD="post" action='passwordchange.asp?UserName=<%=UserName%>'>
        <tr valign=top><td width=50% align=right>
          <b>Current Password:</b>
          <img src="./images/white.gif" width=6 height=1>
        </td><td>
          <input type="password" name="Current" value="">          
        </td></tr><tr><td align=right>
          <b>New Password:</b>
          <img src="./images/white.gif" width=6 height=1>
        </td><td>
          <input type="password" name="New1" value="">          
        </td></tr><tr><td align=right>
          <b>Confirm:</b>
          <img src="./images/white.gif" width=6 height=1>
        </td><td>
          <input type="password" name="New2" value="">          
        </td></tr><tr><td colspan=2 valign=middle align=center height=40>
          <input class="SelectButton" type="button" onclick="SubmitForm()" value="Change">
        </tr></td>
      </FORM>
      <%if BadReuse = 1 then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B>You cannot recycle your old password.</td></tr>
      <%elseif BadEasy = 1 then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B>You cannot use your username as password.</td></tr>
      <%end if%>
    <%end if%>
  </table>
  </form>
</td></tr></table>

</BODY>

</HTML>