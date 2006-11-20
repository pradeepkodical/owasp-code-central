<HTML>

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "INSERT INTO SecAccessLevel (AccessLevelName) VALUES (" _
		& "'" & Request.Form("ALName") & "');"

set rst = dbobj.Execute(strSQL)

set rst=nothing

dbobj.Close 
set dbobj=nothing

%>

</HTML>