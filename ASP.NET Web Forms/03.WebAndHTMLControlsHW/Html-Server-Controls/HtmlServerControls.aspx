<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlServerControls.aspx.cs" 
  Inherits="Html_Server_Controls.HtmlServerControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Generate Random Number</title>
</head>

<body>
    <form id="formMain" runat="server">      
        <input id="TextFieldOne" type="text" runat="server" />
        <input id="TextFieldTwo" type="text" runat="server" />
        <input id="ButtonSubmit" type="button"
            runat="server" value="Submit"
            onserverclick="ButtonSubmit_Click" />
    </form>
</body>

</html>
