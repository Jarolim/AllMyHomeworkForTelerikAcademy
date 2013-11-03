<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditPostControl.ascx.cs" 
    Inherits="StichtiteForum.Controls.AddEditPostControl" %>

<div id="post-title">
    <%--<label>Comment Title</label>--%>
    <asp:TextBox ID="TextBoxPostTitle" runat="server" MaxLength="200" Visible="false"></asp:TextBox>
</div>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" 
    ControlToValidate="TextBoxPostTitle" Display="Dynamic" 
    ErrorMessage="<span class='error-message'>Title field should not be empty.</span>">
</asp:RequiredFieldValidator>--%>

<div id="post-content">
    <label>Comment Content</label>
    <asp:TextBox ID="TextBoxPostContent" runat="server" Height="100px" 
        TextMode="MultiLine"></asp:TextBox>
</div>
<asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" 
runat="server" ControlToValidate="TextBoxPostContent" 
ErrorMessage="<span class='error-message'>Post content should not be empty.</span>">
</asp:RequiredFieldValidator>
<br />
<asp:FileUpload ID="FileUploadControl" runat="server" />
<footer>
    <asp:LinkButton ID="ButtonSubmitPost" runat="server" Height="26px" Text="Submit" 
                        Width="100px"/>
    <asp:LinkButton ID="ButtonCancel" runat="server" Height="26px" Text="Cancel" 
                        Width="100px" CommandName="Cancel"/>
</footer>