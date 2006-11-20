<%@ Control Language="c#" AutoEventWireup="false" Codebehind="recordSession.ascx.cs" Inherits="beretta.Web.controls.recordSession" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Record Session </h1>

<!-- Record Panel -->
<asp:Panel ID="panelRecord" Runat="server" Visible="False">
	<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD>
							<asp:Panel id="panelMessage" Visible="False" Runat="server">
								<BR>
								<asp:Label id="lblMessage" Runat="server" CssClass="normal"></asp:Label>
								<BR>
								<BR>
							</asp:Panel>
							<asp:Button id="cmdRecord" Runat="server" Text="Record"></asp:Button>
							<asp:Button id="cmdPause" Visible="False" Runat="server" Text="Pause"></asp:Button>&nbsp;
							<asp:Button id="cmdStop" Runat="server" Text="End"></asp:Button><BR>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
	<BR>
	<BR>
</asp:Panel>
<!-- Eof Record Panel -->
<!-- Inital Session Setup -->
<asp:Panel ID="panelInitialSessionSetup" Runat="server">
	<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD><BR>
							<asp:ValidationSummary id="ValidationSummary1" Runat="server" HeaderText="The following errors occurred:"
								Font-Name="arial" Font-Size="10"></asp:ValidationSummary>
							<TABLE>
								<TR>
									<TD><SPAN class="normal">Session Name:</SPAN></TD>
									<TD>&nbsp;</TD>
									<TD>
										<asp:TextBox id="txtSessionName" Runat="server" CssClass="normaltextbox" Width="500">Test
									</asp:TextBox>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" Runat="server" Font-Name="arial" Font-Size="10" ControlToValidate="txtSessionName"
											text="<" ErrorMessage="Session name is blank" ForeColor="#ff0000"></asp:RequiredFieldValidator>
										<asp:Label id="lblHiddenId" Visible="False" Runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD vAlign="top"><SPAN class="normal">Session Description:</SPAN></TD>
									<TD>&nbsp;</TD>
									<TD vAlign="top">
										<asp:TextBox id="txtSessionDescription" Runat="server" CssClass="normaltextbox" Width="500" TextMode="MultiLine"
											Rows="5">Test</asp:TextBox>
										<asp:RequiredFieldValidator id="Requiredfieldvalidator2" Runat="server" Font-Name="arial" Font-Size="10" ControlToValidate="txtSessionDescription"
											text="<" ErrorMessage="Session description is blank" ForeColor="#ff0000" NAME="Requiredfieldvalidator2"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD vAlign="top"><SPAN class="normal">Application Base Url:</SPAN></TD>
									<TD>&nbsp;</TD>
									<TD vAlign="top">
										<asp:TextBox id="txtApplicationBaseUrl" Runat="server" Width="500"></asp:TextBox>
										<asp:RequiredFieldValidator id="Requiredfieldvalidator4" Runat="server" Font-Name="arial" Font-Size="10" ControlToValidate="txtApplicationBaseUrl"
											text="<" ErrorMessage="Application base url is blank" ForeColor="#ff0000" NAME="Requiredfieldvalidator3"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD vAlign="top"><SPAN class="normal">Url:</SPAN></TD>
									<TD>&nbsp;</TD>
									<TD vAlign="top">
										<asp:TextBox id="txtUrl" Runat="server" Width="500"></asp:TextBox>
										<asp:RequiredFieldValidator id="Requiredfieldvalidator3" Runat="server" Font-Name="arial" Font-Size="10" ControlToValidate="txtUrl"
											text="<" ErrorMessage="Url is blank" ForeColor="#ff0000" NAME="Requiredfieldvalidator3"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>&nbsp;</TD>
									<TD>
										<asp:Button id="cmdStartRecordingNewSession" Runat="server" Text="Start New Session"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</asp:Panel>
<!-- Eof Inital Session Setup -->
<br>
<br>
<asp:Panel ID="panelRetrievedSite" Visible="False" Runat="server">
	<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD><BR>
							</FORM><SPAN class="normal"><STRONG>URL:</STRONG></SPAN><BR>
							<BR>
							<asp:TextBox id="txtCurrentURL" Runat="server" Width="800" Enabled="False"></asp:TextBox><BR>
							<BR>
							<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
								<TR>
									<TD>
										<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
											<TR>
												<TD>
													<asp:Panel id="panelHtml" Runat="server"></asp:Panel></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<BR>
							<BR>
							<SPAN class="normal"><STRONG>Submitted Payload:</STRONG></SPAN><BR>
							<BR>
							<asp:TextBox id="txtPayload" Runat="server" Width="800" TextMode="MultiLine" Rows="5" Height="100"></asp:TextBox></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</asp:Panel>
