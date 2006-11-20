<%@ Page language="c#" Codebehind="webuploadform.aspx.cs" AutoEventWireup="false" Inherits="DefAppTestWeb.webuploadform" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>webuploadform</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<P>SuperZonline Dosya Yükleme Fasilitesi Cok Super</P>
			<P>
				<asp:Label id="Label1" runat="server" Width="312px"></asp:Label></P>
			<P><INPUT id="File1" type="file" name="File1" runat="server"></P>
			<P><INPUT type="submit" value="Save File">
			</P>
			<P>
				<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></P>
		</form>
	</body>
</HTML>
