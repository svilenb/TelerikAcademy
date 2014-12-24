namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using ForumSystem.Web.ViewModels.PageableFeedbackList;

    public class PageableFeedbackListController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        public ActionResult List(int? id)
        {
            int pageNumber = new int();

            if (id == null)
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = id.Value;
            }

            var allFeedbacks = this.feedbacks.All().Project().To<FeedbackDisplayViewModel>().ToList();
            var viewModel = allFeedbacks.Skip((pageNumber - 1) * 4).Take(4);
            ViewBag.Pages = Math.Ceiling((double)allFeedbacks.Count() / 4);
            ViewBag.CurrentPage = pageNumber;

            return View(viewModel);
        }
    }
}