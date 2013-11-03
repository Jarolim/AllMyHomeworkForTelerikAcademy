﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PollSystemIvoCSharp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ListViewPolls" runat="server" ItemType="PollSystemIvoCSharp.Models.Question">
        <ItemTemplate>
            <div class="poll-question">
                <%#: Item.QuestionText %>
                <ul>
                    <asp:Repeater runat="server" ItemType="PollSystemIvoCSharp.Models.Answer" DataSource="<%# Item.Answers %>">
                        <ItemTemplate>
                            <li>
                                <%#: Item.AnswerText %>
                                <asp:LinkButton Text="Vote" runat="server" CommandName="Vote" CommandArgument="<%# Item.AnswerId %>" OnCommand="Vote_Command"/>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
