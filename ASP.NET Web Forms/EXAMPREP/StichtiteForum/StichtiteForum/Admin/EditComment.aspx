<%@ Page Title="ACP Edit Comment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditComment.aspx.cs" Inherits="StichtiteForum.Admin.EditComment" %>

<asp:Content ID="ContentAdminEditComment" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Edit Comment</h1>
    
    <h3>Post: <asp:Label runat="server" ID="LabelCommentPostTitle"/></h3>
    
    <asp:Label runat="server" ID="LabelCommentContent" Text="Comment Content" AssociatedControlID="TextBoxCommentContent"/>
    <asp:TextBox runat="server" ID="TextBoxCommentContent" TextMode="MultiLine" Width="600" Rows="6" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxCommentContent" 
        ErrorMessage="<span class='label label-important'>Comment content should not be empty.</span>" />

    <br/>

    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" CssClass="btn btn-primary"/>
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" CssClass="btn btn-danger" CausesValidation="False"/>

</asp:Content>
