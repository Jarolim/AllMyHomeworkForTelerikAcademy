<%@ Page Title="ACP Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Users.aspx.cs" Inherits="StichtiteForum.Admin.Users" %>

<asp:Content ID="ContentAdminUsers" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Users</h1>
    
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
    
    <asp:GridView runat="server" ID="GridViewUsers" AllowPaging="True" AllowSorting="True" PageSize="5" 
        ItemType="StichtiteForum.Models.UserModel" AutoGenerateColumns="False" DataKeyNames="UserId"
        SelectMethod="GridViewUsers_GetUsers"
        DeleteMethod="GridViewUsers_BanUser">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username">
                <ItemStyle Width="910"/>
            </asp:BoundField>
            <asp:CheckBoxField DataField="IsAdmin" HeaderText="Is Admin?" SortExpression="IsAdmin">
                <ItemStyle Width="100" HorizontalAlign="Center"/>
            </asp:CheckBoxField>
            <asp:HyperLinkField HeaderText="" Text="Edit" DataNavigateUrlFields="UserId" 
                DataNavigateUrlFormatString="EditUser.aspx?userId={0}">
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:HyperLinkField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Ban" ID="LinkButtonBanUser"
                        CommandName="Ban" CommandArgument="<%# Item.UserId %>"
                        OnClientClick="return confirm('Do you want to ban this user ?');" />
                </ItemTemplate>
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:TemplateField>
        </Columns>  
    </asp:GridView>

</asp:Content>
