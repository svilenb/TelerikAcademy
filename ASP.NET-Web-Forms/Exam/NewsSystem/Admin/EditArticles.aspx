<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="NewsSystem.Admin.EditArticles" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary DisplayMode="BulletList" EnableClientScript="true" runat="server" ID="errorResult" ValidationGroup="EditArticle" />
    <asp:ValidationSummary DisplayMode="BulletList" EnableClientScript="true" runat="server" ID="ValidationSummaryCreateArticle" ValidationGroup="CreateArticle" />
    <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSystem.Models.Article" SelectMethod="ListViewArticles_GetData"
        DeleteMethod="ListViewArticles_DeleteItem" UpdateMethod="ListViewArticles_UpdateItem" InsertMethod="ListViewArticles_InsertItem"
        InsertItemPosition="LastItem" DataKeyNames="Id">
        <LayoutTemplate>
            <div class="row">
                <div class="col-md-3 panel">
                    <asp:LinkButton Text="Sort by Title" runat="server" ID="LinkButtonSortByTitle" CommandName="Sort" CommandArgument="Title" />
                </div>
                <div class="col-md-3  panel">
                    <asp:LinkButton Text="Sort by Date" runat="server" ID="LinkButtonSortByDate" CommandName="Sort" CommandArgument="DateCreated" />
                </div>
            </div>
            <div class="row">
                <asp:DataPager runat="server" ID="DataPagerArticles" PagedControlID="ListViewArticles" PageSize="5">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
                <asp:LinkButton runat="server" ID="LinkButtonInsert" Text="Insert" OnClick="LinkButtonInsert_Click" CssClass="btn btn-primary pull-right"></asp:LinkButton>
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-3"><%#: Item.Title %></div>
                <asp:LinkButton CssClass="btn btn-info" runat="server" ID="LinkButtonEdit" Text="Edit" CommandName="Edit" />
                <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="LinkButtonDelete" Text="Delete" CommandName="Delete" />
            </div>
            <div class="row">
                <div class="col-md-3">Category: <%#: Item.Category.Name %></div>
            </div>
            <div class="row">
                <div class="col-md-10"><%#: Item.Content %></div>
            </div>
            <div class="row">
                <div class="col-md-10">Likes: <%#: Item.Likes.Count %></div>
            </div>
            <div class="row">
                <i>by <%#: Item.Author.UserName %> created on: <%# Item.DateCreated %></i>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="TextBoxTitle" Text="<%#: BindItem.Title %>" />
                    <asp:RequiredFieldValidator
                        ErrorMessage="Title Required!"
                        ControlToValidate="TextBoxTitle"
                        runat="server"
                        Display="None"
                        ValidationGroup="EditArticle" />
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                <asp:LinkButton runat="server" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" DataTextField="Name"
                        DataValueField="Id" ItemType="NewsSystem.Models.Category"
                        SelectedValue="<%#: BindItem.CategoryID %>" SelectMethod="DropDownListCategoriesCreate_GetData">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxContent" Text="<%#: BindItem.Content %>" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator
                        ErrorMessage="Content Required!"
                        ControlToValidate="TextBoxContent"
                        runat="server"
                        Display="None"
                        ValidationGroup="EditArticle" />
                </div>
            </div>
            <div class="row">
                <i>by <%#: Item.Author.UserName %> created on: <%# Item.DateCreated %></i>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h2>Create New Article</h2>
            <div>
                <span>Title:</span>
                <asp:TextBox runat="server" ID="TextBoxArticleTitleCreate" placeholder="Enter article title ..." Text=" <%#: BindItem.Title %>">                           
                </asp:TextBox>
                <asp:RequiredFieldValidator
                    ErrorMessage="Title Required!"
                    ControlToValidate="TextBoxArticleTitleCreate"
                    runat="server"
                    Display="None"
                    ValidationGroup="CreateArticle" />
            </div>
            <div>
                <span>Category:</span>
                <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" DataTextField="Name" DataValueField="Id"
                    ItemType="NewsSystem.Models.Category" SelectedValue="<%#: BindItem.CategoryID %>" SelectMethod="DropDownListCategoriesCreate_GetData">
                </asp:DropDownList>
            </div>
            <div>
                <span>Content:</span>
                <asp:TextBox runat="server" ID="TextBoxContentCreate" TextMode="MultiLine" placeholder="Enter article content ..." Text=" <%#: BindItem.Content %>">                           
                </asp:TextBox>
                <asp:RequiredFieldValidator
                    ErrorMessage="Content Required!"
                    ControlToValidate="TextBoxContentCreate"
                    runat="server"
                    Display="None"
                    ValidationGroup="CreateArticle" />
            </div>
            <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="link-button" Text="Create" CommandName="Insert" />
            <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="link-button" Text="Cancel" CommandName="Cancel" PostBackUrl="~/Admin/EditArticles.aspx" />
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
