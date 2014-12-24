namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Web.InputModels.Feedback;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using ForumSystem.Data.Models;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Web.Infrastructure;

    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        private readonly ISanitizer sanitizer;

        public FeedbackController(IDeletableEntityRepository<Feedback> feedbacks, ISanitizer sanitizer)
        {
            this.feedbacks = feedbacks;
            this.sanitizer = sanitizer;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateInputViewModel();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInputViewModel input)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var feedback = new Feedback
                {
                    Title = input.Title,
                    Content = this.sanitizer.Sanitize(input.Content),
                    AuthorId = userId
                };

                this.feedbacks.Add(feedback);
                this.feedbacks.SaveChanges();
               return this.RedirectToAction("Index", "Home");
            }

            return this.View(input);
        }
    }
}