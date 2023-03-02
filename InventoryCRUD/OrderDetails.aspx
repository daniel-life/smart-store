<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="SmartStore.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Order Details</li>
            </ol>
            <h2>Order Details</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <h1>ORDER DETAILS</h1>
    <table>
        <tr>
            <td>Order ID:</td>
            <td>
                <asp:TextBox ID="tbOrderID" runat="server" Width="400px" Enabled="False" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Product ID:</td>
            <td>
                <asp:TextBox ID="tbProductID" runat="server" Width="400px" Enabled="False" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Product:</td>
            <td>
                <asp:TextBox ID="tbProduct" runat="server" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Quantity:</td>
            <td>
                <asp:TextBox ID="tbQuantity" runat="server" Width="200px" Enabled="False" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Supplier:</td>
            <td>
                <asp:TextBox ID="tbSupplier" runat="server" Width="280px" Enabled="False" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Urgency:</td>
            <td>
                <asp:RadioButtonList ID="rblUrgency" runat="server" Enabled="False">
                    <asp:ListItem Selected="True" Value="U">Urgent</asp:ListItem>
                    <asp:ListItem Value="NU">Not Urgent</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbMessage" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" Style="height: 26px" BackColor="#999999" />
            </td>
        </tr>
    </table>
</asp:Content>