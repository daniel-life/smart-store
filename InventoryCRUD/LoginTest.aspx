<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginTest.aspx.cs" Inherits="InventoryCRUD.LoginTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Login</li>
            </ol>
            <h2>Login</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <h1>LOGIN</h1>
    <table style="width: 100%;">
        <tr>
            <td style="width: 165px">Account ID:</td>
            <td>
                <asp:TextBox ID="tbAccountID" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">Password:</td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" Width="400px"></asp:TextBox>
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
                <asp:Button ID="Forget" runat="server" OnClick="Forget_Click" Text="Forget Password" />
            </td>
        </tr>
    </table>
</asp:Content>