namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNet.Identity;

    using Model = ForumSystem.Data.Models.Post;
    using ViewModel = ForumSystem.Web.Areas.Administration.ViewModel.Posts.PostViewModel;

    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;

    [Authorize]
    public class PostsController : KendoGridAdministrationController
    {
        public PostsController(IDeletableEntityRepository<Post> posts)
        {
            this.Posts = posts;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Posts
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Posts.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            var userId = this.User.Identity.GetUserId();
            dbModel.AuthorId = userId;
            if (dbModel != null)
            {
                model.Id = dbModel.Id;
                model.AuthorName = dbModel.Author.UserName;
                model.CreatedOn = dbModel.CreatedOn;
                model.IsDeleted = dbModel.IsDeleted;
                model.ModifiedOn = dbModel.ModifiedOn;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            model.ModifiedOn = DateTime.Now;
            model.Content = model.Content.Substring(0, 10) + "...";
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var post = this.Posts.GetById(model.Id.Value);

                this.Posts.Delete(post);
                this.Posts.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}