<HTML>

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

if Request.Form("Active") = "on" then
  Active = "True"
else
  Active = "False"
end if

strSQL	= "UPDATE SecGroup SET GroupName='" & Request.Form("GroupName") & "', Active=" & Active & " WHERE " & Request.Form("ID") & ";"
set rst = dbobj.Execute(strSQL)

set rst=nothing

dbobj.Close 
set dbobj=nothing
%>

</HTML>