<%@ Page Title="View Questions and Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllResults.aspx.cs" Inherits="PollSystemIvoCSharp.ViewAllResults" %>

<asp:Content ID="ContentVIewAllResults" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridViewQuestions" PageSize="3" AllowPaging="true" runat="server" AutoGenerateColumns="False"
        DataKeyNames="QuestionId" SelectMethod="GridViewQuestions_GetData"
         OnSelectedIndexChanged="GridViewQuestions_SelectedIndexChanged" AllowSorting="true">
        <Columns>          
            <asp:BoundField DataField="QuestionText" HeaderText="Question" SortExpression="QuestionText"/>           
            <asp:CommandField ShowSelectButton="True" SelectText="Details" HeaderText="Action"/>            
        </Columns>
    </asp:GridView>

    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server" ItemType="PollSystemIvoCSharp.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %> --> <%#: Item.Votes %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    

</asp:Content>
