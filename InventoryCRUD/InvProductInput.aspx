<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="InvProductInput.aspx.cs" Inherits="InventoryCRUD.ProductInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Add Products</li>
            </ol>
            <h2>Add Products</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <h1>INPUT PRODUCT DETAILS</h1>
    <table style="width: 100%;">
        <tr>
            <td style="height: 50px; width: 176; font-size: small;">Product Name:</td>
            <td style="height: 20px">
                <asp:TextBox ID="tbProdName" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Product ID:</td>
            <td>
                <asp:TextBox ID="tbProdID" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Description:</td>
            <td>
                <asp:TextBox ID="tbDescription" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Price:</td>
            <td>
                <asp:TextBox ID="tbPrice" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">RFID Tag:</td>
            <td>
                <asp:TextBox ID="tbRFIDTag" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Quantity:</td>
            <td style="height: 20px">
                <asp:TextBox ID="tbQuantity" runat="server" Width="400px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176; height: 50px; font-size: small;">Threshold:</td>
            <td style="height: 20px">
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
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Height="30px" Width="80px" />
            </td>
        </tr>
    </table>
</asp:Content>