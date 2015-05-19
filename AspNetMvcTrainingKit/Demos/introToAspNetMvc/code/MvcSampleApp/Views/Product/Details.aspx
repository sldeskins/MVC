<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcSampleApp.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            ProductID:
            <%= Html.Encode(Model.ProductID) %>
        </p>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            ProductNumber:
            <%= Html.Encode(Model.ProductNumber) %>
        </p>
        <p>
            Color:
            <%= Html.Encode(Model.Color) %>
        </p>
        <p>
            StandardCost:
            <%= Html.Encode(String.Format("{0:F}", Model.StandardCost)) %>
        </p>
        <p>
            ListPrice:
            <%= Html.Encode(String.Format("{0:F}", Model.ListPrice)) %>
        </p>
        <p>
            Size:
            <%= Html.Encode(Model.Size) %>
        </p>
        <p>
            Weight:
            <%= Html.Encode(String.Format("{0:F}", Model.Weight)) %>
        </p>
        <p>
            ProductCategoryID:
            <%= Html.Encode(Model.ProductCategoryID) %>
        </p>
        <p>
            ProductModelID:
            <%= Html.Encode(Model.ProductModelID) %>
        </p>
        <p>
            SellStartDate:
            <%= Html.Encode(String.Format("{0:g}", Model.SellStartDate)) %>
        </p>
        <p>
            SellEndDate:
            <%= Html.Encode(String.Format("{0:g}", Model.SellEndDate)) %>
        </p>
        <p>
            DiscontinuedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.DiscontinuedDate)) %>
        </p>
        <p>
            ThumbnailPhotoFileName:
            <%= Html.Encode(Model.ThumbnailPhotoFileName) %>
        </p>
        <p>
            rowguid:
            <%= Html.Encode(Model.rowguid) %>
        </p>
        <p>
            ModifiedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ModifiedDate)) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.ProductID }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

