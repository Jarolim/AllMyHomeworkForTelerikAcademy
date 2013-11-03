<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowChannelsGridView.aspx.cs" Inherits="WebChat.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
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

    <asp:GridView ID="GridViewMessages" runat="server"
        AutoGenerateColumns="False" DataKeyNames="MessageId" 
        AllowSorting="true"
        SelectMethod="GridViewMessages_GetData"
        OnSelectedIndexChanged="GridViewMessages_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField DataField="MessageAuthor" HeaderText="Author"
                SortExpression="MessageAuthor" />
            <asp:BoundField DataField="MessageDate" HeaderText="Date"
                SortExpression="MessageDate" />
            <asp:BoundField DataField="MessageText" HeaderText="Text"
                SortExpression="MessageText" />
            <asp:CommandField ShowSelectButton="True" SelectText="Enter channel" HeaderText="Action" />
        </Columns>
    </asp:GridView>

</asp:Content>
