<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CodeInput.aspx.cs" Inherits="InventoryCRUD.CodeInput" %>

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
    <h1>INPUT CODE</h1>
    <p>A code has been sent to your gmail account. Input the code below to view account information.</p>
    <p>&nbsp;</p>
    <table style="width: 100%;">
        <tr>
            <td style="width: 165px; height: 31px;">Code:</td>
            <td style="height: 31px">
                <asp:TextBox ID="tbCode" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 165px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmitCode" runat="server" OnClick="btnSubmit_Click" Text="Submit Code" />
            </td>
        </tr>
    </table>
</asp:Content>