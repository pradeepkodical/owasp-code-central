<%
if InStr("," & Session("UserPrivs") & ",", Privilege) = 0 then
  %><script> document.location.href="noprivilege.asp" </script><%
end if
%>