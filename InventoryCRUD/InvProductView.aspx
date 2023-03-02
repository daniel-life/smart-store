<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="InvProductView.aspx.cs" Inherits="InventoryCRUD.ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>View Products</li>
            </ol>
            <h2>View Products</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <div>
        Search Product:
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="prodName" DataValueField="prodName" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="Button1_Click" />
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProduct_RowCommand" DataKeyNames="prodID" OnRowDeleting="gvProduct_RowDeleting" Font-Size="Medium" Height="120px" Width="874px" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" OnRowDataBound="gvProduct_RowDataBound" AllowPaging="True" PageSize="6" OnPageIndexChanging="gvProduct_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="prodID" HeaderText="prodID" ReadOnly="True" SortExpression="prodID" />
                <asp:BoundField DataField="prodName" HeaderText="prodName" SortExpression="prodName" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                <asp:ButtonField CommandName="Select" Text="Select" />
                <asp:ButtonField CommandName="Update" Text="Update" />
                <asp:ButtonField CommandName="Delete" Text="Delete" />
                <asp:ButtonField CommandName="Order" Text="Order" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT * FROM [Inventory]"></asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:GridView ID="gvProduct2" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProduct_RowCommand" DataKeyNames="prodID" OnRowDeleting="gvProduct_RowDeleting" Font-Size="Medium" Height="120px" Width="874px" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" OnRowDataBound="gvProduct_RowDataBound" AllowPaging="True" PageSize="6" OnPageIndexChanging="gvProduct_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="prodID" HeaderText="prodID" ReadOnly="True" SortExpression="prodID" />
                <asp:BoundField DataField="prodName" HeaderText="prodName" SortExpression="prodName" />
                <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                <asp:ButtonField CommandName="Select" Text="Select" />
                <asp:ButtonField CommandName="Update" Text="Update" />
                <asp:ButtonField CommandName="Delete" Text="Delete" />
                <asp:ButtonField CommandName="Order" Text="Order" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT * FROM [Inventory] WHERE ([prodName] = @prodName)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="prodName" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>