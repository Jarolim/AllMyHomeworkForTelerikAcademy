<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StringOccurrencesWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Calculator Client Web Application</title>
</head>

<body>
    <form id="formCalculatorConsumer" runat="server">
    <div aria-autocomplete="both">
        First string: <asp:TextBox ID="TextBoxFirstString" runat="server"/><br />
        <br />
        Second string: <asp:TextBox ID="TextBoxSecondString" runat="server" /><br />
        <br />
        <asp:Button ID="ButtonCalculate" runat="server" Text="Calculate" onclick="ButtonCalculate_Click" />          
        <br />        
    </div>
    <asp:Label ID="LabelResult" runat="server"></asp:Label>
    </form>
</body>
</html>
