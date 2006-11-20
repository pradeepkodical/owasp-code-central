<%@ Control Language="c#" AutoEventWireup="false" Codebehind="displayFormSubmission.ascx.cs" Inherits="beretta.Web.displayFormSubmission" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<br>
<span class="adminTitle">Form Submission Results </span>
<br>
<br>


						<span class="normal">URL:</span>
						<br>
						<asp:HyperLink ID="hyperUrl" Target=_blank CssClass=normal Width="700" Runat="server"></asp:HyperLink>
						<br>
						<br>
						<span class="normal">Raw Form Submission Data (Use this for Payloads and logons):</span>
						<br>
						<asp:TextBox ID="txtFormResults" Rows="5" TextMode="MultiLine" Width="700" Runat="server"></asp:TextBox>
						<br>
						<br>
						<span class="normal">Form Submission Data (Url decoded):</span>
						<br>
						<asp:TextBox ID="txtFormResultsUnEncoded" Rows="5" TextMode="MultiLine" Width="700" Runat="server"></asp:TextBox>
						<br>
						<br>
						<asp:HyperLink ID="hyperBack" Runat="server" CssClass="normal" text="Back To Select Page" NavigateUrl="~/default.aspx?pageId=47"></asp:HyperLink>
				