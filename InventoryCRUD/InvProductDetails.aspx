<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="InvProductDetails.aspx.cs" Inherits="InventoryCRUD.ProductDetails" %>

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
    <h1>PRODUCT DETAILS</h1>
    <table style="width: 100%;">
        <tr>
            <td style="height: 50px; width: 176; font-size: small;">Product ID:</td>
            <td style="height: 20px">
                <asp:Label ID="lbProdID" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Product Name:</td>
            <td>
                <asp:Label ID="lbProdName" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Description:</td>
            <td>
                <asp:Label ID="lbDescription" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Price:</td>
            <td style="height: 20px">
                <asp:Label ID="lbPrice" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">RFID Tag:</td>
            <td>
                <asp:Label ID="lbRFIDTag" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Quantity:</td>
            <td>
                <asp:Label ID="lbQuantity" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Threshold:</td>
            <td>
                <asp:Label ID="lbThreshold" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176px">
                <asp:Label ID="lbMessage" runat="server" Height="25px"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 176px">&nbsp;</td>
            <td>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" Height="30px" Width="80px" />
            </td>
        </tr>
    </table>
</asp:Content>