<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
    </div>

    <div class="row">
        <h2>Most popular articles</h2>
    </div>
    <asp:ListView ID="ListViewPopularArticles" runat="server" ItemType="NewsSystem.Models.Article" SelectMethod="ListViewPopularArticles_GetData">
        <ItemTemplate>
            <div class="row">
                <h2>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%#:  Item.Title %>' />
                </h2>
                <p><%#: Item.Content %></p>
                <p>Likes: <%# Item.Likes.Count %></p>
                <p><i>by <%#: Item.Author.UserName %> created on: <%# Item.DateCreated %></i></p>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <div class="row">
        <h2>All categories</h2>
    </div>
    <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSystem.Models.Category" SelectMethod="ListViewCategories_GetData"
        GroupItemCount="2">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h2><%#: Item.Name %></h2>
                <asp:ListView runat="server" ID="RepeaterArticles" ItemType="NewsSystem.Models.Article" DataSource="<%# Item.Articles %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>' runat="server" Text='<%#: string.Format(@"{0} by <i>{1}</i>", Item.Title, Item.Author.UserName) %>' />
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
