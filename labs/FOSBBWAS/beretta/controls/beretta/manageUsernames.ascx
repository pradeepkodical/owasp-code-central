<%@ Control Language="c#" AutoEventWireup="false" Codebehind="manageUsernames.ascx.cs" Inherits="beretta.Web.manageUsernames" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Manage Usernames
</h1>
<asp:linkbutton ID="lnkNew" Font-Bold="True" cssclass="normal" text="New" Runat="server" />
<br>
<br>
<asp:textbox id="txtHiddenAlphabet" Visible="false" Runat="server"></asp:textbox>
<table bgcolor="graytext" cellspacing="0" cellpadding="1">
	<tr>
		<td>
			<table width="700" class="searchPanel">
				<tr>
					<td></td>
				</tr>
			</table>
			<table width="700" class="searchPanel">
				<tr width="700" class="searchPanel">
					<td width="0"></td>
					<td width="0"></td>
					<td width="350"><span class="datagridSearchText">Username:</span></td>
					<td width="50"></td>
				</tr>
				<tr width="700" class="searchPanel">
					<td width="0"></td>
					<td width="0"><asp:TextBox ID="txtProductId" Visible="False" CssClass="NormalTextBox" Width="0" runat="server" /></td>
					<td width="350"><asp:TextBox ID="txtSectionName" runat="server" Width="200" CssClass="NormalTextBox" />
						<asp:Button ID="cmdSearch" Text="Search" Runat="server" cssclass="NormalButton"></asp:Button>
						&nbsp;
						<asp:Button ID="cmdReset" Text="Reset" Runat="server" cssclass="NormalButton"></asp:Button>
					</td>
					<td width="0"></td>
				</tr>
				<tr width="700">
					<td width="35"></td>
					<td width="38"></td>
					<td width="300"></td>
					<td width="50"></td>
				</tr>
			</table>
			<asp:datagrid id="dbgrid" runat="server" Width="700" OnItemCommand="dgCommand_onClick" PagerStyle-Mode="NumericPages"
				AllowPaging="True" dataKeyField="id" bordercolor="#B4B6C7" borderwidth="0px" gridlines="Horizontal"
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
						<FooterTemplate>
							&nbsp; &nbsp;
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn ItemStyle-Width="20">
						<ItemTemplate>
							&nbsp; &nbsp;
						</ItemTemplate>
						<FooterTemplate>
							&nbsp; &nbsp;
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Username" ItemStyle-Width="300">
						<ItemTemplate>
							<asp:textbox ID="txtExistingValue" Width=100 MaxLength=50 text='<%# DataBinder.Eval(Container.DataItem, "username") %>' CssClass="normaltextbox" Runat=server />
						</ItemTemplate>
						<FooterTemplate>
							<asp:TextBox ID="txtValue" width="100" MaxLength="50" CssClass="NormalTextBox" Runat="server" />
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Item Order" ItemStyle-Width="300">
						<ItemTemplate>
							<asp:textbox ID="txtExistingOrder" Width=100 MaxLength=50 text='<%# DataBinder.Eval(Container.DataItem, "usernameOrder") %>' CssClass="normaltextbox" Runat=server />
						</ItemTemplate>
						<FooterTemplate>
							<asp:TextBox ID="txtOrder" width="100" MaxLength="50" CssClass="NormalTextBox" Runat="server" />
							<asp:Button ID="cmdAddNewSection" CommandName="cmdAdd" Text="Add" Runat="server" CssClass="normalbutton" />
							<asp:Button ID="cmdCancelAddNew" CommandName="cmdCancel" Text="Cancel" Runat="server" CssClass="normalbutton" />
						</FooterTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn ItemStyle-Width="100">
						<ItemTemplate>
							<asp:LinkButton ID="cmdUpdate" text="Update" CommandName="cmdUpdate" CssClass="normal" Runat="server" />
							&nbsp; &nbsp;
							<asp:ImageButton id="cmdDelete" AlternateText="Delete Item" commandName="cmdDelete" ImageUrl='<%# "~/common/images/delete.gif" %>' Runat="server" />
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			<table width="700" class="searchPanel">
				<tr class="searchPanel">
					<td align="center">
						<asp:linkbutton id="LinkButton0" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="A" commandName="A"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton1" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="B" commandName="B"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton2" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="C" commandName="C"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton3" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="D" commandName="D"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton4" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="E" commandName="E"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton5" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="F" commandName="F"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton6" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="G" commandName="G"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton7" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="H" commandName="H"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton8" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="I" commandName="I"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton9" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="J" commandName="J"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton10" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="K" commandName="K"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton11" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="L" commandName="L"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton12" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="M" commandName="M"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton13" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="N" commandName="N"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton14" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="O" commandName="O"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton15" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="P" commandName="P"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton16" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="Q" commandName="Q"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton17" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="R" commandName="R"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton18" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="S" commandName="S"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton19" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="T" commandName="T"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton20" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="U" commandName="U"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton21" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="V" commandName="V"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton22" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="W" commandName="W"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton23" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="X" commandName="X"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton24" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="Y" commandName="Y"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton25" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="Z" commandName="Z"></asp:linkbutton>&nbsp;
						<asp:linkbutton id="Linkbutton26" onclick="alphabet_onClick" Runat="server" CssClass="datagridAlphabetPager"
							text="*" commandName="*"></asp:linkbutton>
					</td>
				</tr>
			</table>
			<table width="700" class="searchPanel">
				<tr class="searchPanel">
					<td></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
