<%@ Page Language="C#" Debug="true" inherits="PS.HelloCbBaseV2"
CodeFile="hello_4V2.aspx.cs" %>
 
<html xmlns="http://www.w3.org/1998/xhtml">
<head><title>Simple page</title></head>
<body>
<form  runat="server">
<h1>Hello ASP.NET!</h1>
<h2>2.0 code behind version</h2>
<h3>I was loaded from 
	<%= GetType().Assembly.Location %>
</h3>

<asp:BulletedList runat="server" ID="_displayList">
	<asp:ListItem>Sample Item 1</asp:ListItem>
	<asp:ListItem>Sample Item 2</asp:ListItem>
	<asp:ListItem>Sample Item 3</asp:ListItem>
</asp:BulletedList>
 
<% Response.Write("<h2>Total number of items = "+_itemCount.ToString()+"</h2>");%>
	</form> 
</body>
</html>