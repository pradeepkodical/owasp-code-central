<HTML>
<HEAD>

<%@ LANGUAGE="VBScript" %>

<TITLE> PDS Login </TITLE>

<STYLE>

BODY {
  font-family: arial, sans-serif;
  font-size: 10pt;
}

A {
  text-decoration: none;
  color: #000077;
}

A:visited {
  text-decoration: none;
  color: #000077;
}

A:hover {
  text-decoration: none;
  color: #1111bb;
}

</STYLE>

<%
Application("SecurityConnStr") = "DSN=PDSSecurity; Database=Security"
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='PasswordCaseSensative';"
set rst = dbobj.Execute(strSQL)
PasswordCase	= rst("ParamValue")

strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='UsernameCaseSensative';"
set rst = dbobj.Execute(strSQL)
UsernameCase	= rst("ParamValue")

UserName = Request.Form("UserName")
Password = Request.Form("Password")

if UserName <> "" then
  BadUserName = 1
  BadPassword = 1
  strSQL  = "SELECT ID, UserName, Active, PasswordExpiry, DeactivateOnExpiry, Password FROM SecUser"
  set rst = dbobj.Execute(strSQL)

  do until rst.eof
    if UsernameCase = 1 then
      if UserName = rst("UserName") then
        BadUserName = 0
        if rst("Active") = false then
          UserInActive = 1
        else
          if PasswordCase = 1 then
            if Password = rst("Password") then 
              BadPassword = 0
              Expiry = rst("PasswordExpiry")
              Deactivate = rst("DeactivateOnExpiry")
              UserID = rst("ID")
            end if
          else
            if LCase(Password) = LCase(rst("Password")) then
              BadPassword = 0
              Expiry = rst("PasswordExpiry")
              Deactivate = rst("DeactivateOnExpiry")
              UserID = rst("ID")
            end if
          end if
        end if
      end if
    else
      if LCase(UserName) = LCase(rst("UserName")) then
        BadUserName = 0
        if rst("Active") = false then
          UserInActive = 1
        else
          if PasswordCase = 1 then
            if Password = rst("Password") then 
              BadPassword = 0
              Expiry = rst("PasswordExpiry")
              Deactivate = rst("DeactivateOnExpiry")
              UserID = rst("ID")
            end if
          else
            if LCase(Password) = LCase(rst("Password")) then
              BadPassword = 0
              Expiry = rst("PasswordExpiry")
              Deactivate = rst("DeactivateOnExpiry")
              UserID = rst("ID")
            end if
          end if
        end if
      end if
    end if
    rst.movenext()
  loop
end if

if BadPassword = 0 and UserName <> "" then
  dim Groups()
  dim AL()
  UserPrivs = ""

  strSQL	= "SELECT ParamValue FROM SysSecurityParameters WHERE ParamName='PendingPasswordChange';"
  set rst = dbobj.Execute(strSQL)
  Pending	= rst("ParamValue")


  if GetYear(Date()) > GetYear(Expiry) then
    PasswordExpired = 1
  elseif GetYear(Date()) = GetYear(Expiry) then
    if GetMonth(Date())> GetMonth(Expiry) then
      PasswordExpired = 1
    elseif GetMonth(Date()) = GetMonth(Expiry) then
      if GetDay(Date()) >= GetDay(Expiry) then
        PasswordExpired = 1
      end if
    end if
  end if

  if PasswordExpired <> 1 then
    PDay = GetDay(Date())
    PMonth = GetMonth(Date())
    PYear = GetYear(Date())
  
    PDay = PDay + Pending
    while (PDay > GetDaysInMonth(PMonth, PYear))
      PDay = PDay - GetDaysInMonth(PMonth, PYear)
      PMonth = PMonth + 1
      if PMonth > 12 then
        PYear = PYear + 1
        PMonth = 1
      end if
    wend

    if PYear > GetYear(Expiry) then
      RenewPassword = 1
    elseif PYear = GetYear(Expiry) then
      if PMonth > GetMonth(Expiry) then
        RenewPassword = 1
      elseif PMonth = GetMonth(Expiry) then
        if PDay >= GetDay(Expiry) then
          RenewPassword = 1
        end if
      end if
    end if
  end if

  strSQL	= "SELECT GroupID FROM SecJoinUserGroup WHERE UserID=" & UserID & ";"
  set rst	= dbobj.Execute(strSQL)

  i = 0
  do until rst.eof
    redim preserve Groups(i)
    Groups(i) = rst("GroupID")
    rst.movenext()
    i = i + 1
  loop

  if i > 0 then
    i = 0
    for j = 0 to ubound(Groups)
      strSQL	= "SELECT Active FROM SecGroup WHERE ID=" & Groups(j) & ";"
      set rst	= dbobj.Execute(strSQL)
      if rst("Active") = true then
        strSQL	= "SELECT ALID FROM SecJoinGroupAL WHERE GroupID=" & Groups(j) & ";"
        set rst	= dbobj.Execute(strSQL)
        do until rst.eof
          redim preserve AL(i)
          AL(i) = rst("ALID")
          rst.movenext()
          i = i + 1
        loop
      end if
    next
  end if

  if i > 0 then
    i = 0
    for j = 0 to ubound(AL)
      strSQL	= "SELECT Active FROM SecAccessLevel WHERE ID=" & AL(j) & ";"
      set rst	= dbobj.Execute(strSQL)
      if rst("Active") = true then
        strSQL	= "SELECT PrivilegeID FROM SecJoinPrivAL WHERE ALID=" & AL(j) & ";"
        set rst	= dbobj.Execute(strSQL)
        do until rst.eof
          UserPrivs = UserPrivs + "," + rst("PrivilegeID")
          rst.movenext()
        loop
      end if
    next
    UserPrivs = UserPrivs + ","
  end if     
      
  
  if PasswordExpired = 1 then
    if Deactivate = true then
      strSQL	= "UPDATE SecUser SET Active=False WHERE ID=" & UserID & ";"
      set rst	= dbobj.Execute(strSQL)
    end if
  else
    Session("UserPrivs") = UserPrivs
    Session("UserName") = UserName
    Session.Timeout = 5
    if RenewPassword <> 1 then
      %><script> document.location.href="./security.asp" </script><%
    end if
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

  function GetHint() {
    if (document.forms.Login.UserName.value == "")
      window.alert("Enter a user name first.");
    else
      window.open("./passwordhint.asp?UserName=" + document.forms.Login.UserName.value,null,"height=150,width=300,status=no,toolbar=no,menubar=no,location=no,titlebar=no");
  }

  function ChangePass() {
    if (document.forms.Login.UserName.value == "")
      window.alert("Enter a user name first.");
    else
      window.open("./passwordchange.asp?UserName=" + document.forms.Login.UserName.value,null,"height=180,width=330,status=no,toolbar=no,menubar=no,location=no,titlebar=no");
  }

  function ChangePass2() {
    window.open('./passwordchange.asp?UserName=<%=UserName%>',null,"height=180,width=330,status=no,toolbar=no,menubar=no,location=no,titlebar=no");
    document.location.href="./security.asp";
  }


  function SubmitForm() {
    if (document.forms.Login.UserName.value == "" || document.forms.Login.Password.value == "")
      window.alert("You must enter a user name and a password.");
    else
      document.forms.Login.submit();
  }

</script>

</HEAD

<BODY bgcolor=ffffff>

<table align=center valign=center height=100%><tr><td>
  <table bgcolor=CECECE width=250 style="border-top: 2px solid #DDDDDD; border-left: 2px solid #DDDDDD; border-bottom: 2px solid #aaaaaa; border-right: 2px solid #aaaaaa;">
    <tr><td align=center width=* height=30 style="border: 1px solid #999999;" valign=middle colspan=2>
      <table width=100%>
        <tr><td width=30>
          <img src="./images/login.gif">
        </td><td width=* align=center>
          <b>Login</b>    
        </td><td width=30>
        </td></tr>
      </table>
    </td></tr>
    <%if RenewPassword = 1 then%>
      <tr><td align=left valign=middle>
        <%if Deactivate = true then%>
          <br>Your password will soon be expiring (<%=Expiry%>), at which time your account will become inactive.
          Changing your password will extend the expiry date.  Would you like to do so now?<br>
        <%else%>
          <br>Your password will soon be expiring (<%=Expiry%>), at which time you will have
          to change it.  Would you like to do so now?<br>
        <%end if%>
        <img src="./images/white.gif" width=1 height=1>
      </td></tr><tr><td height=30 align=center valign=middle>
        <input type="button" onclick='ChangePass2()' value="Yes" style="width: 50px;">
        <img src="./images/white.gif" width=10 height=1>
        <input type="button" onclick='document.location.href="./security.asp"' value="No" style="width: 50px;">
    <%else%>
      <FORM name="Login" METHOD="post" action="login.asp">
      <tr><td height=30>
        <img src="./images/white.gif" width=10 height=0>
        User Name:
      </td><td>
        <INPUT type="text" name="UserName" value="<%=UserName%>" style="width: 120px;">
      </td></tr><tr><td height=30>
        <img src="./images/white.gif" width=10 height=0>
        Password:
      </td><td>
        <INPUT type="password" name="Password" value="" style="width: 120px;">
      </td></tr><tr><td height=40 align=center colspan=2 valign=middle>
        <INPUT type="button" name="Submitter" onclick="SubmitForm()" value="Login" style="width: 100px;">
      </td></tr><tr><td height=40 valign=middle colspan=2 align=center>
        <hr style="height: 1px" color=000000 width=90%>
        <a href="javascript: GetHint()">Password Hint</a>
        <img src="./images/white.gif" width=7 height=1>|<img src="./images/white.gif" width=7 height=1>
        <a href="javascript: ChangePass()">Change Password</a>
      </td></tr>
      <%if BadUserName = 1 then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B> User name does not exist.</td></tr>
      <%elseif BadPassword = 1 and UserInactive <> 1 then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B> Incorrect password.</td></tr>
      <%elseif BadPassword = 1 and UserInactive = 1 then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B> This account has been deactivated. </td></tr>
      <%elseif PasswordExpired = 1 and Deactivate = false then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B> Your password has expired.  You must change it now.</td></tr>
      <%elseif PasswordExpired = 1 and Deactivate = true then%>
        <tr><td colspan=2 align=center style="border: 1px solid #000000;" bgcolor=88889B> Your password has expired, and your account has now been deactivated.  Contact the system administrator to reactivate it.</td></tr>
      <%end if%>
      </FORM>
    <%end if%>
  </table>
</td></tr></table>

</BODY>

</HTML>