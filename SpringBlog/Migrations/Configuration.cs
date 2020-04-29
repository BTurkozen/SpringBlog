namespace SpringBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SpringBlog.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpringBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpringBlog.Models.ApplicationDbContext context)
        {
            // https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "bk@turkozen.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "bk@turkozen.com",
                    Email = "bk@turkozen.com",
                    DisplayName = "BTurkozen",
                    EmailConfirmed = true
                };

                manager.Create(user, "123Pass");
                manager.AddToRole(user.Id, "Admin");

                #region Seed Categories and Posts
                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category
                    {
                        CategoryName = "Sample Category 1 ",
                        Posts = new List<Post> {
                            new Post {
                        Title = "Sapmle Post 1",
                        AuthorId = user.Id,
                        Content = "<p> In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content</p>",
                        Slug = "sample-post-1",
                        CreateTime = DateTime.Now, // site amerikada ise oranýn saatlerýný gýrecegýz.
                        ModificationTime = DateTime.Now
                    },

                        new Post
                        {
                            Title = "Sapmle Post 2",
                            AuthorId = user.Id,
                            Content = "<p> In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content</p>",
                            Slug = "sample-post-2",
                            CreateTime = DateTime.Now, // site amerikada ise oranýn saatlerýný gýrecegýz.
                            ModificationTime = DateTime.Now
                        }
                        }
                    });
                }
                #endregion
            }
        }
    }
}
