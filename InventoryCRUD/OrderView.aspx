<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeSite.Master" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="SmartStore.OrderView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ======= Breadcrumbs ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <ol>
                <li><a href="~/">Home</a></li>
                <li>View Orders</li>
            </ol>
            <h2>View Orders</h2>
        </div>
    </section>
    <!-- End Breadcrumbs -->
    <asp:Label ID="lblSearch" runat="server" Text="Search:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Product" DataValueField="Product" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT [Product] FROM [Orders]"></asp:SqlDataSource>
    <asp:Button ID="btnSearch" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />

    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gvOrder" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" OnRowCommand="gvOrder_RowCommand" Width="506px" DataKeyNames="OrderID" OnRowDeleting="gvOrder_RowDeleting" GridLines="None" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
                <asp:ButtonField CommandName="Select" Text="Select" />
                <asp:ButtonField CommandName="Update" Text="Update" />
                <asp:CommandField ShowDeleteButton="True" />
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
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" OnRowCommand="gvOrder_RowCommand" Width="506px" DataKeyNames="OrderID" OnRowDeleting="gvOrder_RowDeleting" GridLines="None" DataSourceID="SqlDataSource3">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
                <asp:ButtonField CommandName="Select" Text="Select" />
                <asp:ButtonField CommandName="Update" Text="Update" />
                <asp:CommandField ShowDeleteButton="True" />
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
    </asp:Panel>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT * FROM [Orders] WHERE ([Product] = @Product)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="Product" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>
</asp:Content>