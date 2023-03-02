<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ViewPastPurchases.aspx.cs" Inherits="Enterprise_project_CRUD.ViewPastPurchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Purchase History</li>
            </ol>
            <h2>Purchase History</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <div class="cartcontainer">
        <div class="containertitle">
            <asp:GridView ID="gvPurchases" AutoGenerateColumns="False" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Purchase Number">
                        <ItemTemplate>
                            <asp:Label ID="lblPurchaseNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TotalPrice" DataFormatString="{0:c}" HeaderText="Total Price" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="ProductPrice" DataFormatString="{0:c}" HeaderText="Product Price" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Back" />
</asp:Content>