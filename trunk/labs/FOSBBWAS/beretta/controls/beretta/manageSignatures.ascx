<%@ Register TagPrefix="myTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="manageSignatures.ascx.cs" Inherits="beretta.Web.manageSignatures" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Manage Signatures </h1>

<asp:Panel ID="panelAdd" Runat="server" Visible="false"><BR>
<mytab:tabstrip id="TabStrip1" style="FONT: 8pt Verdana" Runat="server" width="790" TargetId="sessionTabs"
		TabDefaultStyle="color:#000000;background:#C4D3FF; border-color:#6D99FE; border-width:1px; border-style:solid; font-weight:bold; font-family:Verdana; font-size:12px; height:25px; width:90px; text-align:center;"
		TabHoverStyle="background:#DDF0FF;color:#000000" TabSelectedStyle="color:#000000;background:white;border-bottom:none;font-weight:bold"
		SepDefaultStyle="width:3px;border-bottom:solid 1px #6D99FE;">
		<myTab:Tab Text="Signature" />
		<myTab:TabSeparator />
		<myTab:Tab Text="Test" />
		<myTab:TabSeparator />
	</mytab:tabstrip>
<mytab:multipage id="sessionTabs" style="BORDER-RIGHT: #6d99fe 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: medium none; PADDING-LEFT: 10px; BACKGROUND: white; PADDING-BOTTOM: 10px; BORDER-LEFT: #6d99fe 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #6d99fe 1px solid"
		runat="server" Width="790">
		<myTab:PageView>
			<SPAN class="normal"><STRONG>Signature</STRONG>
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
						<TD><SPAN class="normal">Signature Name: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtSignatureName" CssClass="normaltextbox" Runat="server" Width="600"></asp:TextBox>
							<asp:Label id="lblHiddenId" Visible="False" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD vAlign="top"><SPAN class="normal">Signature Value: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD vAlign="top">
							<asp:TextBox id="txtSignatureValue" CssClass="normaltextbox" Runat="server" Width="600" Rows="5"
								TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD><SPAN class="normal">Signature Operator: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:RadioButton id="radOperatorEquals" CssClass="normal" Runat="server" Text="Equals" GroupName="signatureOperator"></asp:RadioButton>&nbsp;
							<asp:RadioButton id="radOperatorNotEqual" CssClass="normal" Runat="server" Text="Not Equal" GroupName="signatureOperator"></asp:RadioButton></TD>
					</TR>
					<TR>
						<TD><SPAN class="normal">Signature Type: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:RadioButton id="radStringMatch" CssClass="normal" Runat="server" Text="String Match" Checked="True"
								GroupName="signatureType"></asp:RadioButton>&nbsp;
							<asp:RadioButton id="radRegex" CssClass="normal" Runat="server" Text="Regular Expression" GroupName="signatureType"></asp:RadioButton></TD>
					</TR>
					<TR>
						<TD vAlign="top"><SPAN class="normal">Signature Description: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD vAlign="top">
							<asp:TextBox id="txtSignatureDescription" CssClass="normaltextbox" Runat="server" Width="600"
								Rows="5" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD><SPAN class="normal">Signature Message: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtSignatureMessage" CssClass="normaltextbox" Runat="server" Width="600"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD><SPAN class="normal">Message Type: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:RadioButton id="radInfo" Checked="True" CssClass="normal" Runat="server" Text="Info" GroupName="signatureMessageType"></asp:RadioButton>&nbsp;
							<asp:RadioButton id="radWarning" CssClass="normal" Runat="server" Text="Warning" GroupName="signatureMessageType"></asp:RadioButton>&nbsp;
							<asp:RadioButton id="radCritical" CssClass="normal" Runat="server" Text="Critical" GroupName="signatureMessageType"></asp:RadioButton>
						</TD>
					</TR>
					<TR>
						<TD><SPAN class="normal">Signature Order: </SPAN>
						</TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtSignatureOrder" CssClass="normaltextbox" Runat="server" Width="600"></asp:TextBox></TD>
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
<asp:Button ID="cmdGet" Runat="server" Text="Get"></asp:Button>
								&nbsp; 
<asp:Button ID="cmdReset" Runat="server" Text="Reset"></asp:Button>
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
								<br><br>
								<asp:Label ID="lblResult" Runat="server" CssClass="normal"></asp:Label>
								<br><br>
								</myTab:PageView>
	</mytab:multipage></SPAN>
						
	<br>					
</asp:Panel>

<asp:LinkButton ID="lnkAdd" Runat="server" text="Add New" CssClass="normal"></asp:LinkButton>
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
		<asp:TemplateColumn ItemStyle-Width="300" HeaderText="Site Description">
			<ItemTemplate>
				<asp:linkbutton ID="txtEditType" text='<%# DataBinder.Eval(Container.DataItem, "signatureName") %>' CommandName="cmdUpdate" CssClass="normal" Width=260 Runat=server />
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn ItemStyle-Width="100">
			<ItemTemplate>
				<asp:ImageButton id="cmdDelete" AlternateText="Delete Item" commandName="cmdDelete" ImageUrl='<%# "~/common/images/delete.gif" %>' Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
