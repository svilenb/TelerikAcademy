<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="NewsSystem.Admin.EditCategories" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="GridViewCategories" ItemType="NewsSystem.Models.Category"
        SelectMethod="GridViewCategories_GetData" UpdateMethod="GridViewCategories_UpdateItem"
        DeleteMethod="GridViewCategories_DeleteItem" AllowSorting="True" AllowPaging="True"
        PageSize="5" AutoGenerateColumns="false" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    <div runat="server" id="btnWrapper">
        <asp:LinkButton Text="Insert" ID="LinkButtonInsert" runat="server" OnClick="LinkButtonInsert_Click" />
    </div>
    <asp:UpdatePanel runat="server" ID="UpdatePanelInsertCategory">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonInsert" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:FormView runat="server" ID="FormViewIsertCategory"
                DefaultMode="Insert"
                ItemType="NewsSystem.Models.Category"
                InsertMethod="FormViewIsertCategory_InsertItem" Visible="false">
                <InsertItemTemplate>
                    <h2>Create New Book</h2>
                    <div>
                        <span>Name:</span>
                        <asp:TextBox runat="server" ID="TextBoxBookNameCreate" placeholder="Enter category name ..." Text=" <%#: BindItem.Name %>"></asp:TextBox>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="link-button" Text="Create" CommandName="Insert" />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="link-button" Text="Cancel" CommandName="Cancel" PostBackUrl="~/Admin/EditCategories.aspx" />
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
