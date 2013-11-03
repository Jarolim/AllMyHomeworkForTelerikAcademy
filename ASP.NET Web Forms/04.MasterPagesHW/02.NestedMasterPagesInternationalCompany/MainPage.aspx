<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ContentPage" runat="server"
    ContentPlaceHolderID="ContentPlaceHolderPageContent">
    <h1 id="welcome-text">Welcome to our International Company web site</h1>
    <asp:HyperLink runat="server" NavigateUrl="~/Bulgaria/BulgariaHome.aspx" 
        Text="Bulgaria" CssClass="bulgaria-icon"/>
    <asp:HyperLink runat="server" NavigateUrl="~/Britain/BritainHome.aspx"
         Text="Britain" CssClass="britain-icon"/>
</asp:Content>
