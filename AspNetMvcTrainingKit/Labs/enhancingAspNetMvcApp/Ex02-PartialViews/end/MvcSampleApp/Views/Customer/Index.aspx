<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.ViewData.CustomerViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Customers</h2>
    <% using (Ajax.BeginForm("FilterCustomers", new AjaxOptions() { UpdateTargetId = "divCustomerList" }))
       { %>
            <label for="customersFilter">
                Search:</label>
            <%= Html.TextBox("customersFilter") %>
            <input type="submit" value="Go" />
    <% } %>
    
    <div id="divCustomerList">
        <% Html.RenderPartial("CustomerList", Model); %>
    </div>
</asp:Content>