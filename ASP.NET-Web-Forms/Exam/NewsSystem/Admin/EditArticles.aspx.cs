using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Admin
{
    public partial class EditArticles : System.Web.UI.Page
    {
        public ApplicationDbContext dbContext;

        public EditArticles()
        {
            this.dbContext = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Article> ListViewArticles_GetData()
        {
            return this.dbContext.Articles.OrderBy(a => a.Id);
        }

        public void ListViewArticles_UpdateItem(int Id)
        {
            this.Page.Validate("EditArticle");
            Article item = dbContext.Articles.Find(Id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                dbContext.SaveChanges();
            }
        }

        public void ListViewArticles_DeleteItem(int Id)
        {
            Article item = this.dbContext.Articles.Find(Id);
            this.dbContext.Articles.Remove(item);
            this.dbContext.SaveChanges();
        }

        public void ListViewArticles_InsertItem()
        {
            var item = new Article();
            TryUpdateModel(item);
            string authorName = Page.User.Identity.Name;
            item.AuthorId = dbContext.Users.FirstOrDefault(a => a.UserName == authorName).Id;
            item.DateCreated = DateTime.Now;
            if (ModelState.IsValid)
            {
                dbContext.Articles.Add(item);
                dbContext.SaveChanges();
            }
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.dbContext.Categories.OrderBy(c => c.Name);
        }
    }
}