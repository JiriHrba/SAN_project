<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActionSummary.aspx.cs" Inherits="Knihovna_SAN.Action.ActionSummary" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Prehled akci</h1>
<hr>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" 
        DataSourceID="ActionObjectDataSource1" ForeColor="#333333" 
        GridLines="None" DataKeyNames="action_id" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField SelectText="Rezervace" ShowSelectButton="True" />
            <asp:BoundField DataField="action_date" HeaderText="Datum konani" 
                SortExpression="action_date" />
            <asp:BoundField DataField="action_capacity" HeaderText="Kapacita" 
                SortExpression="action_capacity" />
            <asp:BoundField DataField="action_name" HeaderText="Nazev" 
                SortExpression="action_name" />
            <asp:BoundField DataField="action_cost" HeaderText="Cena" 
                SortExpression="action_cost" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>



    <asp:ObjectDataSource ID="ActionObjectDataSource1" runat="server" 
        DataObjectTypeName="DatabaseLibrary.Action" DeleteMethod="Delete" 
        InsertMethod="Insert" SelectMethod="SelectAll" 
        TypeName="DatabaseLibrary.ActionTable" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
