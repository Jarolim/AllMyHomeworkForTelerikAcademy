<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MongodbDemo.WebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Book Title
            <asp:TextBox ID="txtBookTitle" runat="server"></asp:TextBox><br />
            Book Author
            <asp:TextBox ID="txtBookAuthor" runat="server"></asp:TextBox><br />
            <asp:LinkButton ID="btnInsert" runat="server" OnClick="btnInsert_Click">Insert</asp:LinkButton>
            <asp:GridView ID="grdResult" runat="server" OnRowCancelingEdit="grdResult_RowCancelingEdit" OnRowDeleting="grdResult_RowDeleting" OnRowEditing="grdResult_RowEditing" OnRowUpdating="grdResult_RowUpdating" DataKeyNames="_id">
                <Columns>
                    <asp:CommandField HeaderText="Action" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
            Search Book By Name:
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click">Search</asp:LinkButton><br />
            <asp:LinkButton ID="btnGeneratePdf" runat="server" OnClick="btnGeneratePdf_Click1">Generate result to pdf</asp:LinkButton>
        </div>
    </form>
</body>
</html>
