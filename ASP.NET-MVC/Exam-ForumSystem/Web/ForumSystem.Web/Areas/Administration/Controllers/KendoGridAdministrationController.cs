namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Collections;
    using System.Web.Mvc;

    using ForumSystem.Data;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using AutoMapper;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Data.Common.Models;

    public abstract class KendoGridAdministrationController : Controller
    {
        protected IDeletableEntityRepository<Post> Posts { get; set; }

        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var ads =
                this.GetData()
                .ToDataSourceResult(request);

            return this.Json(ads);
        }

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.GetById<TModel>(id);
                Mapper.Map<TViewModel, TModel>(model, dbModel);
                this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest]DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Posts.Context.Entry(dbModel);
            entry.State = state;
            this.Posts.SaveChanges();
        }
    }
}