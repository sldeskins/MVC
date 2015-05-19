<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.ViewData.ProductViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
                Product Name
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model.Products)
           { %>
        <tr>
            <td>
                <%= item.Name %>
            </td>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.ProductID}) %>
                |
                <%= Html.ActionLink("Details", "Details", new { id=item.ProductID})%>
            </td>
        </tr>
        <% } %>
        <tr>
            <td>
                <%= Html.ActionLink("<< Previous Page","Index",new { page = Model.PreviousPage }) %>
            </td>
            <td>
                <%= Html.ActionLink("Next Page >>","Index",new { page = Model.NextPage }) %>
            </td>
        </tr>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>
