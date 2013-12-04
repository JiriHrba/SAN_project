<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientAdministration.aspx.cs" Inherits="Knihovna_SAN.Client.ClientAdministration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="objectClientDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="client_id" HeaderText="client_id" 
                SortExpression="client_id" />
            <asp:BoundField DataField="client_name" HeaderText="client_name" 
                SortExpression="client_name" />
            <asp:BoundField DataField="client_surname" HeaderText="client_surname" 
                SortExpression="client_surname" />
            <asp:BoundField DataField="client_email" HeaderText="client_email" 
                SortExpression="client_email" />
            <asp:BoundField DataField="client_phone" HeaderText="client_phone" 
                SortExpression="client_phone" />
            <asp:BoundField DataField="client_birth_date" HeaderText="client_birth_date" 
                SortExpression="client_birth_date" />
            <asp:BoundField DataField="client_member_from" HeaderText="client_member_from" 
                SortExpression="client_member_from" />
            <asp:BoundField DataField="client_member_to" HeaderText="client_member_to" 
                SortExpression="client_member_to" />
            <asp:BoundField DataField="client_street" HeaderText="client_street" 
                SortExpression="client_street" />
            <asp:BoundField DataField="client_city" HeaderText="client_city" 
                SortExpression="client_city" />
            <asp:BoundField DataField="client_zip" HeaderText="client_zip" 
                SortExpression="client_zip" />
            <asp:BoundField DataField="client_country" HeaderText="client_country" 
                SortExpression="client_country" />
            <asp:CheckBoxField DataField="client_isEmp" HeaderText="client_isEmp" 
                SortExpression="client_isEmp" />
            <asp:CheckBoxField DataField="client_is_active" HeaderText="client_is_active" 
                SortExpression="client_is_active" />
            <asp:BoundField DataField="client_login" HeaderText="client_login" 
                SortExpression="client_login" />
            <asp:BoundField DataField="client_pass_hash" HeaderText="client_pass_hash" 
                SortExpression="client_pass_hash" />
            <asp:BoundField DataField="client_last_act" HeaderText="client_last_act" 
                SortExpression="client_last_act" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="objectClientDataSource1" runat="server" 
        DataObjectTypeName="DatabaseLibrary.Client" DeleteMethod="Delete" 
        InsertMethod="Insert" SelectMethod="SelectAll" 
        TypeName="DatabaseLibrary.ClientTable" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="clientId" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
