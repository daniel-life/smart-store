<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="Enterprise_project_CRUD.ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>Your Shopping Cart</li>
            </ol>
            <h2>Your shopping Cart</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <div class="productcontainer">
        <div class="containertitle">
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" DataKeyNames="ProdID" OnRowCommand="gvCartView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ProdID" HeaderText="Product ID" />
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="80px" ImageUrl='<%# "~/Images/" + Eval("ProdImage") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProdName" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                            <br />
                            <asp:LinkButton ID="btn_Remove" runat="server" CommandArgument='<%# Eval("ProdID") %>' CommandName="Remove">Remove</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProdPrice" DataFormatString="{0:c}" HeaderText="Unit Price" />
                    <asp:BoundField DataField="TotalPrice" DataFormatString="{0:c}" HeaderText="Item Price" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Total Price:
     <asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btn_Purchase" runat="server" Text="Purchase" OnClick="btn_Purchase_Click" />
    <br />
    <br />
    <asp:Label ID="lbl_Error" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btn_UpdateCart" runat="server" OnClick="btn_UpdateCart_Click" Text="Update Cart" />
    <asp:Button ID="btn_ClearCart" runat="server" OnClick="btn_ClearCart_Click" Text="Clear Cart" />
    <asp:Button ID="btn_Back" runat="server" OnClick="btn_Back_Click" Text="Back" />
    <br />
</asp:Content>