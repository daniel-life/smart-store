<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="OrderUpdate.aspx.cs" Inherits="SmartStore.OrderUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Order Update</li>
            </ol>
            <h2>Order Update</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <h1>UPDATE ORDER DATA</h1>
    <table>
        <tr>
            <td>Order ID:</td>
            <td>
                <asp:TextBox ID="tbOrderID" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">Product ID:</td>
            <td style="height: 20px">
                <asp:TextBox ID="tbProductID" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Product:</td>
            <td>
                <asp:DropDownList ID="ddlProduct" runat="server" Height="25px" Width="200px" DataSourceID="SqlDataSource1" DataTextField="prodName" DataValueField="prodName">
                    <asp:ListItem Selected="True">1001 - Apple</asp:ListItem>
                    <asp:ListItem>1002 - Orange</asp:ListItem>
                    <asp:ListItem>1003 - Grape</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT DISTINCT [prodName] FROM [Inventory]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Quantity:</td>
            <td>
                <asp:TextBox ID="tbQuantity" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Supplier:</td>
            <td>
                <asp:DropDownList ID="ddlSupplier" runat="server" Height="25px" Width="200px">
                    <asp:ListItem Selected="True">123 Privated Limited</asp:ListItem>
                    <asp:ListItem>HCK Private Limited</asp:ListItem>
                    <asp:ListItem>MCD Private Limited</asp:ListItem>
                    <asp:ListItem>CHL Private Limited</asp:ListItem>
                    <asp:ListItem>LIL Private Limited</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Urgency:</td>
            <td>
                <asp:RadioButtonList ID="rblUrgency" runat="server">
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
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" BackColor="Lime" />
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" BackColor="Red" />
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" BackColor="#999999" />
                <asp:Button ID="btnArrived" runat="server" BackColor="#66CCFF" OnClick="btnArrived_Click" Text="Arrived" />
            </td>
        </tr>
    </table>
</asp:Content>