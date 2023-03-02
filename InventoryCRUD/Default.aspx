<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventoryCRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Home</li>
            </ol>
            <h2>Welcome</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <div class="jumbotron">
        <h1>Welcome to our Grocery Store! <%:Session["Name"]%></h1>
        <div class="jumbotron">
            <h1>ID: <%:Session["ID"]%></h1>
            <h1><%:Session["Auth"]%></h1>
            <p>
                <asp:Button ID="Logout" runat="server" OnClick="Logout_Click" Text="Log out" />
            </p>
            <p class="lead">We sell a wide range of daily essential products, such as fruits & vegetables, dairy, and baby products.</p>
        </div>
</asp:Content>