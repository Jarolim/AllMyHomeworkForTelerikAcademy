<%@ Page Title="Voting Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowVotingResults.aspx.cs" Inherits="PollSystemIvoCSharp.ShowVotingResults" %>

<asp:Content ID="ContentVotingResults" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Voting Results</h1>
    <h2>Questions:
        <asp:Literal ID="LiteralQuestion" runat="server" Mode="Encode" /></h2>
    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server"  ItemType="PollSystemIvoCSharp.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %>  --> <%#: Item.Votes %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
