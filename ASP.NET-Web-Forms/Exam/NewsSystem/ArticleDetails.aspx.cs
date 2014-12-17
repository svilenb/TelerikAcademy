using LikesDemo.Controls;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        public ApplicationDbContext dbContext;

        public ArticleDetails()
        {
            this.dbContext = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public NewsSystem.Models.Article FormViewArticleDetails_GetItem()
        {
            string artId = Request.QueryString["id"];
            if (artId == null)
            {
                Response.Redirect("~/");
            }

            int articleID = Convert.ToInt32(artId);

            var article = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleID);
            return article;
        }

        protected int GetLikesValue()
        {
            string artId = Request.QueryString["id"];
            if (artId == null)
            {
                Response.Redirect("~/");
            }

            int articleID = int.Parse(artId);

            Article item = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleID);
            int likesCount = item.Likes.Count(l => l.Value == true);
            int hatesCount = item.Likes.Count(l => l.Value == false);
            return likesCount - hatesCount;
        }

        public int GetArticleId()
        {
            string artId = Request.QueryString["id"];
            if (artId == null)
            {
                Response.Redirect("~/");
            }

            int articleID = int.Parse(artId);
            return articleID;
        }

        protected bool? GetUserVote()
        {
            string artId = Request.QueryString["id"];
            if (artId == null)
            {
                Response.Redirect("~/");
            }

            int articleID = int.Parse(artId);


            Article item = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleID);
            string authorName = Page.User.Identity.Name;
            Author author = dbContext.Users.FirstOrDefault(a => a.UserName == authorName);
            if (author == null)
            {
                return null;
            }

            string userID = dbContext.Users.FirstOrDefault(a => a.UserName == authorName).Id;
            var like = item.Likes.FirstOrDefault(l => l.AuthorId == userID);
            if (like == null)
            {
                return null;
            }

            return like.Value;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            e.DataID = Request.QueryString["id"];
            Article article = this.dbContext.Articles.Find(Convert.ToInt32(e.DataID));
            string authorName = Page.User.Identity.Name;
            string userID = dbContext.Users.FirstOrDefault(a => a.UserName == authorName).Id;

            Like like = article.Likes.FirstOrDefault(l => l.AuthorId == userID);
            if (like == null)
            {
                like = new Like()
                {
                    AuthorId = userID,
                    ArticleId = Convert.ToInt32(e.DataID)
                };

                article.Likes.Add(like);
            }

            like.Value = e.LikeValue;
            this.dbContext.SaveChanges();

            //LikeControl ctrl = sender as LikeControl;
            DataBind();
        }
    }
}