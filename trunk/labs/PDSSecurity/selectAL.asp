<% Response.Buffer=true %>

<%Privilege = "100002.203"%>
<!--#include file ="checkprivilege.asp"-->

<form name="PDSList" method=post action="./pdslist/displist.asp?bar=1">
<INPUT type="hidden" name=ConnStr		value=<%=Application("SecurityConnStr")%>>
<INPUT type="hidden" name=FromTbl		value="SecAccessLevel">
<INPUT type="hidden" name=FieldCSV		value="ID,AccessLevelName">
<INPUT type="hidden" name=PermFilter		value="">
<INPUT type="hidden" name=OrderCSV		value="AccessLevelName;ASC">
<INPUT type="hidden" name=TitleCSV		value="ID,Access Level Name">
<INPUT type="hidden" name=VarTypeCSV		value="L,S">
<INPUT type="hidden" name=PropertyCSV		value="H,S">
<INPUT type="hidden" name=EditTable		value="">
<INPUT type="hidden" name=PrimaryKey		value="ID">
<INPUT type="hidden" name=StyleSheet		value="../CSS/list.css">
<INPUT type="hidden" name=ActionCSV		value="">
<INPUT type="hidden" name=FilterColCSV		value="">
<INPUT type="hidden" name=Filters		value=",,,1,C,<%=Request.QueryString("filterstr")%>">
<INPUT type="hidden" name=DefaultAddCSV		value="">
<INPUT type="hidden" name=ValidateCSV		value="">
<INPUT type="hidden" name=ValidateCSV2		value="">
<INPUT type="hidden" name=AddRow		value="">
<INPUT type="hidden" name=FilterBar		value="3">
<INPUT type="hidden" name=SortCSV		value=",1">
<INPUT type="hidden" name=FilterCSV		value=",1">
<INPUT type="hidden" name=HideCSV		value="">
<INPUT type="hidden" name=AlignCSV		value=",Left">
<INPUT type="hidden" name=LinkCSV		value="0,1,../editAL.asp">
<INPUT type="hidden" name=ForceList		value="">
<INPUT type="hidden" name=IconList		value="w">
</form>
<script>document.PDSList.submit()</script>