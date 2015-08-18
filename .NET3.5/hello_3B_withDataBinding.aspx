<%@ Page Language="C#" Debug="true" %>
<script runat="server">
const int _itemCount=10;

string GetDisplayItem(int n){
	return "Item #" + n.ToString();
}

string[] _displayItemData = {
"Item #1", 
"Item #2",
"Item #3",
"Item #4",
"Item #5",
"Item #6",
"Item #7",
"Item #8"};

protected override void OnLoad(EventArgs e){
	  _displayList.DataSource = _displayItemData ;
	  _displayList.DataBind();
	base.OnLoad(e);
}
</script>

<html xmlns="http://www.w3.org/1998/xhtml">
<head><title>Simple page</title></head>
<body>
<form  runat="server">
<h1>Hello ASP.NET!</h1>
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