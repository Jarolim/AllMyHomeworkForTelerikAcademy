<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebChat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ListViewChat" runat="server"
        ItemType="WebChat.Models.Channel">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="chat-channel">
                <%#: Item.ChannelName %>
                <ul>
                    <asp:Repeater ID="RepeaterMessages" runat="server"
                        ItemType="WebChat.Models.Message"
                        DataSource="<%# Item.Messages %>">
                        <ItemTemplate>
                            <li>
                                <%#: Item.MessageAuthor %>
                                <%#: Item.MessageDate %>
                                <%#: Item.MessageText %>
                                <%--<asp:LinkButton ID="LinkButton1" Text="Vote" runat="server"
                                    CommandName="Vote"
                                    CommandArgument="<%#: Item.AnswerId %>"
                                    OnCommand="Vote_Command" />--%>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
