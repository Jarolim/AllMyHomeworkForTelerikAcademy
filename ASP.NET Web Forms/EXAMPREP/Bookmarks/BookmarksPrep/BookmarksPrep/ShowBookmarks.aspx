<%@ Page Title="Show Bookmarks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowBookmarks.aspx.cs" Inherits="BookmarksPrep.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Show Bookamarks:</h1>

    <asp:GridView ID="GridViewBookmarks" PageSize="5" AllowPaging="true" runat="server" AutoGenerateColumns="False"
        DataKeyNames="BookmarkId" SelectMethod="GridViewBookmarks_GetData" AllowSorting="false">
        <Columns>          
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL"/>
            <asp:BoundField DataField="DateOfCreation" HeaderText="Date Of Creation" SortExpression="DateOfCreation"/>
            <asp:CommandField ShowSelectButton="True" SelectText="Details" HeaderText="Action"/>            
        </Columns>
    </asp:GridView>

</asp:Content>
