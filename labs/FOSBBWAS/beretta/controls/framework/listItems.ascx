<%@ Control Language="c#" AutoEventWireup="false" Codebehind="listItems.ascx.cs" Inherits="sourceControl.controls.framework.listItems" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<h1>Manage List Items</h1>
<p>This allows you to maintain the list items which are used for various drop down 
	lists.
</p>

<p><asp:label id="lblTitle" Runat="server" Font-Size="10" Font-Name="arial"></asp:label><br>
	<br>
	<asp:label id="lblTitle2" Runat="server" Font-Size="10" Font-Name="arial">List Item Name:</asp:label><asp:textbox id="txtListItemName" Width="200" Runat="server"></asp:textbox>&nbsp;
	<asp:checkbox id="chkIsDefault" Runat="server" Text="Is Default" Font-Size="10" Font-Name="arial"></asp:checkbox>&nbsp;
	<asp:button id="cmdAdd" Runat="server" Text="Add"></asp:button>&nbsp;
	<asp:button id="cmdCancel" Runat="server" Text="Cancel"></asp:button><br>
	<br>
	<asp:listbox id="lstItems" Width="480" Runat="server"></asp:listbox><br>
	<br>
	<asp:button id="cmdUp" Runat="server" Text=" Up " NAME="Button1"></asp:button>&nbsp;
	<asp:button id="cmdDown" Runat="server" Text=" Down " NAME="Button2"></asp:button>&nbsp;
	<asp:button id="cmdEdit" Runat="server" Text=" Edit "></asp:button>&nbsp;
	<asp:button id="cmdDelete" Runat="server" Text=" Delete "></asp:button>&nbsp;
</p>
<p>
	<asp:LinkButton ID="lnkBack" Runat="server" text="Back" Font-Underline="True"></asp:LinkButton>
</p>
