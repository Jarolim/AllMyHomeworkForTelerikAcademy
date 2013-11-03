<%@ Page Title="ACP Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Posts.aspx.cs" Inherits="StichtiteForum.Admin.Posts" %>

<asp:Content ID="ContentAdminPosts" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Posts</h1>
    
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

    <asp:GridView ID="GridViewPosts" runat="server" AllowPaging="True" PageSize="5" ItemType="StichtiteForum.Models.PostModel"
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PostId"
        DeleteMethod="GridViewPosts_DeleteItem"
        SelectMethod="GridViewPosts_GetData">  
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title">
                <ItemStyle Width="570"/>
            </asp:BoundField>
            <%--<asp:BoundField DataField="AuthorUsername" HeaderText="Username" SortExpression="AuthorUsername">
                <ItemStyle Width="150"/>
            </asp:BoundField>--%>
            <asp:HyperLinkField HeaderText="Username" DataNavigateUrlFields="AuthorId"
                DataTextField="AuthorUsername" SortExpression="AuthorUsername"
                DataNavigateUrlFormatString="Posts.aspx?authorId={0}">
	            <ItemStyle Width="150" HorizontalAlign="Center"/>
            </asp:HyperLinkField>
            <asp:BoundField DataField="PostDate" HeaderText="Post Date" SortExpression="PostDate">
                <ItemStyle Width="150" HorizontalAlign="Center"/>
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Content" 
                       Command="Content" OnCommand="AdminPostGridView_GetContent"
                       CommandArgument="<%# Item.PostId %>"/>
                </ItemTemplate>
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="" Text="Comments" DataNavigateUrlFields="PostId" 
                DataNavigateUrlFormatString="Comments.aspx?postId={0}">
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:HyperLinkField>
            <asp:HyperLinkField HeaderText="" Text="Edit" DataNavigateUrlFields="PostId" 
                DataNavigateUrlFormatString="EditPost.aspx?postId={0}">
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:HyperLinkField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Delete" ID="LinkButtonDeleteItem"
                        CommandName="Delete" CommandArgument="<%# Item.PostId %>"
                        OnClientClick="return confirm('Do you want to delete this item ?');" />
                </ItemTemplate>
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:TemplateField>
        </Columns>  
    </asp:GridView>

    <h3 id="PostContentHeadline" runat="server" visible="false"></h3>

    <asp:Literal ID="PostContentLiteral" runat="server" Visible="false"/>

</asp:Content>
