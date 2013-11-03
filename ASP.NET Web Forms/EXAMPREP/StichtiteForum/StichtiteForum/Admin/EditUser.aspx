<%@ Page Title="ACP Edit User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditUser.aspx.cs" Inherits="StichtiteForum.Admin.EditUser" %>

<asp:Content ID="ContentAdminEditUser" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>ACP Edit User</h1>
    
    <asp:Label runat="server" ID="LabelUsername" Text="Username" AssociatedControlID="TextBoxUsername"/>
    <asp:TextBox runat="server" ID="TextBoxUsername" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxUsername" 
        ErrorMessage="<span class='label label-important'>Username should not be empty.</span>" />
    
    <br/>

    <asp:CheckBox runat="server" ID="CheckBoxIsAdmin" CssClass="inline-element" Text="Is Admin?"/>

    <br/><br/>

    <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" CssClass="btn btn-primary"/>
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" CssClass="btn btn-danger" CausesValidation="False"/>

</asp:Content>
