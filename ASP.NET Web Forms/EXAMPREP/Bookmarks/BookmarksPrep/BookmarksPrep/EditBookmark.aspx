<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBookmark.aspx.cs" Inherits="BookmarksPrep.EditBookmark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Bookmark</h1>

    Bookmark Title:
    <asp:TextBox ID="TextBoxBookmarkTitle" runat="server" />

    Bookmark URL:
    <asp:TextBox ID="TextBoxBookmarkURL" runat="server" />

<%--    Bookmark Date of Creation:
    <asp:TextBox ID="TextBoxBookmarkDateOfCreation" runat="server" />--%>

    <asp:LinkButton ID="LinkButtonSaveBookmark" Text="Save" runat="server" OnClick="LinkButtonSaveBookmark_Click"/>

</asp:Content>
