namespace ForumSystem.Web.ViewModels.Home
{
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorName { get; set; }

        public ICollection<IndexTagViewModel> Tags { get; set; }

        public ICollection<IndexVoteViewModel> Votes { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                   .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                   .ReverseMap();
        }
    }
}