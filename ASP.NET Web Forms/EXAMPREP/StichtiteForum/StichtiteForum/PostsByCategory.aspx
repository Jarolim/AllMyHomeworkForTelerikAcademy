<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostsByCategory.aspx.cs" Inherits="StichtiteForum.PostsByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="PostsList"
        runat="server"
        ItemType="StichtiteForum.Models.Post"
        SelectMethod="PostsList_GetData">
        <LayoutTemplate>
            <div class="hero-unit">
                Posts:
                <ul id="itemPlaceholder" runat="server"></ul>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <li><a href="Post.aspx?id=<%# Item.PostId%>"><%# Item.Title%></a> posted on: <%#Item.PostDate %><br/>
                <sup>Author: <%# Item.AspNetUser.UserName %> </sup>
            </li>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
