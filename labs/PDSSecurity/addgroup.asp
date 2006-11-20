<HTML>

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "INSERT INTO SecGroup (GroupName) VALUES (" _
		& "'" & Request.Form("GroupName") & "');"

set rst = dbobj.Execute(strSQL)

set rst=nothing

dbobj.Close 
set dbobj=nothing

%>

</HTML>