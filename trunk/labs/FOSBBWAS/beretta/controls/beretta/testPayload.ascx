<%@ Register TagPrefix="myTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="testPayload.ascx.cs" Inherits="beretta.Web.controls.testPayload" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Test Payload:</h1>
<br>

<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
	<TR>
		<TD>
			<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
				<TR>
					<TD><asp:panel id="panelPage" Runat="server" Height="400" Width="600"></asp:panel></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
<br>
<br>
<mytab:tabstrip id="TabStrip1" style="FONT: 8pt Verdana" Runat="server" width="790" TargetId="sessionTabs"
	TabDefaultStyle="color:#000000;background:#C4D3FF; border-color:#6D99FE; border-width:1px; border-style:solid; font-weight:bold; font-family:Verdana; font-size:12px; height:25px; width:90px; text-align:center;"
	TabHoverStyle="background:#DDF0FF;color:#000000" TabSelectedStyle="color:#000000;background:white;border-bottom:none;font-weight:bold"
	SepDefaultStyle="width:3px;border-bottom:solid 1px #6D99FE;">
	<myTab:Tab Text="Payload" />
	<myTab:TabSeparator />
	<myTab:Tab Text="Signatures" />
	<myTab:TabSeparator />
</mytab:tabstrip><mytab:multipage id="sessionTabs" style="BORDER-RIGHT: #6d99fe 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: medium none; PADDING-LEFT: 10px; BACKGROUND: white; PADDING-BOTTOM: 10px; BORDER-LEFT: #6d99fe 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #6d99fe 1px solid"
	Width="790" runat="server">
	<myTab:PageView>
		<table>
			<tr>
				<td><span class="normal">URL:</span></td>
				<td>&nbsp;</td>
				<td><span class="normal">
						<asp:textbox id="txtUrl" Runat="server" Width="600"></asp:textbox></span></td>
			</tr>
			
			<tr>
				<td><span class="normal">Mode:</span></td>
				<td>&nbsp;</td>
				<td>
					<asp:DropDownList ID=dropDownMode Runat=server>
						<asp:ListItem Selected=True Value="POST">POST</asp:ListItem>
						<asp:ListItem Value="GET">GET</asp:ListItem>
					
					</asp:DropDownList>
						
						</td>
			</tr>
			
			<tr>
				<td><span class="normal">User Agent:</span></td>
				<td>&nbsp;</td>
				<td>
					<asp:DropDownList ID="dropDownUserAgent" Width=600 Runat=server>
						
					</asp:DropDownList>
						
						</td>
			</tr>
			
			<tr>
				<td><span class="normal">Send x times:</span></td>
				<td>&nbsp;</td>
				<td>
					<asp:TextBox ID=txtRepeat Width=50 MaxLength=3 text="1" Runat=server></asp:TextBox>
						</td>
			</tr>
			
			<tr>
				<td vAlign="top"><span class="normal">Payload:</span></td>
				<td>&nbsp;</td>
				<td>
				
				<asp:DropDownList ID=dropDownPayloads AutoPostBack=True  Width=600 Runat=server></asp:DropDownList>
				<br>
				
						<asp:textbox id="txtPayload" text="" Runat="server" Height="100" Width="600" Rows="5" TextMode="MultiLine" /></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<asp:CheckBox ID="chkSignatures" Runat="server" Text="Check Response Against Signatures" CssClass="normal"></asp:CheckBox></td>
			</tr>
			<tr>
				<td>&nbsp;
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td>
					<asp:button id="cmdSubmitPayload" Runat="server" Text="Send Payload"></asp:button></td>
				<td></td>
				<td>
					<asp:button id="cmdClear" Runat="server" Text="Clear"></asp:button>
					&nbsp;
					<asp:Button ID="cmdReset" Runat="server" Text="Reset"></asp:Button></td>
			</tr>
		</table>
	</myTab:PageView>
	
	
	<myTab:PageView>
	
	<br>
	<span class=normal>Matching Signatures:</span>
	<br><br>
	
	<asp:Panel ID=panelMatchingSignatures Runat=server></asp:Panel>
	</myTab:PageView>
</mytab:multipage>
