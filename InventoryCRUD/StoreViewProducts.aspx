<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="StoreViewProducts.aspx.cs" Inherits="Enterprise_project_CRUD.ViewProducts" %>

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
    <div class="productcontainer">
        <div class="containertitle">
            Search Product:
            <asp:TextBox ID="tb_SearchProduct" runat="server"></asp:TextBox>
            <asp:Button ID="btn_Search" runat="server" OnClick="btn_Search_Click" Text="Search" />
            <br />
            Search Products By Category:
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource6" DataTextField="ProdCategory" DataValueField="ProdCategory" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <asp:Button ID="btn_Refresh" runat="server" OnClick="btn_Refresh_Click" Text="Refresh" />
            <br />
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT DISTINCT [ProdCategory] FROM [Product]"></asp:SqlDataSource>
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged" Style="margin-right: 0px" OnRowCancelingEdit="gvProducts_RowCancellingEdit" OnRowDeleting="gvProducts_RowDeleting" OnRowEditing="gvProducts_RowEditing" OnRowUpdating="gvProducts_RowUpdating" Width="486px" AllowPaging="True" OnPageIndexChanging="gvProducts_PageIndexChanging" PageSize="5" AllowSorting="True" DataSourceID="SqlDataSource3" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="ProdID" HeaderText="ProdID" InsertVisible="False" ReadOnly="True" SortExpression="ProdID" />
                        <asp:BoundField DataField="ProdName" HeaderText="ProdName" SortExpression="ProdName" />
                        <asp:BoundField DataField="ProdDescription" HeaderText="ProdDescription" ItemStyle-Width="300px" SortExpression="ProdDescription">
                            <ItemStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ProdPrice" DataFormatString="{0:c}" HeaderText="ProdPrice" SortExpression="ProdPrice" />
                        <asp:BoundField DataField="ProdCategory" HeaderText="ProdCategory" SortExpression="ProdCategory" />
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" + Eval("ProdImage") %>' Width="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PageButtonCount="4" PreviousPageText="Prev" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:Panel>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="gvSearchProduct" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" OnPageIndexChanging="gvSearchProduct_PageIndexChanging" OnSelectedIndexChanged="gvSearchProduct_SelectedIndexChanged" PageSize="5" CellSpacing="2" Width="885px">
                    <Columns>
                        <asp:BoundField DataField="ProdID" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProdName" HeaderText="Product Name" />
                        <asp:BoundField DataField="ProdDescription" HeaderText="Product Description" />
                        <asp:BoundField DataField="ProdPrice" DataFormatString="{0:c}" HeaderText="Product Price" />
                        <asp:BoundField DataField="ProdCategory" HeaderText="Category" />
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" + Eval("ProdImage") %>' Width="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="4" Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
                <asp:GridView ID="gvSearchCategory" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" OnPageIndexChanging="gvSearchCategory_PageIndexChanging" OnSelectedIndexChanged="gvSearchCategory_SelectedIndexChanged" PageSize="5" CellSpacing="2">
                    <Columns>
                        <asp:BoundField DataField="ProdID" HeaderText="ProdID" InsertVisible="False" ReadOnly="True" SortExpression="ProdID" />
                        <asp:BoundField DataField="ProdName" HeaderText="ProdName" SortExpression="ProdName" />
                        <asp:BoundField DataField="ProdDescription" HeaderText="ProdDescription" SortExpression="ProdDescription" />
                        <asp:BoundField DataField="ProdPrice" DataFormatString="{0:c}" HeaderText="ProdPrice" SortExpression="ProdPrice" />
                        <asp:BoundField DataField="ProdCategory" HeaderText="ProdCategory" SortExpression="ProdCategory" />
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Width="100px" ImageUrl='<%# "~/Images/" + Eval("ProdImage") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="4" Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </asp:Panel>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:AzureDBConnString %>" SelectCommand="SELECT * FROM [Product] WHERE ([ProdCategory] = @ProdCategory)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList3" Name="ProdCategory" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </div>
</asp:Content>