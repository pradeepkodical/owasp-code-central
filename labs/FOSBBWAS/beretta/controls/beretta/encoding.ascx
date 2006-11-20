<%@ Control Language="c#" AutoEventWireup="false" Codebehind="encoding.ascx.cs" Inherits="beretta.Web.encoding" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<h1>Encoding </h1>


						<br>
						<span class="normal">Text to encode:</span><br>
						<br>
						<asp:TextBox ID="txtTextToEncode" TextMode="MultiLine" Rows="5" Width="600" CssClass="normaltextbox"
							Runat="server"></asp:TextBox>
						<br>
						<br>
						<span class="normal">Encoding Type:</span>
						<asp:DropDownList ID="dropDownEncodingType" Width="300" Runat="server">
							<asp:ListItem Value="0" Selected="True">--</asp:ListItem>
							<asp:ListItem Value="1">Url Encode</asp:ListItem>
							<asp:ListItem Value="2">Html Encode</asp:ListItem>
							<asp:ListItem Value="3">Hex</asp:ListItem>
							<asp:ListItem Value="4">Hex HTML</asp:ListItem>
							<asp:ListItem Value="5">Decimal</asp:ListItem>
							<asp:ListItem Value="6">Viewstate Deserialize</asp:ListItem>
							<asp:ListItem Value="7">Viewstate Serialize</asp:ListItem>
							
						</asp:DropDownList>
						<br>
						<br>
						<asp:Button ID="cmdGet" Text="Convert" Runat="server"></asp:Button>
						<br>
						<br>
						<asp:TextBox ID="txtResults" TextMode="MultiLine" Rows="5" Width="600" CssClass="normaltextbox"
							Runat="server"></asp:TextBox>
						<br>
						<br>
						</FORM>

<br>
<br>
