<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="NewsSystem.ArticleDetails" %>

<%@ Register Src="~/Controls/LikeControl.ascx" TagPrefix="uc" TagName="LikeControl" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewArticleDetails"
        ItemType="NewsSystem.Models.Article" SelectMethod="FormViewArticleDetails_GetItem">
        <ItemTemplate>
            <header>
                <h1><%#: Item.Title %></h1>
                <h2>Category: <%#: Item.Category.Name %></h2>
            </header>
            <div class="row-fluid">
                <p class="article-title"><%#: Item.Title %></p>
                <p class="article-content"><%#: Item.Content %></p>
                <p class="article-author">Author: <%#: Item.Author.UserName %></i></p>
                <p class="article-date pull-right">
                    <%#: Item.DateCreated %>
                </p>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <asp:LoginView runat="server" ID="LoginViewMenu">
        <LoggedInTemplate>
            <asp:UpdatePanel ID="UpdatePanelFavoriteDrink" runat="server" class="panel" UpdateMode="Conditional">
                <ContentTemplate>
                    <uc:LikeControl runat="server" ID="LikeControl"
                        LikesValue="<%# GetLikesValue() %>"
                        OnLike="LikeControl_Like"
                        UserVote="<%# GetUserVote() %>" />
                    </LoggedInTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
