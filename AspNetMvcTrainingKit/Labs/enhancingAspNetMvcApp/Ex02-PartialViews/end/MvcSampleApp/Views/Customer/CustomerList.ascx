<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcSampleApp.ViewData.CustomerViewData>" %>
<div id="divCustomers">
    <ul>
        <% foreach (var customer in Model.Customers)
           { %>
            <li>
                <%= Html.ActionLink(customer.CompanyName + " - " + customer.FirstName + " " + customer.LastName, "Info", new { id = customer.CustomerID }) %>
            </li>
        <% } %>
    </ul>

    <%=Ajax.ActionLink("<< Previous Page", "ChangeCustomersPage", new { currentPage = Model.PreviousPage, customersFilter = Model.CustomerFilter }, new AjaxOptions() { UpdateTargetId = "divCustomers" })%> &nbsp;&nbsp;&nbsp;&nbsp
    <%=Ajax.ActionLink("Next Page >>", "ChangeCustomersPage", new { currentPage = Model.NextPage, customersFilter = Model.CustomerFilter }, new AjaxOptions() { UpdateTargetId = "divCustomers" })%>
</div>

