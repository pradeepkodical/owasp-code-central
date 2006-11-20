<%@ Control Language="c#" AutoEventWireup="false" Codebehind="manageTabs.ascx.cs" Inherits="sourceControl.controls.framework.manageTabs" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>




<h1>Manage Tabs</h1>


<asp:Panel ID="panelModules" Visible=False Runat=server>

<table>
	<tr>
		<td>
		
	
<p>

<asp:DropDownList ID=dropDownModules Width=255 Runat=server></asp:DropDownList>
&nbsp; <asp:Button ID="cmdAddModules" Runat=server Text="Add"></asp:Button>
</p>

<p>
Modules: <br>

<asp:ListBox ID=lstModules Width=300 Runat=server></asp:ListBox>
<br><br>

<asp:Button ID=cmdRemoveModules Runat=server Text="Remove"></asp:Button>
&nbsp;
<asp:Button ID="cmdCloseModules" Runat=server Text="Close"></asp:Button>
</p>

	
	</td>
	</tr>
</table>
</asp:Panel>

<asp:Panel ID=panelNew Visible=False Runat=server>

	<table width=500>
	
		<tr>
			<td> &nbsp; </td>
			<td> &nbsp; </td>
			<td> &nbsp; </td>
			<td> &nbsp;</td>
		</tr>
		
		
		<tr>
			<td> &nbsp; </td>
			<td> Page Name: </td>
			<td> &nbsp; </td>
			<td> <asp:TextBox ID=txtPageName Runat=server Width=300></asp:TextBox></td>
			
		</tr>
		
		<tr>
			<td> &nbsp; </td>
			<td> Allowed Roles: </td>
			<td> &nbsp; </td>
			<td> <asp:TextBox ID="txtAllowedRoles" Runat=server Width=300></asp:TextBox></td>
		</tr>
	
	
		<tr>
			<td> &nbsp; </td>
			<td> Layout: </td>
			<td> &nbsp; </td>
			<td> <asp:DropDownList ID="dropDownLayouts" Runat=server Width=300></asp:DropDownList></td>
		</tr>
		
		<tr>
			<td> &nbsp; </td>
			<td> &nbsp; </td>
			<td> &nbsp; </td>
			<td> &nbsp;</td>
		</tr>
		
		<tr>
			<td> &nbsp; </td>
			<td> &nbsp;</td>
			<td> &nbsp; </td>
			<td>
				<asp:Button ID=cmdAdd Runat=server Text="Add"></asp:Button>
				&nbsp;
				<asp:Button ID="cmdCancel" Runat=server Text="Cancel"></asp:Button>
				
			</td>
		</tr>
		
		<tr>
			<td> &nbsp; </td>
			<td> &nbsp; </td>
			<td> &nbsp; </td>
			<td> &nbsp;</td>
		</tr>
		
	</table>
	

</asp:Panel>

<p>
<asp:LinkButton ID=lnkNew text="New" Runat=server></asp:LinkButton>
<br><br>

<asp:textbox id="txtHiddenAlphabet" Visible="false" Runat="server"></asp:textbox>
<asp:TextBox ID="txtProductId" Visible="False" CssClass="NormalTextBox" Width="0" runat="server" /></td>
<asp:TextBox ID="txtSectionName" runat="server" Width="200" CssClass="NormalTextBox" />
						<asp:Button ID="cmdSearch" Text="Search" Runat="server" cssclass="NormalButton"></asp:Button>
						&nbsp;
						<asp:Button ID="cmdReset" Text="Reset" Runat="server" cssclass="NormalButton"></asp:Button>
					<br><br>
					
					
			<asp:datagrid id="dbgrid" runat="server" Width="600" OnItemCommand="dgCommand_onClick" PagerStyle-Mode="NumericPages"
				AllowPaging="True" dataKeyField="id" bordercolor="#B4B6C7" borderwidth="0px" gridlines="Horizontal"
				ShowHeader="true" AutoGenerateColumns="False" OnItemDataBound="dbgrid_OnItemDataBound" OnPageIndexChanged="dbgrid_SelectedIndexChanged">
			<HeaderStyle cssclass="titles" />
	<PagerStyle CssClass="DataGrid_PagerStyle" />
	<AlternatingItemStyle CssClass="odd" />
	<ItemStyle CssClass="even" />
				<Columns>
					<asp:TemplateColumn ItemStyle-Width="20">
						<ItemTemplate>
							&nbsp; &nbsp;
						</ItemTemplate>
						<FooterTemplate>
							&nbsp; &nbsp;
						</FooterTemplate>
					</asp:TemplateColumn>
					
					<asp:TemplateColumn ItemStyle-Width="100" >
						<ItemTemplate>
							<asp:Image BorderWidth=0 Runat=server ImageUrl="~/common/images/page.gif" ID="Image1" NAME="Image1"></asp:Image>
							
						</ItemTemplate>
				
					</asp:TemplateColumn>
					
					
					<asp:TemplateColumn ItemStyle-Width="50" HeaderText="Page Id">
						<ItemTemplate>
								<asp:label ID="lbl" text='<%# DataBinder.Eval(Container.DataItem, "id") %>' CssClass="normal" Runat=server />
						</ItemTemplate>
				
					</asp:TemplateColumn>
					
					<asp:TemplateColumn ItemStyle-Width="250" HeaderText="Page Name">
						<ItemTemplate>
						&nbsp; 
							<asp:linkbutton ID="lblPageName" text='<%# DataBinder.Eval(Container.DataItem, "pageName") %>' CommandName=cmdEdit Font-Underline=True CssClass="normal" Width=260 Runat=server />
						</ItemTemplate>
				
					</asp:TemplateColumn>
					
					
					<asp:TemplateColumn ItemStyle-Width=300>
						<ItemTemplate>
						&nbsp;
							<asp:hyperlink ID="Linkbutton27" text="Edit Page" NavigateUrl='<%# "~/default.aspx?pageId=20&id=" + DataBinder.Eval(Container.DataItem, "id") %>' CommandName=cmdEdit Font-Underline=True CssClass="normal" Runat=server />
						&nbsp; &nbsp; &nbsp;
							<asp:LinkButton CommandName=cmdModules Runat=server Font-Underline=True text="Modules" ID="Linkbutton28"></asp:LinkButton>
					
						</ItemTemplate>
				
					</asp:TemplateColumn>
					
					
			
					
					
					
					
					<asp:TemplateColumn ItemStyle-Width="100">
						<ItemTemplate>
							
							<asp:ImageButton id="cmdDelete" AlternateText="Delete Item" commandName="cmdDelete" ImageUrl='<%# "~/common/images/delete.gif" %>' Runat="server" />
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			
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
					