<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ProductID">ProductID:</label>
                <%= Html.TextBox("ProductID") %>
                <%= Html.ValidationMessage("ProductID", "*") %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="ProductNumber">ProductNumber:</label>
                <%= Html.TextBox("ProductNumber") %>
                <%= Html.ValidationMessage("ProductNumber", "*") %>
            </p>
            <p>
                <label for="Color">Color:</label>
                <%= Html.TextBox("Color") %>
                <%= Html.ValidationMessage("Color", "*") %>
            </p>
            <p>
                <label for="StandardCost">StandardCost:</label>
                <%= Html.TextBox("StandardCost") %>
                <%= Html.ValidationMessage("StandardCost", "*") %>
            </p>
            <p>
                <label for="ListPrice">ListPrice:</label>
                <%= Html.TextBox("ListPrice") %>
                <%= Html.ValidationMessage("ListPrice", "*") %>
            </p>
            <p>
                <label for="Size">Size:</label>
                <%= Html.TextBox("Size") %>
                <%= Html.ValidationMessage("Size", "*") %>
            </p>
            <p>
                <label for="Weight">Weight:</label>
                <%= Html.TextBox("Weight") %>
                <%= Html.ValidationMessage("Weight", "*") %>
            </p>
            <p>
                <label for="ProductCategoryID">ProductCategoryID:</label>
                <%= Html.TextBox("ProductCategoryID") %>
                <%= Html.ValidationMessage("ProductCategoryID", "*") %>
            </p>
            <p>
                <label for="ProductModelID">ProductModelID:</label>
                <%= Html.TextBox("ProductModelID") %>
                <%= Html.ValidationMessage("ProductModelID", "*") %>
            </p>
            <p>
                <label for="SellStartDate">SellStartDate:</label>
                <%= Html.TextBox("SellStartDate") %>
                <%= Html.ValidationMessage("SellStartDate", "*") %>
            </p>
            <p>
                <label for="SellEndDate">SellEndDate:</label>
                <%= Html.TextBox("SellEndDate") %>
                <%= Html.ValidationMessage("SellEndDate", "*") %>
            </p>
            <p>
                <label for="DiscontinuedDate">DiscontinuedDate:</label>
                <%= Html.TextBox("DiscontinuedDate") %>
                <%= Html.ValidationMessage("DiscontinuedDate", "*") %>
            </p>
            <p>
                <label for="ThumbnailPhotoFileName">ThumbnailPhotoFileName:</label>
                <%= Html.TextBox("ThumbnailPhotoFileName") %>
                <%= Html.ValidationMessage("ThumbnailPhotoFileName", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

