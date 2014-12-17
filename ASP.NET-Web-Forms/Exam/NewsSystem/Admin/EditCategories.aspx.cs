using Error_Handler_Control;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        public ApplicationDbContext dbContext;

        public EditCategories()
        {
            this.dbContext = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> GridViewCategories_GetData()
        {
            return this.dbContext.Categories.OrderBy(b => b.Id);
        }

        public void GridViewCategories_UpdateItem(int id)
        {
            Category item = this.dbContext.Categories.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            if (!TryUpdateModel(item))
            {
                ErrorSuccessNotifier.AddErrorMessage("Cannot update category!");
            }

            if (ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category updated.");
            }
        }

        public void GridViewCategories_DeleteItem(int id)
        {
            Category item = this.dbContext.Categories.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            ErrorSuccessNotifier.AddSuccessMessage("Category deleted.");
            this.dbContext.Categories.Remove(item);
            this.dbContext.SaveChanges();
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.btnWrapper.Visible = false;
            var fv = this.UpdatePanelInsertCategory.FindControl("FormViewIsertCategory") as FormView;
            fv.Visible = true;
        }

        public void FormViewIsertCategory_InsertItem()
        {
            var item = new NewsSystem.Models.Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                ErrorSuccessNotifier.AddSuccessMessage("Category added.");
                this.dbContext.Categories.Add(item);
                this.dbContext.SaveChanges();
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Cannot create category!");
            }
        }
    }
}