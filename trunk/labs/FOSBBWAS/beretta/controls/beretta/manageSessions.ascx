<%@ Control Language="c#" AutoEventWireup="false" Codebehind="manageSessions.ascx.cs" Inherits="beretta.Web.manageSessions" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="myTab" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<br>
<h1>Manage Sessions
</h1>
<br>
<asp:Panel ID="panelSession" Visible="False" Runat="server">
	<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD><SPAN class="normal"><STRONG>Session Config</STRONG>
								<BR>
								<BR>
								<asp:Panel id="panelError" Runat="server">
									<asp:Label id="lblError" Runat="server" ForeColor="#ff0000" Font-Size="10" Font-Name="Arial"></asp:Label>
									<BR>
									<BR>
								</asp:Panel>
								<mytab:tabstrip id="TabStrip1" style="FONT: 8pt Verdana" Runat="server" width="790" TargetId="sessionTabs"
									TabDefaultStyle="color:#000000;background:#C4D3FF; border-color:#6D99FE; border-width:1px; border-style:solid; font-weight:bold; font-family:Verdana; font-size:12px; height:25px; width:90px; text-align:center;"
									TabHoverStyle="background:#DDF0FF;color:#000000" TabSelectedStyle="color:#000000;background:white;border-bottom:none;font-weight:bold"
									SepDefaultStyle="width:3px;border-bottom:solid 1px #6D99FE;">
									<myTab:Tab Text="Detail" />
									<myTab:TabSeparator />
									<myTab:Tab Text="Auth" />
									<myTab:TabSeparator />
									<myTab:Tab Text="Pages" />
									<myTab:TabSeparator />
									<myTab:Tab Text="Page Payloads" />
									<myTab:TabSeparator />
									<myTab:Tab Text="Page Signatures" />
									<myTab:TabSeparator />
									<myTab:Tab Text="Global Payloads" />
									<myTab:TabSeparator />
									<myTab:Tab Text="Global Signatures" />
									<myTab:TabSeparator />
								</mytab:tabstrip>
								<mytab:multipage id="sessionTabs" style="BORDER-RIGHT: #6d99fe 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: medium none; PADDING-LEFT: 10px; BACKGROUND: white; PADDING-BOTTOM: 10px; BORDER-LEFT: #6d99fe 1px solid; PADDING-TOP: 10px; BORDER-BOTTOM: #6d99fe 1px solid"
									runat="server" Width="790">
									<myTab:PageView>
										<br>
										<table>
											<tr>
												<td><span class="normal">Session Name:</span></td>
												<td>&nbsp;</td>
												<td>
													<asp:TextBox ID="txtSessionName" CssClass="normaltextbox" Runat="server" Width="500"></asp:TextBox>
													<asp:Label ID="lblHiddenId" Visible="False" Runat="server"></asp:Label>
												</td>
											</tr>
											<tr>
												<td valign="top"><span class="normal">Session Description:</span></td>
												<td>&nbsp;</td>
												<td valign="top">
													<asp:TextBox ID="txtSessionDescription" CssClass="normaltextbox" TextMode="MultiLine" Rows="5"
														Runat="server" Width="500"></asp:TextBox></td>
											</tr>
											<tr>
												<td valign="top"><span class="normal">Application Base Url:</span></td>
												<td>&nbsp;</td>
												<td valign="top">
													<asp:TextBox ID="txtApplicationBaseUrl" CssClass="normaltextbox" Runat="server" Width="500"></asp:TextBox></td>
											</tr>
											<tr>
												<td valign="top"><span class="normal">User Agent:</span></td>
												<td>&nbsp;</td>
												<td valign="top">
													<asp:DropDownList ID="dropDownUserAgent" Runat="server" Width="300"></asp:DropDownList>
												</td>
											</tr>
											<tr>
												<td>
													&nbsp;</td>
												<td>&nbsp;</td>
												<td>&nbsp;</td>
											</tr>
										</table>
										<br>
									</myTab:PageView>
									<myTab:PageView>
										<br>
										<asp:RadioButton ID="radNoAuthentication" Runat="server" Checked="True" GroupName="authentication"
											AutoPostBack="True" Text="No Authentication"></asp:RadioButton>
										<br>
										<asp:RadioButton ID="radFormsAuthentication" Runat="server" GroupName="authentication" AutoPostBack="True"
											Text="Forms Authentication"></asp:RadioButton>
										<br>
										<asp:RadioButton ID="radRawFormsSubmission" Runat="server" GroupName="authentication" AutoPostBack="True"
											Text="Raw Forms Submission"></asp:RadioButton>
										<br>
										<asp:RadioButton ID="radBasicAuthentication" Runat="server" GroupName="authentication" Text="IIS Basic Authentication (Not Available)"></asp:RadioButton>
										<br>
										<asp:RadioButton ID="radPassportAuthentication" Runat="server" GroupName="authentication" Text="Passport Authentication (Not Available)"></asp:RadioButton>
										<br>
										<br>
										<asp:Panel ID="panelAuthenticationDetailsForm" Runat="server" Visible="False">
											<table>
												<tr>
													<td width="200"><span class="normal">Logon Page URL:</span></td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtLogonPageUrl" Runat="server" CssClass="normalTextbox" Width="300"></asp:TextBox></td>
												</tr>
												<tr>
													<td><span class="normal">Username: </span>
													</td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtUsername" Runat="server" CssClass="normalTextbox" Width="300"></asp:TextBox></td>
												</tr>
												<tr>
													<td><span class="normal">Password: </span>
													</td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtPassword" Runat="server" CssClass="normalTextbox" Width="300"></asp:TextBox></td>
												</tr>
												<tr>
													<td><span class="normal">Username Field Name: </span>
													</td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtUsernameFieldName" Runat="server" CssClass="normalTextbox" Width="300"></asp:TextBox></td>
												</tr>
												<tr>
													<td><span class="normal">Password Field Name:</span></td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtPasswordFieldName" Runat="server" CssClass="normalTextbox" Width="300"></asp:TextBox></td>
												</tr>
												<tr>
													<td><span class="normal">Submit Button Field Name: </span>
													</td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtSubmitButtonFieldName" Runat="server" CssClass="normalTextbox" Width="300"></asp:TextBox></td>
												</tr>
											</table>
											<br>
											<br>
										</asp:Panel>
										<asp:Panel ID="panelRawFormsSubmission" Runat="server" Visible="False">
											<table>
												<tr>
													<td width="200"><span class="normal">Logon Page URL:</span></td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtRawLogonPageUrl" Runat="server" CssClass="normalTextbox" Width="500"></asp:TextBox></td>
												</tr>
												<tr>
													<td valign="top"><span class="normal">Raw Submission: </span>
													</td>
													<td>&nbsp;</td>
													<td>
														<asp:TextBox ID="txtRawSubmission" TextMode="MultiLine" Rows="5" Runat="server" CssClass="normalTextbox"
															Width="500"></asp:TextBox></td>
												</tr>
											</table>
											<br>
											<br>
										</asp:Panel>
									</myTab:PageView>
									<myTab:PageView>
										<br>
						
						
								
							
							<span class="normal">Manual Url Add: &nbsp;</span>
							<br>
										<span class="normal">Url: &nbsp;</span>
										<asp:TextBox ID="txtUrl" Runat="server" CssClass="normaltextbox" Width="300"></asp:TextBox> &nbsp; 
										
										<span class="normal">Description: &nbsp;</span>
										<asp:TextBox ID="txtUrlDescription" Runat="server" CssClass="normaltextbox" Width="300"></asp:TextBox> &nbsp;
										
										<asp:Button ID="cmdAddUrl" Runat="server" Text="Add"></asp:Button>
										<br>
										<br>
										
										<span class="normal">Base URL to Spider From (Not available) &nbsp;</span>
							&nbsp; 
							<asp:TextBox ID="txtBaseSpiderUrl" Runat="server" CssClass="normaltextbox" Width="670"></asp:TextBox>
							&nbsp; 
<asp:Button ID="cmdSpiderUrl" Runat="server" Text="Spider Url"></asp:Button>
							<br>
							
										
										<br>
										
									
										<span class="normal">The following pages will be scaned:</span><br>
												<br>		
										<asp:ListBox ID="lstUrls" Runat="server" Width="100%" Rows="5"></asp:ListBox>
										<br>
										
										<asp:Label ID="lblUrlCount" CssClass="normal" Runat="server"></asp:Label>
										<br><br>
										
										<asp:Button ID="cmdRemoveUrl" Runat="server" Text="Remove URL"></asp:Button>
										&nbsp;
										<asp:Button ID="cmdUrlUp" Runat="server" Text=" Up "></asp:Button>
										&nbsp;
										<asp:Button ID="cmdUrlDown" Runat="server" Text=" Down "></asp:Button>
										&nbsp;
										
										<asp:Button ID="cmdRefreshUrl" Runat="server" Text=" Refresh "></asp:Button>
										&nbsp;
										
									
										
										
									</myTab:PageView>
									<myTab:PageView>
										<br>
										<span class="normal">Url: </span>
										<asp:DropDownList ID="dropDownUrl" AutoPostBack="True" Runat="server" Width="400"></asp:DropDownList>
										<br>
										<Br>
										<table width="100%">
											<tr>
												<td><span class="normal"><strong>Session Payloads:</strong></span></td>
												<td width="50"></td>
												<td><span class="normal"><strong>All Payloads:</strong></span></td>
											</tr>
											<tr>
												<td>
													<asp:listbox ID="lstSessionPayloads" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
												<td valign="top">
													<asp:Button ID="cmdAddPayload" Runat="server" Font-Bold="True" Text="     <    "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdRemovePayload" Runat="server" Font-Bold="True" Text="    >     "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdPayloadUp" Runat="server" Font-Bold="True" Text="   Up    "></asp:Button>
													<br>
													<asp:Button ID="cmdPayloadDown" Runat="server" Font-Bold="True" Text=" Down "></asp:Button>
													<br>
													<br>
												</td>
												<td>
													<asp:listbox ID="lstAllPayloads" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
											</tr>
										</table>
										<br>
										<br>
										
									</myTab:PageView>
									<myTab:PageView>
										<br>
										<span class="normal">Url: </span>
										<asp:DropDownList ID="dropDownUrl2" AutoPostBack="True" Runat="server" Width="400"></asp:DropDownList>
										<br>
										<Br>
										<table width="100%">
											<tr>
												<td><span class="normal"><strong>Session Signatures:</strong></span></td>
												<td width="50"></td>
												<td><span class="normal"><strong>All Signatures:</strong></span></td>
											</tr>
											<tr>
												<td>
													<asp:listbox ID="lstSessionSignatures" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
												<td valign="top">
													<asp:Button ID="cmdAddSignature" Runat="server" Font-Bold="True" Text="     <    "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdRemoveSignature" Runat="server" Font-Bold="True" Text="    >     "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdSignatureUp" Runat="server" Font-Bold="True" Text="   Up    "></asp:Button>
													<br>
													<asp:Button ID="cmdSignatureDown" Runat="server" Font-Bold="True" Text=" Down "></asp:Button>
													<br>
													<br>
												</td>
												<td>
													<asp:listbox ID="lstAllSignatures" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
											</tr>
										</table>
										<br>
										<br>
									</myTab:PageView>
									<myTab:PageView>
										<table width="100%">
											<tr>
												<td><span class="normal"><strong>Global Payloads:</strong></span></td>
												<td width="50"></td>
												<td><span class="normal"><strong>All Payloads:</strong></span></td>
											</tr>
											<tr>
												<td>
													<asp:listbox ID="lstGlobalPayloads" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
												<td valign="top">
													<asp:Button ID="cmdAddGlobalPayload" Runat="server" Font-Bold="True" Text="     <    "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdRemoveGlobalPayload" Runat="server" Font-Bold="True" Text="    >     "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdGlobalAll" Runat="server" Font-Bold="True" Text=" < All   "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdGlobalAllRemove" Runat="server" Font-Bold="True" Text="  All >  "></asp:Button>
												</td>
												<td>
													<asp:listbox ID="lstGlobalAllPayloads" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
											</tr>
										</table>
										
										<br><br>
											<asp:CheckBox ID="chkAutoScan" CssClass="normal" Text="Auto Scan" Runat="server"></asp:CheckBox><br>
											<asp:CheckBox ID="chkEncoding" CssClass="normal" Text="Encode Auto Scan" Runat="server"></asp:CheckBox>
									<br><br>
										
									</myTab:PageView>
									<myTab:PageView>
										<table width="100%">
											<tr>
												<td><span class="normal"><strong>Global Signatures:</strong></span></td>
												<td width="50"></td>
												<td><span class="normal"><strong>All Signatures:</strong></span></td>
											</tr>
											<tr>
												<td>
													<asp:listbox ID="lstGlobalSignatures" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
												<td valign="top">
													<asp:Button ID="cmdAddGlobalSignature" Runat="server" Font-Bold="True" Text="     <    "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdRemoveGlobalSignature" Runat="server" Font-Bold="True" Text="    >     "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdGlobalSignatureAll" Runat="server" Font-Bold="True" Text=" < All   "></asp:Button>
													<br>
													<br>
													<asp:Button ID="cmdGlobalSignatureAllRemove" Runat="server" Font-Bold="True" Text="  All >  "></asp:Button>
												</td>
												<td>
													<asp:listbox ID="lstGlobalAllSignatures" Width="330" Height="200" Runat="server"></asp:listbox>
												</td>
											</tr>
										</table>
									</myTab:PageView>
								</mytab:multipage><BR>
								<asp:Panel id="panelReport" Runat="server" Visible="False">
									<asp:HyperLink id="lnkReport" Runat="server" Target="_blank" Font-Underline="True" CssClass="normal"
										Font-Bold="True" text="View Report"></asp:HyperLink>
									<BR>
									<BR>
								</asp:Panel>
								<asp:Button id="cmdAdd" Runat="server" Text="Save"></asp:Button>&nbsp;
								<asp:Button id="cmdClose" Runat="server" Text="Close"></asp:Button>&nbsp;
								<asp:Button id="cmdInitiate" Runat="server" Text="Run Scan"></asp:Button></SPAN></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
	<BR>
	<BR>
</asp:Panel>
<asp:LinkButton ID="lnkNew" CssClass="normal" Runat="server" Font-Bold="True">Add New</asp:LinkButton>
<br>
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
		<asp:TemplateColumn HeaderText="Session Name">
			<ItemTemplate>
				<asp:LinkButton ID="Linkbutton1" text='<%# DataBinder.Eval(Container.DataItem, "sessionName") %>' CommandName="cmdUpdate" CssClass="normal" Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn HeaderText="Base Url">
			<ItemTemplate>
				<asp:label ID="Label1" text='<%# DataBinder.Eval(Container.DataItem, "applicationBaseUrl") %>' CssClass="normal" Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn HeaderText="Created">
			<ItemTemplate>
				<asp:label ID="Linkbutton2" text='<%# DataBinder.Eval(Container.DataItem, "created") %>' CssClass="normal" Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn ItemStyle-Width="100">
			<ItemTemplate>
				<asp:ImageButton id="cmdDelete" AlternateText="Delete Item" commandName="cmdDelete" ImageUrl='<%# "~/common/images/delete.gif" %>' Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
