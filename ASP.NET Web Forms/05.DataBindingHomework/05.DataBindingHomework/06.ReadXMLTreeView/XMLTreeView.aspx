<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLTreeView.aspx.cs" Inherits="_06.ReadXMLTreeView.XMLTreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="ControlPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
        <asp:XmlDataSource ID="BookXmlDataSource" runat="server" DataFile="~/App_Data/Something.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
