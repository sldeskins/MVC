<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.ViewData.CustomerViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Customers</h2>
    <ul>
        <% foreach (var customer in ViewData.Model.Customers)
           { %>
        <li>
            <%= Html.ActionLink(customer.CompanyName + " - " + customer.FirstName 
       + " " + customer.LastName, "Info", new { id = customer.CustomerID }) %>
        </li>
        <% } %>
    </ul>
    <%=Html.ActionLink("<< Previous Page", "Index", new { page = ViewData.Model.PreviousPage }) %>&nbsp;&nbsp;&nbsp;&nbsp
    <%=Html.ActionLink("Next Page >>", "Index", new { page = ViewData.Model.NextPage }) %>
</asp:Content>
