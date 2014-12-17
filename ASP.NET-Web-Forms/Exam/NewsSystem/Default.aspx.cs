using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class _Default : Page
    {
        public ApplicationDbContext dbContext;

        public _Default()
        {
            this.dbContext = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<NewsSystem.Models.Article> ListViewPopularArticles_GetData()
        {
            return this.dbContext.Articles.OrderByDescending(a => a.Likes.Count).Take(3);
        }

        public IQueryable<NewsSystem.Models.Category> ListViewCategories_GetData()
        {
            return this.dbContext.Categories;
        }
    }
}