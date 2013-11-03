<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBookmarks.aspx.cs" Inherits="BookmarksPrep.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Bookamarks:</h1>

    <asp:GridView ID="GridViewBookmarks" PageSize="5" AllowPaging="true" runat="server" AutoGenerateColumns="False"
        DataKeyNames="BookmarkId" SelectMethod="GridViewBookmarks_GetData" ItemType="BookmarksPrep.Models.Bookmark"
        DeleteMethod="GridViewBookmarks_DeleteItem">
        <Columns>
            <asp:BoundField
                DataField="Title"
                HeaderText="Title"
                SortExpression="Title" />
            <asp:BoundField
                DataField="URL"
                HeaderText="URL"
                SortExpression="URL" />
            <asp:BoundField
                DataField="DateOfCreation"
                HeaderText="Date Of Creation" SortExpression="DateOfCreation" />

            <asp:HyperLinkField
                Text="Edit..."
                HeaderText="Action"
                DataNavigateUrlFields="BookmarkId"
                DataNavigateUrlFormatString="EditBookmark.aspx?bookmarkId={0}" />

            <asp:CommandField
                ShowSelectButton="True"
                SelectText="Details"
                HeaderText="Action" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton
                        ID="LinkButtonDeleteBookmark"
                        Text="Delete"
                        runat="server"
                        CommandName="Delete"
                        CommandArgument="<%#: Item.BookmarkId %>"
                        OnClientClick="return confirm('Do you want to cancel?');" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <a href="EditBookmark.aspx">Create New Bookmark</a>

</asp:Content>
