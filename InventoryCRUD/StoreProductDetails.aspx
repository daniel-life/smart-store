<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="StoreProductDetails.aspx.cs" Inherits="Enterprise_project_CRUD.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Product Details</li>
            </ol>
            <h2>Product Details</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->

    <table class="nav-justified">
        <tr>
            <td rowspan="3" style="width: 15px">
                <asp:Image ID="imgProduct" runat="server" Height="97px" Width="100px" />
            </td>
            <td>
                <asp:Label ID="lblProdName" runat="server"></asp:Label>
                &nbsp;(<asp:Label ID="lblProdID" runat="server"></asp:Label>
                )<br />
                <asp:Label ID="lblProdCategory" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblProdDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
                <br />
                <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Back" />
                <asp:Button ID="btn_Add_To_Cart" runat="server" Text="Add to Cart" OnClick="btn_Add_To_Cart_Click" />
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>