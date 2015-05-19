<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="ProductNumber">ProductNumber:</label>
                <%= Html.TextBox("ProductNumber", Model.ProductNumber) %>
                <%= Html.ValidationMessage("ProductNumber", "*") %>
            </p>
            <p>
                <label for="Color">Color:</label>
                <%= Html.TextBox("Color", Model.Color) %>
                <%= Html.ValidationMessage("Color", "*") %>
            </p>
            <p>
                <label for="StandardCost">StandardCost:</label>
                <%= Html.TextBox("StandardCost", String.Format("{0:F}", Model.StandardCost)) %>
                <%= Html.ValidationMessage("StandardCost", "*") %>
            </p>
            <p>
                <label for="ListPrice">ListPrice:</label>
                <%= Html.TextBox("ListPrice", String.Format("{0:F}", Model.ListPrice)) %>
                <%= Html.ValidationMessage("ListPrice", "*") %>
            </p>
            <p>
                <label for="Size">Size:</label>
                <%= Html.TextBox("Size", Model.Size) %>
                <%= Html.ValidationMessage("Size", "*") %>
            </p>
            <p>
                <label for="Weight">Weight:</label>
                <%= Html.TextBox("Weight", String.Format("{0:F}", Model.Weight)) %>
                <%= Html.ValidationMessage("Weight", "*") %>
            </p>
            <p>
                <label for="ProductCategoryID">ProductCategoryID:</label>
                <%= Html.TextBox("ProductCategoryID", Model.ProductCategoryID) %>
                <%= Html.ValidationMessage("ProductCategoryID", "*") %>
            </p>
            <p>
                <label for="ProductModelID">ProductModelID:</label>
                <%= Html.TextBox("ProductModelID", Model.ProductModelID) %>
                <%= Html.ValidationMessage("ProductModelID", "*") %>
            </p>
            <p>
                <label for="SellStartDate">SellStartDate:</label>
                <%= Html.TextBox("SellStartDate", String.Format("{0:g}", Model.SellStartDate)) %>
                <%= Html.ValidationMessage("SellStartDate", "*") %>
            </p>
            <p>
                <label for="SellEndDate">SellEndDate:</label>
                <%= Html.TextBox("SellEndDate", String.Format("{0:g}", Model.SellEndDate)) %>
                <%= Html.ValidationMessage("SellEndDate", "*") %>
            </p>
            <p>
                <label for="DiscontinuedDate">DiscontinuedDate:</label>
                <%= Html.TextBox("DiscontinuedDate", String.Format("{0:g}", Model.DiscontinuedDate)) %>
                <%= Html.ValidationMessage("DiscontinuedDate", "*") %>
            </p>
            <p>
                <label for="ThumbnailPhotoFileName">ThumbnailPhotoFileName:</label>
                <%= Html.TextBox("ThumbnailPhotoFileName", Model.ThumbnailPhotoFileName) %>
                <%= Html.ValidationMessage("ThumbnailPhotoFileName", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

