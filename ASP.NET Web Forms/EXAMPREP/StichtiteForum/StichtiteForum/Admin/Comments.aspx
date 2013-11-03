<%@ Page Title="ACP Comments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Comments.aspx.cs" Inherits="StichtiteForum.Admin.Comments" %>

<asp:Content ID="ContentAdminComments" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Comments <a href="Posts.aspx" class="btn btn-inverse pull-right">Go Back</a></h1>
    
    <h3><asp:Label runat="server" ID="LabelPostTitle"/></h3>
    
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
    
    <asp:GridView runat="server" ID="GridViewComments" AllowPaging="True" AllowSorting="True" PageSize="5" 
        ItemType="StichtiteForum.Models.CommentModel" AutoGenerateColumns="False" DataKeyNames="CommentId"
        SelectMethod="GridViewComments_GetComments"
        DeleteMethod="GridViewComments_DeleteComment"
        OnSelectedIndexChanged="GridViewComments_OnSelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Comment">
                <ItemTemplate>
                    <div class="comment-content">
                        <asp:Label runat="server" ID="LabelComment" Text='<%#: Bind("Content") %>'/>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="700"/>
            </asp:TemplateField>
            <asp:BoundField DataField="AuthorUsername" HeaderText="Author" SortExpression="AuthorUsername">
                <ItemStyle Width="150" HorizontalAlign="Center"/>
            </asp:BoundField>
            <asp:BoundField DataField="CommentDate" HeaderText="Date" SortExpression="CommentDate">
                <ItemStyle Width="150" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Content">
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:CommandField>
            <asp:HyperLinkField HeaderText="" Text="Edit" DataNavigateUrlFields="CommentId" 
                DataNavigateUrlFormatString="EditComment.aspx?commentId={0}">
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:HyperLinkField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Delete" ID="LinkButtonDeleteItem"
                        CommandName="Delete" CommandArgument="<%# Item.CommentId %>"
                        OnClientClick="return confirm('Do you want to delete this comment ?');" />
                </ItemTemplate>
                <ItemStyle Width="70" HorizontalAlign="Center"/>
            </asp:TemplateField>
        </Columns>  
    </asp:GridView>
    
    <br/>
    <div class="comment-details">
        <h4><asp:Label runat="server" ID="LabelCommentContentTitle" Text="Comment Content" Visible="False"/></h4>
        <asp:Literal runat="server" ID="LiteralCommentContent" />  
    </div>

</asp:Content>
