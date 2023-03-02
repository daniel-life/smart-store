<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="InventoryCRUD.ForgetPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
    <h1>INPUT ID</h1>
    <p>Use your ID to get sent a code to your gmail.</p>
    <p>&nbsp;</p>
    <table style="width: 100%;">
        <tr>
            <td style="width: 165px; height: 31px;">ID:</td>
            <td style="height: 31px">
                <asp:TextBox ID="tbID" runat="server" Width="400px"></asp:TextBox>
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
                <asp:Button ID="btnSubmitID" runat="server" OnClick="btnSubmit_Click" Text="Submit ID" />
            </td>
        </tr>
    </table>
</asp:Content>