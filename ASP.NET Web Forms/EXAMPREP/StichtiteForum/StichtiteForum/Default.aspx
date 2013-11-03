<%@ Page Title="Home Page" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="StichtiteForum._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:ListView ID="PostsList"
            runat="server"
            ItemType="StichtiteForum.Models.Post"
            SelectMethod="PostsList_GetData">
            <LayoutTemplate>
                <div class="hero-unit span7">
                    <h3>Posts:</h3>
                    <asp:LoginView runat="server">
                        <LoggedInTemplate>
                            <a href="EditPost.aspx">Add New Post</a>
                        </LoggedInTemplate>
                    </asp:LoginView>
                    <ul id="itemPlaceholder" runat="server"></ul>
                    <asp:DataPager ID="DataPagerComments" runat="server" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True"
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <a href="Post.aspx?id=<%# Item.PostId%>"><%#: Item.Title%></a>
                    posted on: <%#: Item.PostDate %>
                    <br />
                    <sup>Author: <%#: Item.AspNetUser.UserName %> </sup>
                </li>
            </ItemTemplate>
        </asp:ListView>

        <asp:ListView ID="CategoriesList"
            runat="server"
            ItemType="StichtiteForum.Models.Category"
            SelectMethod="CategoriesList_GetData">
            <LayoutTemplate>
                <div class="hero-unit span2">
                    All categories:
                <ul id="itemPlaceholder" runat="server"></ul>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <li><a href="PostsByCategory.aspx?id=<%# Item.CategoryId %>"><%#: Item.Title%></a></li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
