<%@ Page Title="ACP Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Categories.aspx.cs" Inherits="StichtiteForum.Admin.Categories" %>

<asp:Content ID="ContentAdminCategories" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Categories</h1>
    
    <asp:Label runat="server" ID="LabelPageSize" Text="Page size:" AssociatedControlID=""/>
    <asp:DropDownList ID="DropDownPageSize" runat="server" 
        OnSelectedIndexChanged="DropDownPageSize_SelectedIndexChanged" AutoPostBack="true" Width="70px">
        <asp:ListItem Value="5">5</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="15">15</asp:ListItem>
        <asp:ListItem Value="20">20</asp:ListItem>
        <asp:ListItem Value="25">25</asp:ListItem>
        <asp:ListItem Value="30">30</asp:ListItem>
    </asp:DropDownList>
    
    <asp:GridView runat="server" ID="GridViewCategories" AllowPaging="True" AllowSorting="True" PageSize="5" 
        ItemType="StichtiteForum.Models.Category" AutoGenerateColumns="False" DataKeyNames="CategoryId"
        SelectMethod="GridViewUsers_GetCategories"
        DeleteMethod="GridViewUsers_DeleteCategory">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title">
                <ItemStyle Width="1050"/>
            </asp:BoundField>
            <asp:HyperLinkField HeaderText="" Text="Edit" DataNavigateUrlFields="CategoryId" 
                DataNavigateUrlFormatString="EditCategory.aspx?categoryId={0}">
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:HyperLinkField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Delete" ID="LinkButtonDeleteCategory"
                        CommandName="Delete" CommandArgument="<%# Item.CategoryId %>"
                        OnClientClick="return confirm('Do you want to delete this category ?');" />
                </ItemTemplate>
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:TemplateField>
        </Columns>  
    </asp:GridView>
    
    <h3>New Category</h3>
    
    <asp:Label runat="server" ID="LabelCategoryTitle" Text="Title" AssociatedControlID="TextBoxCategoryTitle"/>
    <asp:TextBox runat="server" ID="TextBoxCategoryTitle"/>
    <br/>
    <asp:Button runat="server" ID="ButtonCreate" Text="Create" OnClick="ButtonCreate_OnClick" CssClass="btn btn-primary"/>

</asp:Content>
