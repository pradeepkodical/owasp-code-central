<html>

<title> PDS Security Manager </title>

<%
Application("SecurityConnStr") = "DSN=PDSSecurity; Database=Security"
%>

<frameset COLS="*,520,*" frameborder="no" border="0" framespacing="0">
  <frame MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="auto" NORESIZE frameborder=no>
  <frameset ROWS="*,24,400,3,*" frameborder="no" border="0" framespacing="0">
    <frame MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="auto" NORESIZE frameborder=no>
    <frame NAME="tabbar" SRC="PDSWebTab.htm?LabelCSV=Users,Groups,Groups-AL,Access Level,Settings,Exit&MainDoc=main.asp&defaultTab=1&CSSFile=./CSS/secstyle.css" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no" NORESIZE frameborder="no">
    <frameset COLS="3,8,*,8,3" frameborder="no" border="0" framespacing="0">
      <frame src="leftmargin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
      <frame src="margin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
      <frameset ROWS="8,*,42,0,8" frameborder="no" border="0" framespacing="0" scrolling="yes">
        <frame src="margin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
        <frame NAME="tabmain" SRC="main.asp" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="auto"  NORESIZE frameborder=no>
        <frame NAME="tabbottom" SRC="margin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
        <frame NAME="tabhidden" SRC="margin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
        <frame src="margin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
      </frameset>
      <frame src="margin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
      <frame src="rightmargin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
    </frameset>
    <frame src="bottommargin.htm" MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no"  NORESIZE frameborder=no>
    <frame MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="auto" NORESIZE frameborder=no>
  </frameset>
  <frame MARGINHEIGHT="0" MARGINWIDTH="0" SCROLLING="no" NORESIZE frameborder=no>
</frameset>
	
</html>

