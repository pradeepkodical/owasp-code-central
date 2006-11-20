<HTML>

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

if Request.Form("Deactivate") = "on" then
  Deactivate = "True"
else
  Deactivate = "False"
end if

if Request.Form("Active") = "on" then
  Active = "True"
else
  Active = "False"
end if

Hint = Apostrophe(Request.Form("Hint"))
if Hint = "" then Hint = "-none-"
HintAnswer = Apostrophe(Request.Form("HintAnswer"))
if HintAnswer = "" then HintAnswer = "-none-"
Email = Apostrophe(Request.Form("Email"))
if Email = "" then Email = "-none-"

strSQL	= "UPDATE SecUser SET " _
		& "UserName = '" & Apostrophe(Request.Form("UserName")) & "', " _
		& "email = '" & Email & "', " _
		& "Password = '" & Apostrophe(Request.Form("Password")) & "', " _
		& "PasswordExpiry = '" & Request.Form("PasswordExp") & "', " _
		& "Active = " & Active & ", " _
		& "DeactivateOnExpiry = " & Deactivate & ", " _
		& "PasswordHint = '" & Hint & "', " _
		& "HintResponse = '" & HintAnswer & "' " _
		& "WHERE " & Request.Form("ID") & ";"

set rst = dbobj.Execute(strSQL)

set rst=nothing

dbobj.Close 
set dbobj=nothing

function Apostrophe(line)
  i = 1

  while i <= len(line)
    if mid(line, i, 1) = "'" then
      line = mid(line, 1, i-1) + "' + chr(39) + '" + mid(line, i + 1)
      i = i + 15
    else
      i = i + 1
    end if
  wend

  Apostrophe = line
end function
%>

</HTML>