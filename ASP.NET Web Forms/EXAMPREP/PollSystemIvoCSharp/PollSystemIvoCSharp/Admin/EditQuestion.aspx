<%@ Page Title="Edit Question" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="EditQuestion.aspx.cs" Inherits="PollSystemIvoCSharp.Admin.EditQuestion" %>
<asp:Content ID="ContentEditQuestion" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Question</h1>
    
    Question Text:
    <asp:TextBox ID="TextBoxQuestionText" runat="server" />

    <asp:LinkButton ID="LinkButtonSaveQuestion" Text="Save" runat="server" OnClick="LinkButtonSaveQuestion_Click"/>

    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server"  ItemType="PollSystemIvoCSharp.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %>  --> <%#: Item.Votes %>
                    <a href="EditAnswer.aspx?answerId=<%# Item.AnswerId %>">Edit...</a>

                    <asp:LinkButton Text="Delete" runat="server" CommandName="Delete" CommandArgument="<%# Item.AnswerId %>" 
                        onClientClick ="return confirm('Do you wat to cancel?');"
                        OnCommand="Delete_Command"/>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:LinkButton ID="LinkButtonCreateNewAnswer" Text="Create New Answer" runat="server" Visible="false" OnClick="LinkButtonCreateNewAnswer_Click"/>

</asp:Content>
