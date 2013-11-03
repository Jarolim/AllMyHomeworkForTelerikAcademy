<%@ Page Title="Current Post"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Post.aspx.cs"
    Inherits="StichtiteForum.Post" %>

<%@ Register Src="~/Controls/AddEditPostControl.ascx"
    TagName="AddEditPostControl" TagPrefix="uc" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewPost"
        DataKeyNames="PostId"
        SelectMethod="FormViewPost_GetItem"
        DeleteMethod="FormViewPost_DeleteItem"
        ItemType="StichtiteForum.Models.Post">
        <ItemTemplate>
            <h3><%#: Item.Title %></h3>
            <div><%#: Item.Content %></div>
            <asp:LinkButton Text="Edit" runat="server"
                ID="ButtonEditPost"
                CommandName="Edit" CommandArgument="<%#: Item.PostId %>"
                CssClass="btn btn-info btn-small"
                OnCommand="ButtonEditPost_Command" />
            <asp:LinkButton Text="Delete" runat="server"
                ID="LinkButtonDeletePost"
                OnClientClick="confirm('Are you sure you want to delete this post')"
                CommandName="Delete"
                CssClass="btn btn-danger btn-small" />
            <ul>
                <asp:UpdatePanel runat="server" ID="UpdatePanelComments"
                    UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ButtonRefresh"
                            EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:LinkButton Text="Refresh" ID="ButtonRefresh" runat="server"
                            OnClick="ButtonRefresh_Click" />
                        <asp:ListView runat="server" ID="ListViewComments"
                            ItemType="StichtiteForum.Models.Comment"
                            DataKeyNames="CommentId"
                            InsertItemPosition="None"
                            OnItemInserted="ListViewComments_ItemInserted"
                            SelectMethod="ListViewComments_GetData"
                            UpdateMethod="ListViewComments_UpdateItem"
                            InsertMethod="ListViewComments_InsertItem"
                            DeleteMethod="ListViewComments_DeleteItem">

                            <LayoutTemplate>
                                <h3>Comments</h3>
                                <div runat="server" id="itemPlaceholder"></div>
                                <div class="pagerLine">
                                    <asp:DataPager ID="DataPagerComments" runat="server" PageSize="4">
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
                                <div id="commentHolder">
                                    <div><%#: Item.Content %> created on <span><%#: Item.CommentDate %></span></div>
                                    <div>created by: <%#: Item.AspNetUser.UserName %></div>
                                    <asp:LinkButton Text="Edit" runat="server" ID="ButtonEditComment"
                                        CssClass="btn btn-info btn-small"
                                        CommandName="Edit" CommandArgument="<%#: Item.CommentId %>"
                                        OnCommand="ButtonEditComment_Command" />
                                    <asp:LinkButton Text="Delete" runat="server"
                                        ID="LinkButtonDeleteComment" CssClass="btn btn-danger btn-small"
                                        CommandName="Delete" />
                                </div>
                            </ItemTemplate>

                            <InsertItemTemplate>
                                <h4>Add New Comment</h4>
                                <asp:TextBox ID="TextBoxComment" runat="server"
                                    Text="<%# BindItem.Content  %>"
                                    TextMode="MultiLine" Rows="6" Width="200px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server"
                                    ControlToValidate="TextBoxComment"
                                    ErrorMessage="<span class='label label-important'>Comment content should not be empty.</span>" />
                                <br />
                                <asp:LinkButton Text="Save" CommandName="Insert" runat="server"
                                    ID="ButtonInsert"
                                    CssClass="btn btn-info btn-small" />
                                <asp:LinkButton Text="Cancel" CommandName="Cancel" runat="server"
                                    CausesValidation="false" CssClass="btn btn-danger btn-small" />
                            </InsertItemTemplate>

                            <EditItemTemplate>
                                <h4>Edit Comment</h4>
                                <asp:TextBox ID="TextBoxComment" runat="server"
                                    Text="<%# BindItem.Content  %>"
                                    TextMode="MultiLine" Rows="6" Width="200px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server"
                                    ControlToValidate="TextBoxComment"
                                    ErrorMessage="<span class='label label-important'>Comment content should not be empty.</span>" />
                                <br />
                                <asp:LinkButton Text="Save" CommandName="Update" CssClass="btn btn-info btn-small"
                                    CommandArgument="<%# Item.CommentId %>" runat="server" />
                                <asp:LinkButton Text="Cancel" CommandName="Cancel" runat="server"
                                    CssClass="btn btn-danger btn-small" CausesValidation="false" />
                            </EditItemTemplate>

                        </asp:ListView>
                        </ul>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="ButtonInsertComment" runat="server"
                    OnClick="ButtonInsertComment_Click" Text="Add Comment" />

                <%--<div id="addCommentWrapper">
                <h4>Add New Comment</h4>
                <asp:TextBox ID="TextBoxComment" runat="server"
                    Text="<%# BindItem.Comments  %>"
                    TextMode="MultiLine" Rows="6" Width="200px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server"
                    ControlToValidate="TextBoxComment"
                    ErrorMessage="<span class='label label-important'>Comment content should not be empty.</span>" />
                <br />
                <asp:LinkButton Text="Save" CommandName="Insert" runat="server" />
                <asp:LinkButton Text="Cancel" CommandName="Cancel" runat="server" CausesValidation="false" />
            </div>--%>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
