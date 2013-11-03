<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowChannels.aspx.cs" Inherits="WebChat.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ListViewChat" runat="server"
        ItemType="WebChat.Models.Channel">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="chat-channel">
                <asp:HyperLink NavigateUrl="ShowChannels.aspx" runat="server"
                    Text="<%#: Item.ChannelName %>" />
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:GridView ID="GridViewChannels" runat="server"
        AutoGenerateColumns="False" DataKeyNames="ChannelId"
        AllowSorting="true"
        SelectMethod="GridViewChannels_GetData"
        OnSelectedIndexChanged="GridViewChannels_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ChannelName" HeaderText="Channel"
                SortExpression="ChannelName" />
            <asp:CommandField ShowSelectButton="True" SelectText="Enter channel" HeaderText="Action" />
        </Columns>
    </asp:GridView>

    <ul>
        <asp:Repeater ID="RepeaterMessages" runat="server"
            ItemType="WebChat.Models.Message">
            <HeaderTemplate>
                <h3>Channel Name</h3>
            </HeaderTemplate>

            <ItemTemplate>
                <li>
                    <%#: Item.MessageAuthor %>
                    <%#: Item.MessageDate %>
                    <%#: Item.MessageText %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <ul>
        <asp:ListView ID="ListViewMessages" runat="server"
            ItemType="WebChat.Models.Message" SelectMethod="ListViewMessages_GetData" Visible="false" >
            <LayoutTemplate>
                <h3>Channel Name</h3>
                <div id="itemPlaceholder" runat="server"></div>
                <div class="pager-line">
                    <asp:DataPager ID="DataPagerMessages" runat="server" PageSize="4">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <%#: Item.MessageAuthor %>
                    <%#: Item.MessageDate %>
                    <%#: Item.MessageText %>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </ul>


    <%--<asp:DataPager ID="DataPagerMessages" runat="server"
        PagedControlID="ListViewMessages" PageSize="3"
        QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>--%>
</asp:Content>
