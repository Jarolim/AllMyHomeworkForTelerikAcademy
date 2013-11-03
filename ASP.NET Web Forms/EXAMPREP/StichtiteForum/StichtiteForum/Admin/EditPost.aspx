<%@ Page Title="ACP Edit Post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="StichtiteForum.Admin.EditPosts" EnableEventValidation="false" %>

<asp:Content ID="ContentAdminEditPost" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Edit Post</h1>

    <br />

    <section id="edit-post">
        <asp:Label runat="server" ID="LabelPostTitle" Text="Post Title" AssociatedControlID="TextBoxPostTitle"/>
        <asp:TextBox ID="TextBoxPostTitle" runat="server" MaxLength="200"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxPostTitle" Display="Dynamic" 
            ErrorMessage="<span class='label label-important'>Title field should not be empty.</span>"/>
        
        <br />

        <asp:Label runat="server" ID="LabelPostContent" Text="Post Content" AssociatedControlID="TextBoxPostContent"/>
        <asp:TextBox ID="TextBoxPostContent" runat="server" Height="200px" Width="500px" TextMode="MultiLine"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxPostContent" 
            ErrorMessage="<span class='label label-important'>Post content should not be empty.</span>"/>
        
        <br />

        <h4>Files:</h4>
        <asp:GridView ID="FileGridView"
            runat="server" ItemType="StichtiteForum.Models.File"
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="FileId"
            DeleteMethod="FileGridView_DeleteItem"
            SelectMethod="FileGridView_GetData">
            <columns>
                <asp:BoundField DataField="FileId" HeaderText="File Id" SortExpression="FileId">
                  <ItemStyle Width="140"/>
                </asp:BoundField>
                <asp:BoundField DataField="Path" HeaderText="File Path" SortExpression="Path">
                  <ItemStyle Width="140"/>
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Delete" ID="LinkButtonDeleteItem"
                            CommandName="Delete" CommandArgument="<%# Item.FileId %>"
                            OnClientClick="return confirm('Do you want to delete this item ?');" />
                    </ItemTemplate>
                    <ItemStyle Width="50" HorizontalAlign="Center"/>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" Text="Edit" ID="LinkButtonEditItem"
                            OnCommand="LinkButtonEditItem_Command" 
                            CommandArgument="<%# Item.FileId %>" />
                    </ItemTemplate>
                    <ItemStyle Width="50" HorizontalAlign="Center"/>
                </asp:TemplateField>
            </columns>
        </asp:GridView>

        <h5 id="EditFileHeadline" runat="server" visible="false">Edit file:</h5>
        <asp:Literal ID="EditFileIdLiteral" Text="" runat="server" visible="false" />   
        <asp:TextBox runat="server" ID="EditFileTextbox" visible="false" />
        <asp:Button Text="Submit" runat="server" ID="EditFileSubmitButton" Visible="false" OnClick="EditFileSubmitButton_Click" CssClass="btn btn-success"/>
        
        <%--<div id="add-file">
            <label for="AddFileLocation">File Location</label>
            <asp:TextBox ID="AddFileLocation" runat="server" MaxLength="255"></asp:TextBox>
            <asp:Button Text="Add File" runat="server" OnClick="AddFile_Click" />
        </div>--%>

        <br />

        <footer>
            <asp:Button ID="ButtonSubmitPost" runat="server" Text="Submit"  OnClick="ButtonSubmitPost_Click" CssClass="btn btn-primary"/>
            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" CssClass="btn btn-danger" CausesValidation="False"/>
        </footer>
    </section>
</asp:Content>
