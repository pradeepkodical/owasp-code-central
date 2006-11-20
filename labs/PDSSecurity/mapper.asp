<HTML>

<script language="JavaScript">
  window.parent.tabmain.location.href	= "<%=Request.Form("ParentUrl")%>?Group=<%=Request.Form("GroupID")%>&Arrange=<%=Request.Form("Arrange")%>&Module=<%=Request.Form("Module")%>";
</script>

<%
  InList			= Request.Form("InList")		'IDs of items now in group
  GroupID			= Request.Form("GroupID")		'ID of group
  OIn				= Request.Form("OriginalIn")	'IDs of items originally in group
  JID				= Request.Form("JoinerID")		'IDs of the original records in the table associating item with group
  JoinerTable		= Request.Form("JoinerTable")
  JoinerItemField	= Request.Form("JoinerItemField")
  JoinerGroupField	= Request.Form("JoinerGroupField")
  dim InGroup()
  dim OriginalIn()
  dim JoinerID()

  Set dbobj = Server.CreateObject("ADODB.Connection")
  dbobj.Open Request.Form("ConnStr")

  'Parse information from comma-lists into arrays

  start = 2
  finish = 2
  index = 0
  do while start <= len(InList)
    do while mid(InList, finish, 1) <> "," and finish <= len(InList)
      finish = finish + 1
    loop
    redim preserve InGroup(index)
    InGroup(index) = mid(InList, start, finish - start)
    index = index + 1
    finish = finish + 1
    start = finish
  loop
  
  if index = 0 then NoIn = 1
  
  start = 2
  finish = 2
  index = 0
  do while start <= len(OIn)
    do while mid(OIn, finish, 1) <> "," and finish <= len(OIn)
      finish = finish + 1
    loop
    redim preserve OriginalIn(index)
    OriginalIn(index) = mid(OIn, start, finish - start)
    index = index + 1
    finish = finish + 1
    start = finish
  loop

  if index = 0 then NoOIn = 1

  start = 2
  finish = 2
  index = 0
  do while start <= len(JID)
    do while mid(JID, finish, 1) <> "," and finish <= len(JID)
      finish = finish + 1
    loop
    redim preserve JoinerID(index)
    JoinerID(index) = mid(JID, start, finish - start)
    index = index + 1
    finish = finish + 1
    start = finish
  loop

  'Delete any items that have been removed from group in joining table

  if NoOIn <> 1 then
    for i = 0 to ubound(OriginalIn)
      deleted = 1
      if NoIn <> 1 then
        for j = 0 to ubound(InGroup)
          if InGroup(j) = OriginalIn(i) then
            deleted = 0
          end if
        next
      end if
      if deleted = 1 then
        strSQL = "DELETE * FROM " & JoinerTable & " WHERE ID=" & JoinerID(i)
%><%=strsql%><br><%
        set rst = dbobj.Execute(strSQL)
      end if
    next
  end if
  
  'Add any items that did not previously belong in group in joining table

  if NoIn <> 1 then
    for i = 0 to ubound(InGroup)
      added = 1
      if NoOIn <> 1 then
        for j = 0 to ubound(OriginalIn)
          if InGroup(i) = OriginalIn(j) then
            added = 0
          end if
        next
      end if
      if added = 1 then
        strSQL	= "INSERT INTO " & JoinerTable & " (" & JoinerItemField & ", " & JoinerGroupField _
				& ") VALUES ('" & InGroup(i) & "', '" & GroupID & "');"
%><%=strsql%><br><%
        set rst = dbobj.Execute(strSQL)
      end if
    next
  end if
  
  set rst=nothing
  dbobj.Close
  set dbobj = nothing
%>

</HTML>