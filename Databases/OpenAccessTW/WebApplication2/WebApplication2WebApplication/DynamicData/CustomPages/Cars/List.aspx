<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="List.aspx.cs" Inherits="WebApplication2WebApplication.Cars.List" %>
<%@ Register Assembly="Telerik.OpenAccess.Web.40" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>
<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head"/>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>

    <h2 class="DDSubHeader"><%= this.Table.DisplayName %> List View</h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="DD">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                    HeaderText="List of validation errors" CssClass="DDValidator" />
                <asp:DynamicValidator runat="server" ID="GridViewValidator" ControlToValidate="GridView1" Display="None" CssClass="DDValidator" />

                <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("DisplayName") %>' OnPreRender="Label_PreRender" />
                        <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged" /><br />
                    </ItemTemplate>
                </asp:QueryableFilterRepeater>
                <br />
            </div>

            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true"
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView" AutoGenerateColumns="False"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DynamicHyperLink runat="server" Action="Edit" Text="Edit" Visible="True" />
                                <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" Visible="True"
                                    OnClientClick='return confirm("Are you sure you want to delete this item?");' />
							<asp:DynamicHyperLink runat="server" Text="Details" Visible="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
					<asp:DynamicField DataField="CarID" HeaderText="CarID"/>
					<asp:DynamicField DataField="TagNumber" HeaderText="TagNumber"/>
					<asp:DynamicField DataField="Make" HeaderText="Make"/>
					<asp:DynamicField DataField="Model" HeaderText="Model"/>
					<asp:DynamicField DataField="CarYear" HeaderText="CarYear"/>
					<asp:DynamicField DataField="CategoryID" HeaderText="CategoryID"/>
					<asp:DynamicField DataField="Mp3Player" HeaderText="Mp3Player"/>
					<asp:DynamicField DataField="DVDPlayer" HeaderText="DVDPlayer"/>
					<asp:DynamicField DataField="AirConditioner" HeaderText="AirConditioner"/>
					<asp:DynamicField DataField="ABS" HeaderText="ABS"/>
					<asp:DynamicField DataField="ASR" HeaderText="ASR"/>
					<asp:DynamicField DataField="Navigation" HeaderText="Navigation"/>
					<asp:DynamicField DataField="Available" HeaderText="Available"/>
					<asp:DynamicField DataField="Latitude" HeaderText="Latitude"/>
					<asp:DynamicField DataField="Longitude" HeaderText="Longitude"/>
					<asp:DynamicField DataField="ImageFileName" HeaderText="ImageFileName"/>
					<asp:DynamicField DataField="Rating" HeaderText="Rating"/>
					<asp:DynamicField DataField="NumberOfRatings" HeaderText="NumberOfRatings"/>
					<asp:DynamicField DataField="Category" HeaderText="Category"/>
					<asp:DynamicField DataField="RentalOrders" HeaderText="RentalOrders"/>
				</Columns>
				<PagerStyle CssClass="DDFooter"/>        
				<PagerTemplate>
					<asp:GridViewPager runat="server" />
				</PagerTemplate>
				<EmptyDataTemplate>
					There are currently no items in this table.
				</EmptyDataTemplate>
			</asp:GridView>
			<telerik:OpenAccessLinqDataSource ID="GridDataSource" runat="server" EnableDelete="True" />
			<asp:QueryExtender TargetControlID="GridDataSource" ID="GridQueryExtender" runat="server">
				<asp:DynamicFilterExpression ControlID="FilterRepeater" />
			</asp:QueryExtender>
			<br />
			<div class="DDBottomHyperLink">
            	<asp:DynamicHyperLink ID="InsertHyperLink" runat="server" Action="Insert"  Visible="True"><img runat="server" src="~/DynamicData/Content/Images/plus.gif" alt="Insert new item" />Insert new item</asp:DynamicHyperLink>
			</div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

