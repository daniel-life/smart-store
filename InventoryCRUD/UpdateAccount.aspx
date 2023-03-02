<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="UpdateAccount.aspx.cs" Inherits="AccountCRUD.UpdateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Our Products</li>
            </ol>
            <h2>Our Products</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <h1>UPDATE ACCOUNT DATA</h1>
    <table style="width: 100%;">
        <tr>
            <td style="width: 165px">Acount ID:</td>
            <td>
                <asp:TextBox ID="tbAccountID" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Name:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Password:</td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Email</td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Address</td>
            <td>
                <asp:TextBox ID="tbAddress" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px; height: 20px">
                <asp:Label ID="lbMessage" runat="server"></asp:Label>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 165px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
            </td>
        </tr>
    </table>
</asp:Content>