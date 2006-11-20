<%@ Page language="c#" Codebehind="ControllerBase.aspx.cs" AutoEventWireup="false" Inherits="mvc2.ControllerBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>WebForm1</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body id=body runat="server">
  
    <div align="center">
      <a href="?page=Page1&amp;action=View">Page1.View()</a> | 
      <a href="?page=Page1&amp;action=View&amp;x=5&amp;y=3">Page1.View(5,3)</a> | 
      <a href="?page=Page2&amp;action=Multiply&amp;x=5&amp;y=3">Page2.Multiply(5,3)</a>
    </div>
  
    <div style="border: black 2px solid; margin: 10px; padding 10px;">
      <asp:Xml id=xmlBody runat="server"></asp:Xml>
    </div>
    
    <div id=errors runat="server" style="border: red 2px solid; margin: 10px; padding 10px;">
    </div>
    
  </body>
</HTML>
