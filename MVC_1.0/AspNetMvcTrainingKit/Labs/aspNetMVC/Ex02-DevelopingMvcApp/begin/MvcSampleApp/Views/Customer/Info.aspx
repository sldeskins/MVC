<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Info
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Customer Information</h2>
    <fieldset>
        <p>
            CompanyName:
            <%= Html.Encode(Model.CompanyName) %>
        </p>
        <p>
            EmailAddress:
            <%= Html.Encode(Model.EmailAddress) %>
        </p>
        <p>
            Name:
            <%= Html.Encode(Model.Title + " " + Model.FirstName + " " + Model.MiddleName + Model.LastName) %>
        </p>
        <p>
            Phone:
            <%= Html.Encode(Model.Phone) %>
        </p>
    </fieldset>
    <h3>
        Addresses</h3>
    <ul>
        <% foreach (var address in Model.CustomerAddress)
           { %>
        <li>
            <%= address.Address.AddressLine1 + " " + address.Address.AddressLine2 + " - " + address.Address.City %>
            <%=Html.ActionLink("(Edit)", "Edit", "Address", new { address.AddressID, Model.CustomerID }, null)%>
            <%=Html.ActionLink("(Delete)", "Delete", "Address", new { address.AddressID, Model.CustomerID }, null)%>
        </li>
        <% } %>
    </ul>
    <%=Html.ActionLink("Add New Address", "Create", "Address", new { Model.CustomerID }, null)%>
</asp:Content>
