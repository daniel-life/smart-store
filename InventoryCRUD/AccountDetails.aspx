<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDetails.aspx.cs" Inherits="AccountCRUD.AccountDetails" %>

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
    <h1>VIEW ACCOUNT DETAILS</h1>
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
                <asp:TextBox ID="tbName" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Password:</td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Email</td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Address</td>
            <td>
                <asp:TextBox ID="tbAddress" runat="server" Width="400px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <% if (((string)Session["Auth"] == "Admin") ^ ((string)Session["Auth"] == "Customer") ^ ((string)Session["Auth"] == "Employee"))
            { %>
        <tr>
            <td style="width: 165px; height: 20px">
                <asp:Label ID="lbMessage" runat="server"></asp:Label>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 165px">&nbsp;</td>
            <td style="margin-left: 40px">
                <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Back" />
                <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update" />
            </td>
        </tr>
        <% }
        else
        { %>
        <tr>
            <td style="width: 165px">&nbsp;</td>
            <td style="margin-left: 40px">
                <asp:Button ID="login" runat="server" OnClick="btn_login" Text="Login" />
            </td>
        </tr>

        <% } %>
    </table>
</asp:Content>