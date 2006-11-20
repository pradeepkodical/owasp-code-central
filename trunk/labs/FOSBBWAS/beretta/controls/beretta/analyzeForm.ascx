<%@ Control Language="c#" AutoEventWireup="false" Codebehind="analyzeForm.ascx.cs" Inherits="beretta.Web.analyzeForm" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<h1>Analyze Form</h1>

<asp:Panel ID=panelError Runat=server>
	
	<asp:Label ID=lblError Font-Name=arial Font-Size=10 ForeColor=#ff0000 Runat=server>
	</asp:Label>
	<br><br>
	
</asp:Panel>

<span class=normal>URL to analyze:</span><br>
 <asp:TextBox ID="txtUrl" Runat="server" Width="300">http://</asp:TextBox>

<asp:Button ID="cmdGet" Text="Analyze" Runat="server"></asp:Button>
<br><br>


<strong>Form Elements:</strong>
<br><br>
<asp:DataGrid ID="dgForm" AutoGenerateColumns=False bordercolor="#B4B6C7" borderwidth="1px" gridlines="Horizontal" Runat="server" Width=600>
<HeaderStyle cssclass="DataGrid_HeaderStyle" />
	<PagerStyle CssClass="DataGrid_PagerStyle" />
	<AlternatingItemStyle CssClass="DataGrid_AlternateStyle" />
	<ItemStyle CssClass="DataGrid_ItemStyle" />
	
	<Columns>
		<asp:TemplateColumn>
			<ItemTemplate>
				&nbsp;
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:BoundColumn DataField="name" HeaderText="Element Name"></asp:BoundColumn>
		<asp:BoundColumn DataField="type" HeaderText="Type"></asp:BoundColumn>
		<asp:BoundColumn DataField="value" HeaderText="Value"></asp:BoundColumn>
	</Columns>
</asp:DataGrid>

<br>

<span class=normal><strong>Server:</strong></span> <br>
<asp:TextBox ID=txtServer Width=500 Runat=server></asp:TextBox> <br>
<br>

<span class=normal><strong>Protocol Version:</strong></span> <br>
<asp:TextBox ID="txtProtocolVersion" Width=500 Runat=server></asp:TextBox> <br>

<br>

<span class=normal><strong>Headers:</strong></span> <br>
<asp:PlaceHolder ID=placeHolderHeaders Runat=server></asp:PlaceHolder>

<br>

<span class=normal><strong>Auto Form Submission:</strong></span> <br>
<asp:PlaceHolder ID="placeHolderFormSubmission" Runat=server></asp:PlaceHolder>
