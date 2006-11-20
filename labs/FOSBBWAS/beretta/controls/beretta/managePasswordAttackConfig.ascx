<%@ Control Language="c#" AutoEventWireup="false" Codebehind="managePasswordAttackConfig.ascx.cs" Inherits="beretta.Web.managePasswordAttackConfig" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Manage Password Attack Config </h1>

<br>
<asp:Label ID=lblMessage CssClass=normal Runat=server>
</asp:Label>
<br><br>

<asp:Panel ID="panelAdd" Runat="server" Visible="false">
<br>
	<TABLE cellSpacing="1" cellPadding="0" width="800" bgColor="#cccccc" border="0">
		<TR>
			<TD>
				<TABLE cellSpacing="1" cellPadding="10" width="800" bgColor="#ffffff" border="0">
					<TR>
						<TD><SPAN class="normal"><STRONG>Dictionary Config</STRONG>
								<asp:Panel id="panelError" Visible="False" Runat="server">
								<br>
									<asp:Label id="lblErrorMessage" CssClass=normaltextbox Runat="server" ForeColor="#ff0000" Font-Size="10" Font-Name="Arial"></asp:Label>
									<br><br>
								</asp:Panel>
								<TABLE>
									<TR>
										<TD><SPAN class="normal">Site Description: </SPAN>
										</TD>
										<TD>&nbsp;</TD>
										<TD>
											<asp:TextBox id="txtDescription" CssClass=normaltextbox Runat="server" Width="600"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD><SPAN class="normal">Login Page URL: </SPAN>
										</TD>
										<TD>&nbsp;</TD>
										<TD>
											<asp:TextBox id="txtUrl" CssClass=normaltextbox Runat="server" Width="600">http://localhost/Silverbear.Web.Events.Admin.UI/default.aspx?tabid=25</asp:TextBox>
											<asp:Label id="lblHiddenId" Visible="False" Runat="server"></asp:Label></TD>
									</TR>
									
									<tr>
										<TD><SPAN class="normal">Form Submission use %%username%% and %%password%% as placeholders: </SPAN>
										</TD>
										<TD>&nbsp;</TD>
										<TD>
										
											<asp:TextBox ID=txtFormSubmission Width=300 TextMode=MultiLine Rows=5 Runat=server>
											
											
											</asp:TextBox>	
										</TD>
									
									</tr>
									
									<TR>
										<TD><SPAN class="normal">Signature Operator: </SPAN>
										</TD>
										<TD>&nbsp;</TD>
										<TD>
											<asp:RadioButton id="sigEquals" Runat="server" Text="Equal To" CssClass="normal" GroupName="signatureOperator"></asp:RadioButton>&nbsp;
											<asp:RadioButton id="sigNotEqual" Runat="server" Text="Not Equal To" CssClass="normal" GroupName="signatureOperator"></asp:RadioButton></TD>
									</TR>
									<TR>
										<TD><SPAN class="normal">Signature Type: </SPAN>
										</TD>
										<TD>&nbsp;</TD>
										<TD>
											<asp:RadioButton id="sigTypeStringMatch" Runat="server" Text="String Match" CssClass="normal" GroupName="signatureType"></asp:RadioButton>&nbsp;
											<asp:RadioButton id="sigTypeRegex" Runat="server" Text="Regular Expression" CssClass="normal" GroupName="signatureType"></asp:RadioButton></TD>
									</TR>
									<TR>
										<TD><SPAN class="normal">Signature Value: </SPAN>
										</TD>
										<TD>&nbsp;</TD>
										<TD>
											<asp:TextBox id="txtSuccessSignature" CssClass=normaltextbox Runat="server" Width="600"></asp:TextBox></TD>
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
							</SPAN>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
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
				<asp:linkbutton ID="txtEditType" text='<%# DataBinder.Eval(Container.DataItem, "description") %>' CommandName="cmdUpdate" CssClass="normal" Width=260 Runat=server />
			</ItemTemplate>
		</asp:TemplateColumn>
		
		
		
		
		<asp:TemplateColumn ItemStyle-Width="100">
			<ItemTemplate>
			
				<asp:LinkButton Text="Initiate" Font-Underline=True commandName="cmdInitiate" Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
		
		
		<asp:TemplateColumn ItemStyle-Width="100">
			<ItemTemplate>
			
				<asp:ImageButton id="cmdDelete" AlternateText="Delete Item" commandName="cmdDelete" ImageUrl='<%# "~/common/images/delete.gif" %>' Runat="server" />
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>

<br><br>

<asp:Label id=lblResult Runat=server CssClass=normal></asp:Label>
