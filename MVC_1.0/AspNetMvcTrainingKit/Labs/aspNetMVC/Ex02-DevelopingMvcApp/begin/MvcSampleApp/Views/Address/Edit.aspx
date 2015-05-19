<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.ViewData.AddressViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Editing:
        <%= Model.Address.AddressLine1 %></h2>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            <label for="AddressLine1">
                Address Line 1:</label>
            <%=Html.TextBox("Address.AddressLine1")%>
        </p>
        <p>
            <label for="AddressLine2">
                Address Line 2:</label>
            <%=Html.TextBox("Address.AddressLine2")%>
        </p>
        <p>
            <label for="City">
                City:</label>
            <%=Html.TextBox("Address.City")%>
        </p>
        <p>
            <label for="StateProvince">
                State/Province:</label>
            <%=Html.TextBox("Address.StateProvince")%>
        </p>
        <p>
            <label for="PostalCode">
                Postal Code:</label>
            <%=Html.TextBox("Address.PostalCode")%>
        </p>
        <p>
            <label for="CountryRegion">
                Country/Region:</label>
            <%=Html.TextBox("Address.CountryRegion")%>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
</asp:Content>
