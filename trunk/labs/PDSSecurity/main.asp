<%response.buffer=true%>
<HTML>

<BODY bgcolor=CECECE>

<%select case Request.QueryString("tab")
  case 1%>
    <script> 
      window.parent.tabbottom.location.href = "./useroptions.htm"; 
      document.location.href = "selectuser.asp";
    </script>
  <%case 2%>
    <script> 
      window.parent.tabbottom.location.href = "./groupoptions.htm"; 
      document.location.href = "./mapUserGroups.asp";
    </script>
  <%case 3%>
    <script> 
      window.parent.tabbottom.location.href = "./margin.htm"; 
      document.location.href = "./mapGroupAL.asp";
    </script>
  <%case 4%>
    <script> 
      window.parent.tabbottom.location.href = "./ALoptions.htm"; 
      document.location.href = "./mapALPrivileges.asp";
    </script>
  <%case 5%>
    <script> 
      window.parent.tabbottom.location.href = "./margin.htm"; 
      document.location.href = "./editsettings.asp";
    </script>
  <%case 6
    Session.Abandon%>
    <script>
      window.parent.location.href = "./login.asp"
    </script>
  <%case else%>
    <script> 
      window.parent.tabbottom.location.href = "./useroptions.htm"; 
      document.location.href = "selectuser.asp";
    </script>
<%end select%>

</BODY>

</HTML>