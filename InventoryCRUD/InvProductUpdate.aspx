<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="InvProductUpdate.aspx.cs" Inherits="InventoryCRUD.ProductUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Update Product</li>
            </ol>
            <h2>Update Product</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <h1>UPDATE PRODUCT DETAILS</h1>
    <table style="width: 100%;">
        <tr>
            <td style="height: 50px; width: 176px; font-size: small;">Product ID:</td>
            <td style="height: 20px">
                <asp:Label ID="lbProdID" runat="server" Height="25px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 50px; font-size: small;">Product Name:</td>
            <td>
                <asp:TextBox ID="tbProdName" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 50px; font-size: small;">Description:</td>
            <td>
                <asp:TextBox ID="tbDescription" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 50px; font-size: small;">Price:</td>
            <td>
                <asp:TextBox ID="tbPrice" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 50px; font-size: small;">RFID Tag:</td>
            <td>
                <asp:TextBox ID="tbRFIDTag" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 50px; font-size: small;">Quantity:</td>
            <td>
                <asp:TextBox ID="tbQuantity" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176px; height: 50px; font-size: small;">Threshold:</td>
            <td>
                <asp:TextBox ID="tbThreshold" runat="server" Width="400px" Height="25px"></asp:TextBox>
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
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Height="30px" Width="80px" />
                <asp:Button ID="btnBack" runat="server" OnClick="btnClear_Click" Text="Back" Height="30px" Width="80px" />
            </td>
        </tr>
    </table>
</asp:Content>