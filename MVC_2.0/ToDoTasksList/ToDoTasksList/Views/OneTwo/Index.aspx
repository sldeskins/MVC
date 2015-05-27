<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ToDoTasksList.Models.Repository.OneTwo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                OneTwoID
            </th>
            <th>
                Description
            </th>
            <th>
                RankOrder
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.OneTwoID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.OneTwoID })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.OneTwoID })%>
            </td>
            <td>
                <%= Html.Encode(item.OneTwoID) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(item.RankOrder) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

