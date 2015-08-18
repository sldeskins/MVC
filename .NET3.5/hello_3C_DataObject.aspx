<%@ Page Language="C#" Debug="true" %>

<html xmlns="http://www.w3.org/1998/xhtml">
<head><title>Simple page</title></head>
<body>
<form  runat="server">
<h1>Hello ASP.NET!</h1>
<h3>I was loaded from 
	<%= GetType().Assembly.Location %>
</h3>

<asp:BulletedList runat="server" ID="_displayList" DataSourceId = "_itemsDataSource">
	<asp:ListItem>Sample Item 1</asp:ListItem>
	<asp:ListItem>Sample Item 2</asp:ListItem>
	<asp:ListItem>Sample Item 3</asp:ListItem>
</asp:BulletedList>

<asp:ObjectDataSource runat="server" ID="_itemsDataSource" TypeName="PS.AspDotNet.MyDataSource" SelectMethod="GetItems" /> 

<% Response.Write("<h2>Total number of items = " + PS.AspDotNet.MyDataSource.ItemCount.ToString() + "</h2>");%>
</form> 
</body>
</html>