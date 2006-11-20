<HTML>

<HEAD>

<link rel='stylesheet' type='text/css' href="./css/list.css">

<%
dim Group
dim Module
dim ThisModuleName
dim ThisModuleActive
dim ModuleName()
dim ModuleID()
dim ModuleActive()
dim ModuleParent()
dim ItemNames()
dim ItemActive()
dim ItemNamesIDs()
dim JoinerID()
dim InIDs()
dim InNames()
dim InActive()
dim OutNames()
dim OutIDs()
dim OutActive()
dim i, j, k, l
Set dbobj = Server.CreateObject("ADODB.Connection")
dbobj.Open Request.Form("ConnStr")

ItemTable		= Request.Form("ItemTable")
GroupTable		= Request.Form("GroupTable")
JoinerTable		= Request.Form("JoinerTable")
ItemIDField		= Request.Form("ItemIDField")
ItemNameField		= Request.Form("ItemNameField")
ItemActiveField		= Request.Form("ItemActiveField")
GroupIDField		= Request.Form("GroupIDField")
GroupNameField		= Request.Form("GroupNameField")
GroupActiveField	= Request.Form("GroupActiveField")
JoinerIDField		= Request.Form("JoinerIDField")
JoinerItemField		= Request.Form("JoinerItemField")
JoinerGroupField	= Request.Form("JoinerGroupField")

if Request.Form("Arrange") = 1 then
  ItemImage		= Request.Form("Arrange2icon")
  ItemDeactiveImage	= Request.Form("Arrange2icondeactive")
else
  ItemImage		= Request.Form("Arrange1icon")
  ItemDeactiveImage	= Request.Form("Arrange1icondeactive")
end if


'Get current module
if Request.Form("Module") = "" then
  strSQL = "SELECT ModuleID FROM SecPrivilege"
  set rst = dbobj.Execute(strSQL)
  Module = rst("ModuleID")
else
  Module = Request.Form("Module")
end if

'Get current group on drop-down menu
if Request.Form("Group") = "" then
  if Request.Form("Arrange") = 1 then
    Group = 1
  else
    strSQL = "SELECT ModuleID, PrivilegeID FROM SecPrivilege WHERE ModuleID=" & Module
    set rst = dbobj.Execute(strSQL)
    if rst.eof then
      Group = 0
      NoItems = 1
    else
      Group = CStr(rst("ModuleID")) + "." + CStr(rst("PrivilegeID"))
    end if
  end if
else
  Group = Request.Form("Group")
end if

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

ThisModuleName = GetName(CLng(Module))

if ItemActiveField <> "" then
  strSQL = "SELECT " & ItemActiveField & " FROM " & ItemTable & " ORDER BY " & ItemIDField & ";"
  set rst = dbobj.Execute(strSQL)
  i = 0
  do until rst.eof
    redim preserve ItemActive(i)
    if rst(ItemActiveField) = "True" then
      ItemActive(i) = 1
    else
      ItemActive(i) = 0
    end if
    rst.movenext()
    i = i + 1
  loop
end if

if GroupActiveField <> "" then
  strSQL = "SELECT " & GroupActiveField & " FROM " & GroupTable & " WHERE " & GroupIDField & "=" & Group & ";"
  set rst = dbobj.Execute(strSQL)
  if rst(GroupActiveField) = "True" then
    GroupActive = 1
    if Request.Form("Arrange") = 1 then
      GroupImage = Request.Form("Arrange1icon")
    else
      GroupImage = Request.Form("Arrange2icon")
    end if
  else
    if Request.Form("Arrange") = 1 then
      GroupImage = Request.Form("Arrange1icondeactive")
    else
      GroupImage = Request.Form("Arrange2icondeactive")
    end if
  end if
else
  GroupActive = 1
  if Request.Form("Arrange") = 1 then
    GroupImage = Request.Form("Arrange1icon")
  else
    GroupImage = Request.Form("Arrange2icon")
  end if
end if    

if Request.Form("Arrange") = 1 then
  strSQL = "SELECT ModuleID, PrivilegeID, " & ItemNameField & " FROM " & ItemTable & " WHERE ModuleID=" & Module & " ORDER BY " & ItemIDField & ";"
else
  strSQL = "SELECT " & ItemIDField & ", " & ItemNameField & " FROM " & ItemTable
end if
set rst = dbobj.Execute(strSQL)
i = 0
do until rst.eof
  redim preserve ItemNames(i)
  redim preserve ItemNamesIDs(i)
  ItemNames(i) = rst(ItemNameField)
  if Request.Form("Arrange") = 1 then
    ItemNamesIDs(i) = CStr(rst("ModuleID")) + "." + CStr(rst("PrivilegeID"))
  else
    ItemNamesIDs(i) = rst(ItemIDField)
  end if
  rst.movenext()
  i = i + 1
loop

if i = 0 then NoItems = 1

if Request.Form("Arrange") = 1 then
  strSQL	= "SELECT " & JoinerIDField & ", " & JoinerItemField & " FROM " & JoinerTable & " WHERE " & JoinerGroupField & "=" & Group
  set rst = dbobj.Execute(strSQL)
  i = 0
  do until rst.eof
    if CStr(GetModule(rst(JoinerItemField))) = CStr(Module) then
      redim preserve InIDs(i)
      redim preserve InNames(i)
      redim preserve JoinerID(i)
      redim preserve InActive(i)
      InIDs(i) = rst(JoinerItemField)
      JoinerID(i) = rst(JoinerIDField)
      InNames(i) = ItemNames(GetNameIndex(InIDs(i)))
      i = i + 1
    end if
    rst.movenext()
  loop
else
  strSQL	= "SELECT " & JoinerIDField & ", " & JoinerItemField & " FROM " & JoinerTable & " WHERE " & JoinerGroupField & "='" & Group & "';"
  set rst = dbobj.Execute(strSQL)
  i = 0
  do until rst.eof
    redim preserve InIDs(i)
    redim preserve InNames(i)
    redim preserve JoinerID(i)
    InIDs(i) = rst(JoinerItemField)
    if ItemActiveField <> "" then
      redim preserve InActive(i)
      InActive(i) = ItemActive(GetNameIndex(InIDs(i)))
    end if
    JoinerID(i) = rst(JoinerIDField)
    InNames(i) = ItemNames(GetNameIndex(InIDs(i)))
    i = i + 1
    rst.movenext()
  loop
end if

if i = 0 then NoIn = 1

i = 0
if NoItems <> 1 then
  for l = 0 to ubound(ItemNames)
    if NoIn <> 1 then
      for j = 0 to ubound(InIDs)
        if InIDs(j) = ItemNamesIDs(l) then
          k = 1
        end if
      next
    end if
    if k = 1 then
      k = 0
    else
      redim preserve OutIDs(i)
      redim preserve OutNames(i)
      if ItemActiveField <> "" then
        redim preserve OutActive(i)
        OutActive(i) = ItemActive(l)
      end if
      OutIDs(i) = ItemNamesIDs(l)
      OutNames(i) = ItemNames(l)
      i = i + 1
    end if
  next
end if

if i = 0 then NoOut = 1

function GetNameIndex(id)
  for j = 0 to ubound(ItemNamesIDs)
    if CStr(ItemNamesIDs(j)) = CStr(id) then
      GetNameIndex = j
    end if
  next
end function

function GetModule(ID)
  j = 1
  do until mid(ID, j, 1) = "." or j > len(ID)
    j = j + 1
  loop

  GetModule = mid(ID, 1, j - 1)
end function

function GetActive(ModID)
  parent = ModID
  active = true

  do until parent = 0
    if ModuleActive(GetIndex(parent)) = "False" then
      active = false
    end if
    parent = GetParent(parent)
  loop

  GetActive=active
end function 

function GetName(ModID)
  GetName = ModuleName(GetIndex(ModID))
end function

function GetIndex(ModID)
  for a = 0 to ubound(ModuleID)
    if CStr(ModuleID(a)) = CStr(ModID) then
      GetIndex = a
    end if
  next
end function

function GetParent(ModID)
  GetParent = ModuleParent(GetIndex(ModID))
end function
%>

<script language="JavaScript">

// ----- Dragger Settings -----

<%=Request.Form("Tests")%>
SubmitMessage		= "<%=Request.Form("SubmitMessage")%>";
ParentUrl		= "<%=Request.Form("ThisUrl")%>";
GroupID			= "<%=Group%>";
SubmitCaption		= "<%=Request.Form("SubmitCaption")%>";
OutCaption		= "<%=Request.Form("OutListCaption")%>";
InCaption		= "<%=Request.Form("InListCaption")%>";
Icon			= "<%=ItemImage%>";
DeactiveIcon		= "<%=ItemDeactiveImage%>";

// ----------------------------

function ChangeGroup(index) {
  document.location.href = ParentUrl + "?Group=" + document.getElementById("GroupSelect").childNodes[index * 2 + 1].id + "&Arrange=<%=Request.Form("Arrange")%>&Module=<%=Module%>";
}

function ChangeArrange(id) {
  document.location.href = ParentUrl + "?Arrange=" + id + "&Module=<%=Module%>";
}

function NoSelect() {
  for (i = 0; i < document.all.length; i++)
    document.all[i].unselectable = "on";
}

function ModuleWindow() {
  window.open("./selectmodule.asp?Group=<%=Group%>&Arrange=<%=Request.Form("Arrange")%>",null,"height=350,width=300,status=no,toolbar=no,menubar=no,location=no,titlebar=no");
}


</script>

<script language="Javascript" src="dragger.js"></script>

</HEAD>

<BODY onload="NoSelect()">

<table width="100%">
  <tr><td width=50%>
    <table align=center valign=middle>
      <tr><td align=left>
        <INPUT type="radio" class="SelectButton" onclick="ChangeArrange(1)" name="ChangeArrange" <%if Request.Form("Arrange") = 1 then%>checked<%end if%>>
          Arrange by <%=Request.Form("Arrange1")%><br>
        <INPUT type="radio" class="SelectButton" onclick="ChangeArrange(2)" name="ChangeArrange" <%if Request.Form("Arrange") = 2 then%>checked<%end if%>>
          Arrange by <%=Request.Form("Arrange2")%>
      </td></tr>
    </table>
  </td><td width=50%>
    <table align=center valign=middle>
      <tr><td align=left width=*>
        <%if GetActive(Module) = true then%>
          <img src="./images/module.gif" border=1 align=top alt="Currently Active">
        <%else%>
          <img src="./images/dmodule.gif" border=1 align=top alt="Currently Not Active">
        <%end if%>
        <img src="./images/white.gif" width=5 height=1 border=0>
        <%=ThisModuleName%>
      </td><td align=right>
        <a class="button" href="javascript: ModuleWindow()"><img src="./images/selectmodule.gif" valign=middle border=0 alt="Switch modules"></a>
      </tr></td><tr><td align=left colspan=2>
        <img src="<%=GroupImage%>" border=1 valign=middle
        <%if GroupActive = 1 then%>
          alt = "Currently active."
        <%else%>
          alt = "Currently not active."
        <%end if%>>
        <img src="./images/white.gif" width=5 height=1 border=0>
        <SELECT onchange="ChangeGroup(this.selectedIndex)" ID="GroupSelect" style="width: 155px"> 
          <%if Request.Form("Arrange") = 1 then          
            strSQL = "SELECT " & GroupIDField & ", " + GroupNameField + " FROM " + GroupTable + " ORDER BY " & GroupIDField & ";"
            set rst = dbobj.Execute(strSQL)
            do until rst.eof%>
              <OPTION id="<%=rst(GroupIDField)%>"
                <%if CStr(rst(GroupIDField)) = CStr(Group) then%>
                  SELECTED
                <%end if%>>
                <%=rst(GroupNameField)%>
              </OPTION>
              <%rst.movenext()
            loop
          else
            strSQL = "SELECT PrivilegeID, " + GroupNameField + " FROM " + GroupTable + " WHERE ModuleID=" & Module & " ORDER BY " & GroupIDField & ";"
            set rst = dbobj.Execute(strSQL)
            do until rst.eof%>
              <OPTION id="<%=Module%>.<%=rst("PrivilegeID")%>"
                <%if CStr(Module) & "." & CStr(rst("PrivilegeID")) = Group then%>
                  SELECTED
                <%end if%>>
                <%=rst(GroupNameField)%>
              </OPTION>
              <%rst.movenext()
            loop
          end if%>
        </SELECT>
      </td></tr>
    </table>
  </td></tr>
</table>


<FORM name="SendData" method="post" target="tabhidden" action="<%=Request.Form("SubmitURL")%>">
  <INPUT type="hidden" name="InList">
  <INPUT type="hidden" name="ConnStr"			value="<%=Request.Form("ConnStr")%>">
  <INPUT type="hidden" name="JoinerTable"		value="<%=JoinerTable%>">
  <INPUT type="hidden" name="JoinerItemField"		value="<%=JoinerItemField%>">
  <INPUT type="hidden" name="JoinerGroupField"		value="<%=JoinerGroupField%>">
  <INPUT type="hidden" name="OriginalIn"		value="<%if NoIn <> 1 then%><%for i = 0 to ubound(InNames)%>,<%=InIDs(i)%><%next%><%end if%>">
  <INPUT type="hidden" name="JoinerID"			value="<%if NoIn <> 1 then%><%for i = 0 to ubound(InNames)%>,<%=JoinerID(i)%><%next%><%end if%>">
  <INPUT type="hidden" name="GroupID"			value="<%=Group%>">
  <INPUT type="hidden" name="Arrange"			value="<%=Request.Form("Arrange")%>">
  <INPUT type="hidden" name="Module"			value="<%=Request.Form("Module")%>">
  <INPUT type="hidden" name="ParentUrl"			value="<%=Request.Form("ThisUrl")%>">
</FORM>

<script>
  // ----- More Dragger Settings -----
  var ListOut = new Array(	<%if NoOut <> 1 then
				  for i = 0 to ubound(OutNames)%>
				    "<%=OutNames(i)%>"
				    <%if i <> ubound(OutNames) then%>,<%end if%>
				  <%next
				end if%>);

  var ListIn = new Array(	<%if NoIn <> 1 then
				  for i = 0 to ubound(InNames)%>
				    "<%=InNames(i)%>"
				    <%if i <> ubound(InNames) then%>,<%end if%>
				  <%next
				end if%>);

  var IDOut = new Array(	<%if NoOut <> 1 then
				  for i = 0 to ubound(OutNames)%>
				    "<%=OutIDs(i)%>"
				    <%if i <> ubound(OutNames) then%>,<%end if%>
				  <%next
				end if%>);

  var IDIn = new Array(		<%if NoIn <> 1 then
				  for i = 0 to ubound(InNames)%>
				    "<%=InIDs(i)%>"
				    <%if i <> ubound(InNames) then%>,<%end if%>
				  <%next
				end if%>);

  var ActiveOut = new Array(	<%if NoOut <> 1 then
				  if ItemActiveField <> "" then
				    for i = 0 to ubound(OutNames)%>
				      "<%=OutActive(i)%>"
				      <%if i <> ubound(OutNames) then%>,<%end if%>
				    <%next
				  end if
				end if%>);

  var ActiveIn = new Array(	<%if NoIn <> 1 then
				  if ItemActiveField <> "" then
				    for i = 0 to ubound(InNames)%>
				      "<%=InActive(i)%>"
				      <%if i <> ubound(InNames) then%>,<%end if%>
				    <%next
				  end if
				end if%>);

  SubmitForm		= document.forms.SendData;
  SubmitField		= document.forms.SendData.InList;

  // ----- Draw Lists -----
  
  Lists(IDOut, ListOut, ActiveOut, IDIn, ListIn, ActiveIn);
</script>

</BODY>

<%
rst.close
set rst=nothing
dbobj.Close 
set dbobj=nothing
%>

</HTML>