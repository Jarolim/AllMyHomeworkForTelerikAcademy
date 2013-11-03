<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookmarksPrep._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bookmarks:</h1>
    <asp:ListView runat="server" ID="ListViewBookmarks" ItemType="BookmarksPrep.Models.Bookmark">
        <ItemTemplate>

            

            <div class="bookmarks">
                <div class="bookmarksTitle"><%#: Item.Title %></div>
                <a href="<%#: Item.URL %>" class="bookmarksURL"><%#: Item.URL %></a>
            </div>

        </ItemTemplate>
    </asp:ListView>

</asp:Content>
