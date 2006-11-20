<HTML>
<TITLE> Select a Module </TITLE>

<STYLE>

BODY {
  font-family : arial, sans-serif;
  background-color: #CECECE;
  font-size: 10pt;
}

A.module {
  text-decoration: none;
  color : #000000;
}

A.module:link {
  text-decoration: none;
}

A.module:hover {
  text-decoration: none;
  color: #83ADCE;
}


TD {
  BORDER: 0px none;
  padding: 2px;
  spacing: 5px;
}

</STYLE>  

<%Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Application("SecurityConnStr")

dim ModuleName()
dim ModuleID()
dim ModuleActive()
dim ModuleParent()

strSQL	= "SELECT ID, ParentID, ModuleName, Active FROM SysModule"
set rst = dbobj.Execute(strSQL)

i = 0
do until rst.eof
  redim preserve ModuleName(i)
  redim preserve ModuleID(i)
  redim preserve ModuleActive(i)
  redim preserve ModuleParent(i)
  ModuleName(i) = rst("ModuleName")
  ModuleID(i) = rst("ID")
  ModuleActive(i) = rst("Active")
  ModuleParent(i) = rst("ParentID")
  i = i + 1
  rst.movenext()
loop

function List(index, indent, active)
  dim counter

  %>
    <tr><td>
      <img src="./images/white.gif" width=<%=indent%> height=1 border=0>
      <%if active=1 then%>
        <img src="./images/module.gif" border=1 align=top alt="Currently active">
      <%else%>
        <img src="./images/dmodule.gif" border=1 align=top alt="Currently not active">
      <%end if%>
      <a class="module" href='javascript: opener.location.href="./mapALprivileges.asp?Group=<%=Request.QueryString("Group")%>&Arrange=<%=Request.QueryString("Arrange")%>&Module=<%=ModuleID(index)%>"; this.close();'><%=ModuleName(index)%></a>
    </td></tr>
  <%
  for counter = 0 to ubound(ModuleID)
    if ModuleParent(counter) = ModuleID(index) then
      if ModuleActive(counter) = "True" and active <> 0 then
        List counter, indent + 20, 1
      else
        List counter, indent + 20, 0
      end if
    end if
  next
end function
%>

<script>

function ReturnModule(ModID) {
  window.alert(opener.location.href)
}

</script>

<BODY>

<TABLE height=100% width=100% valign=middle border=0>
  <tr><td align=center>
  <img src="./images/white.gif" height=20 width=1 border=0 align=top><b>Select a Module<b><br>
  <TABLE border=1 bgcolor=dfdfdf bordercolor=000000 border=0>

  <%
  for i=0 to ubound(ModuleID)
    if ModuleParent(i) = 0 then
      if ModuleActive(i) = "True" then
        List i, 0, 1
      else
        List i, 0, 0
      end if
    end if
  next
  %>

  </TABLE>
  </tr></td>
</TABLE>

</BODY>

<%
rst.close
set rst=nothing
dbobj.close
set dbobj=nothing
%>

</HTML>