<HTML>

<link rel='stylesheet' type='text/css' href="./css/list.css">

<BODY>

<table align=center valign=center height=100%><tr><td>
  <table align=center>
    <%if Session("UserName") <> "" then%>
      <tr><td align=center colspan=2 height=50>
        <b>Current User:&nbsp&nbsp"<%=Session("UserName")%>"</b>
      </td></tr><tr><td>
        <img src="./images/noaccess.gif" align=middle>
        <img src="./images/white.gif" width=7 height=1>
      </td><td>
        You do not have the authority to access this page.
      </td></tr>
    <%else%>
      <tr><td>
        <img src="./images/noaccess.gif" align=middle>
        <img src="./images/white.gif" width=7 height=1>
      </td><td>
        You have not logged on, or your session has terminated.
      </td></tr>
    <%end if%>
  </table>
</table>

</BODY>

</HTML>