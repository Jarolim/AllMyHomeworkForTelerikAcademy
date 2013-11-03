<%@ Page Title="Edit Questions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditQuestions.aspx.cs" Inherits="PollSystemIvoCSharp.EditQuestions" %>

<asp:Content ID="ContentVIewAllResults" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridViewQuestions" PageSize="3" AllowPaging="true" runat="server" AutoGenerateColumns="False"
        DataKeyNames="QuestionId" SelectMethod="GridViewQuestions_GetData" AllowSorting="true" ItemType="PollSystemIvoCSharp.Models.Question"
        DeleteMethod="GridViewQuestions_DeleteItem">
        <Columns>          
            <asp:BoundField DataField="QuestionText" HeaderText="Question" SortExpression="QuestionText"/>           
            <%--<asp:CommandField ShowSelectButton="True" SelectText="Edit" HeaderText="Action"/> --%> 
            <asp:HyperLinkField Text="Edit..." HeaderText="Action" DataNavigateUrlFields="QuestionId"
                 DataNavigateUrlFormatString="EditQuestion.aspx?questionId={0}"  />    

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDeleteQuestion" Text="Delete" runat="server" CommandName="Delete" CommandArgument="<%# Item.QuestionId %>" 
                        onClientClick ="return confirm('Do you wat to cancel?');"/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <a href="EditQuestion.aspx">Create New Question</a>

</asp:Content>
