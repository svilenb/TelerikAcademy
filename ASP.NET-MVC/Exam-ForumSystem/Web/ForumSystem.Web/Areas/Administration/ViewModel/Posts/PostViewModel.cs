namespace ForumSystem.Web.Areas.Administration.ViewModel.Posts
{
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("String")]
        public string Title { get; set; }

        [Required]
        [DataType("MultiLinetext")]
        [UIHint("MultiLinetext")]
        public string Content { get; set; }

        [UIHint("String")]
        public string AuthorName { get; set; }

        [UIHint("Boolean")]
        public bool IsDeleted { get; set; }

        [UIHint("DateTime")]
        public DateTime CreatedOn { get; set; }

        [UIHint("DateTime")]
        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                 .ForMember(m => m.AuthorName, opt => opt.MapFrom(t => t.Author.UserName))
                 .ForMember(m => m.Title, opt => opt.MapFrom(t => t.Title.Substring(0, 10) + "..."))
                 .ForMember(m => m.Content, opt => opt.MapFrom(t => t.Content.Substring(0, 10) + "..."))
                 .ReverseMap();
        }
    }
}