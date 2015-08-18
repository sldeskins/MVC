<%@ Page Language="C#" Debug="true" %>
<script runat="server">
const int _itemCount=10;

string GetDisplayItem(int n){
	return "Item #" + n.ToString();
}
</script>

<html xmlns="http://www.w3.org/1998/xhtml">
<head><title>Simple page</title></head>
<body>
<h1>Hello ASP.NET!</h1>
<h3>I was loaded from 
	<%= GetType().Assembly.Location %>
</h3>

<ul>
	<%for (int i=0; i<_itemCount; i++) {%>
	<li><%= GetDisplayItem(i)%></li>
	<%}%>
</ul>
<% Response.Write("<h2>Total number of items = "+_itemCount.ToString()+"</h2>");%>
	 
</body>
</html>