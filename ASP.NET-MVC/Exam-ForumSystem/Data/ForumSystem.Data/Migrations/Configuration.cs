namespace ForumSystem.Data.Migrations
{
    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private IRandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedTags(context);
            this.SeedPosts(context);
        }

        private void SeedTags(ApplicationDbContext context)
        {
            if (context.Tags.Any())
            {
                return;
            }

            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag()
            {
                Name = "MVC"
            });
            tags.Add(new Tag()
            {
                Name = "Web Forms"
            });
            tags.Add(new Tag()
            {
                Name = "data structures and algorithms"
            });
            tags.Add(new Tag()
            {
                Name = "databases"
            });
            tags.Add(new Tag()
            {
                Name = "nodejs coolness"
            });
            tags.Add(new Tag()
            {
                Name = "java applications"
            });
            tags.Add(new Tag()
            {
                Name = "csharp applications"
            }); 
            tags.Add(new Tag()
            {
                Name = "windows forms"
            });
            tags.Add(new Tag()
            {
                Name = "javascipt"
            }); 
            tags.Add(new Tag()
            {
                Name = "PHP with laravel"
            });
            tags.Add(new Tag()
            {
                Name = "Kendo UI for mvc"
            });

            context.Tags.AddOrUpdate(tags.ToArray());
        }

        private void SeedPosts(ApplicationDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            ApplicationUser user = new ApplicationUser() { UserName = "Anonimous" };

            List<Post> posts = new List<Post>();

            for (int i = 0; i < 10; i++)
            {
                var post = new Post()
                {
                    Title = this.random.RandomString(5, 40),
                    Content = this.random.RandomString(20, 200),
                    Author = user,
                };

                int numberOfTags = this.random.RandomNumber(3, 6);
                for (int j = 0; j < numberOfTags; j++)
                {
                    var tag = new Tag()
                    {
                        Name = this.random.RandomString(5, 40)
                    };

                    post.Tags.Add(tag);
                }

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }
    }
}
