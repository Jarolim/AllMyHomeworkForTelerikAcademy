<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_04.EmployeesWithRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>ID</th>
                            <th>FirstName</th>
                            <th>LastName</th>
                            <th>Title</th>
                            <th>TitleOfCourtesy</th>
                            <th>BirthDate</th>
                            <th>HireDate</th>
                            <th>Address</th>
                            <th>City</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "EmployeeID") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Title") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "BirthDate") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "HireDate") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Address") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "City") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [TitleOfCourtesy], [Title], [BirthDate], [HireDate], [Address], [City] FROM [Employees]"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
