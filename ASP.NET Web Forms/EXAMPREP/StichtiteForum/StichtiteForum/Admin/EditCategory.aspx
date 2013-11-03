<%@ Page Title="ACP Edit Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditCategory.aspx.cs" Inherits="StichtiteForum.Admin.EditCategory" %>

<asp:Content ID="ContentAdminEditCategory" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Edit Category</h1>
    
    <asp:Label runat="server" ID="LabelCategoryTitle" Text="Username" AssociatedControlID="TextBoxCategoryTitle"/>
    <asp:TextBox runat="server" ID="TextBoxCategoryTitle" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxCategoryTitle" 
        ErrorMessage="<span class='label label-important'>Title should not be empty.</span>" />
    
    <br/>

    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" CssClass="btn btn-primary"/>
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" CssClass="btn btn-danger" CausesValidation="False"/>

</asp:Content>
