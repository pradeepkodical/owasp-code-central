<HTML>

<%
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("Hint") & "' WHERE ParamName='AllowPasswordHint'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("Expiry") & "' WHERE ParamName='DefaultPasswordExpiry'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("Easy") & "' WHERE ParamName='EasyPassword'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("PLength") & "' WHERE ParamName='MinPasswordLength'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("PassCase") & "' WHERE ParamName='PasswordCaseSensative'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("Pending") & "' WHERE ParamName='PendingPasswordChange'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("Reuse") & "' WHERE ParamName='ReusePassword'"
set rst = dbobj.Execute(strSQL)

strSQL	= "UPDATE SysSecurityParameters SET Paramvalue='" & Request.Form("UserCase") & "' WHERE ParamName='UsernameCaseSensative'"
set rst = dbobj.Execute(strSQL)

set rst=nothing
dbobj.Close 
set dbobj=nothing
%>

<script>

document.parent.tabmain.location.href="./editsettings.asp";

</HTML>