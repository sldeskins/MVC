<%@ Page Language="C#" Debug="true" inherits="PS.HelloCbBase6"
CodeFile="hello_6.aspx.cs" 
AutoEventWireUp="true"%>
 
<html xmlns="http://www.w3.org/1998/xhtml">
<head><title>Simple page</title></head>
<body>
<form  runat="server">
<h1>Hello ASP.NET!</h1>
<h2>Control event wireup</h2>
<h3>I was loaded from 
	<%= GetType().Assembly.Location %>
</h3>

<asp:BulletedList runat="server" ID="_displayList">
	<asp:ListItem>Sample Item 1</asp:ListItem>
	<asp:ListItem>Sample Item 2</asp:ListItem>
	<asp:ListItem>Sample Item 3</asp:ListItem>
</asp:BulletedList>
 
<% Response.Write("<h2>Total number of items = "+_itemCount.ToString()+"</h2>");%>

<asp:Button ID="_clickMeButton" runat="server" Text="Click me!" 
onClick="_clickMeButton_Click"/>

<asp:Label runat="server" ID ="_msgLabel" />

</form> 
</body>
</html>