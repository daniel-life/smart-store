<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="InventoryCRUD.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Home</li>
            </ol>
            <h2>Welcome</h2>
        </div>
    </section>
    <div class="jumbotron">
        <h1>Welcome <%:Session["Name"]%> to our Grocery Store!</h1>
        <h1>ID: <%:Session["ID"]%></h1>
        <h1><%:Session["Auth"]%></h1>
        <p>
            <asp:Button ID="Logout" runat="server" OnClick="Logout_Click" Text="Log out" />
        </p>
        <p class="lead">We sell a wide range of daily essential products, such as fruits & vegetables, dairy, and baby products.</p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>