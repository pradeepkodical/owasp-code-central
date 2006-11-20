<%@ Control Language="c#" AutoEventWireup="false" Codebehind="systemEvents.ascx.cs" Inherits="sourceControl.controls.systemEvents" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<br>
<h1>System Events</h1>
<br>

	
	 <asp:DropDownList ID="dropDownEventTypes" AutoPostBack="True" Runat="server" Width="300"></asp:DropDownList>
	<br>
	<br>
<asp:DataGrid ID="dgSystemEvents" OnPageIndexChanged=dbgrid_SelectedIndexChanged PagerStyle-Mode=NumericPages DataKeyField="id" Width=600 BorderWidth="0" AutoGenerateColumns="False"
		ShowFooter="False" AllowPaging="true" Runat="server">
		<HeaderStyle cssclass="titles" />
		<PagerStyle CssClass="DataGrid_PagerStyle" />
		<AlternatingItemStyle CssClass="odd" />
		<ItemStyle CssClass="even" />
		<Columns>
			<asp:BoundColumn DataField="modified" HeaderText="Date"></asp:BoundColumn>
			<asp:BoundColumn DataField="eventDescription" HeaderText="Event"></asp:BoundColumn>
			<asp:BoundColumn DataField="message" HeaderText="Description"></asp:BoundColumn>
			<asp:BoundColumn DataField="username" HeaderText="User"></asp:BoundColumn>
			<asp:BoundColumn DataField="ip" HeaderText="IP"></asp:BoundColumn>
		</Columns>
	</asp:DataGrid></span>
