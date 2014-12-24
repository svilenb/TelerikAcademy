namespace ForumSystem.Web.ViewModels.PageableFeedbackList
{
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class FeedbackDisplayViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Feedback, FeedbackDisplayViewModel>()
                  .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                  .ReverseMap();
        }
    }
}