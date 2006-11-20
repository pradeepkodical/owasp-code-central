<%@ Register TagPrefix="myTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="managePayloads.ascx.cs" Inherits="beretta.Web.managePayloads" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Manage Payloads </h1>

<asp:Panel ID="panelAdd" Runat="server" Visible="false"><BR>
<mytab:tabstrip id="TabStrip1" style="FONT: 8pt Verdana" Runat="server" width="790" TargetId="sessionTabs"
		TabDefaultStyle="color:#000000;background:#C4D3FF; border-color:#6D99FE; border-width:1px; border-style:solid; font-weight:bold; font-family:Verdana; font-size:12px; height:25px; width:90px; text-align:center;"
		TabHoverStyle="background:#DDF0FF;color:#000000" TabSelectedStyle="color:#000000;background:white;border-bottom:none;font-weight:bold"
		SepDefaultStyle="width:3px;border-bottom:solid 1px #6D99FE;">
		<myTab:Tab Text="Payload" />
		<myTab:TabSeparator />
		<myTab:Tab Text="Test Payload" />
		<myTab:TabSeparator />
	</mytab:tabstrip>
<mytab:multipage id="sessionTabs" style="BORDER-RIGHT: #6d99fe 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: medium none; PADDING-LEFT: 10px; BACKGROUND: white; PADDING-BOTTOM: 10px; BORDER-LEFT: #6d99fe 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #6d99fe 1px solid"
		runat="server" Width="790">
		<myTab:PageView>
			<br>
			<SPAN class="normal"><STRONG>Payloads</STRONG>
				<br>
				<br>
				<asp:Panel id="panelError" Visible="False" Runat="server">
					<BR>
					<asp:Label id="lblErrorMessage" Runat="server" Font-Name="Arial" Font-Size="10" ForeColor="#ff0000"></asp:Label>
					<BR>
					<BR>
				</asp:Panel>
				<TABLE>
					<TR>
						<TD><SPAN class="normal">Payload Name: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtPayloadName" CssClass="normaltextbox" Runat="server" Width="600"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD valign="top"><SPAN class="normal">Payload Data: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD valign="top">
							<asp:TextBox id="txtPayloadData" CssClass="normaltextbox" Rows="5" TextMode="MultiLine" Runat="server"
								Width="600">http://localhost/Silverbear.Web.Events.Admin.UI/default.aspx?tabid=25</asp:TextBox>
							<asp:Label id="lblHiddenId" Visible="False" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD valign="top"><SPAN class="normal">Description: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD valign="top">
							<asp:TextBox id="txtDescription" CssClass="normaltextbox" Rows="5" TextMode="MultiLine" Runat="server"
								Width="600"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD><SPAN class="normal">Payload Order: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtPayloadOrder" CssClass="normaltextbox" Runat="server" Width="100" MaxLength="5"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD valign=top><SPAN class="normal">Type: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD valign=top>
						
							<asp:DropDownList ID=dropDownType Runat=server Width=300>
								<asp:ListItem Value=0>Form Submission Manual</asp:ListItem>
								<asp:ListItem Value=1>Form Submission Auto Scan</asp:ListItem>
								<asp:ListItem Value=2>Query String Replace Manual</asp:ListItem>
								<asp:ListItem Value=4>Query String Replace Auto</asp:ListItem>
								<asp:ListItem Value=3>Query String Append Manual </asp:ListItem>
								<asp:ListItem Value=5>Query String Append Auto</asp:ListItem>
							</asp:DropDownList>
													</TD>
					</TR>
					
					
					
					
					<TR>
						<TD>&nbsp;
						</TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>&nbsp;
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:Button id="cmdAdd" Runat="server" Text="Add"></asp:Button>&nbsp;
							<asp:Button id="cmdClose" Runat="server" Text="Close"></asp:Button></TD>
					</TR>
				</TABLE>
		</myTab:PageView>
		<myTab:PageView>
								
								
								<span class="normal">Url: </span> 
								<asp:TextBox ID="txtTestUrl" Runat="server" Width="300" CssClass="normal"></asp:TextBox> &nbsp; 
<asp:Button ID="cmdGet" Runat="server" Text="Submit Payload"></asp:Button>
								<br><br>
								
								<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
				<tr>
					<td><table width="100%" border="0" cellpadding="10" cellspacing="1" bgcolor="#FFFFFF">
							<tr>
								<td>
									<br>
									<asp:panel ID="panelTestResult" Runat="server"></asp:panel>
									<br>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
								
								
								
								</myTab:PageView>
	</mytab:multipage></SPAN>
<br>			
</asp:Panel>

<asp:LinkButton ID="lnkAdd" Runat="server" text="Add New" CssClass="normal"></asp:LinkButton>
&nbsp;
<asp:LinkButton ID="lnkUpdate" Runat="server" text="Update Payloads Over Internet" CssClass="normal"></asp:LinkButton>
<BR>
<br>
<asp:datagrid id="dbgrid" runat="server" Width="800" OnItemCommand="dgCommand_onClick" PagerStyle-Mode="NumericPages"
	AllowPaging="True" dataKeyField="id" bordercolor="#B4B6C7" borderwidth="1px" gridlines="Horizontal"
	ShowHeader="true" AutoGenerateColumns="False" OnItemDataBound="dbgrid_OnItemDataBound" OnPageIndexChanged="dbgrid_SelectedIndexChanged">
	<HeaderStyle cssclass="DataGrid_HeaderStyle" />
	<PagerStyle CssClass="DataGrid_PagerStyle" />
	<AlternatingItemStyle CssClass="DataGrid_AlternateStyle" />
	<ItemStyle CssClass="DataGrid_ItemStyle" />
	<Columns>
		<asp:TemplateColumn ItemStyle-Width="20">
			<ItemTemplate>
				&nbsp; &nbsp;
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn ItemStyle-Width="300" HeaderText="Payload Name">
			<ItemTemplate>
				<asp:linkButton ID="txtEditType" text='<%# DataBinder.Eval(Container.DataItem, "payloadName") %>' CommandName="cmdUpdate" CssClass="normal" Width=260 Runat=server />
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn ItemStyle-Width="100">
			<ItemTemplate>
				<asp:ImageButton id="cmdDelete" AlternateText="Delete Item" commandName="cmdDelete" ImageUrl='<%# "~/common/images/delete.gif" %>' Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
