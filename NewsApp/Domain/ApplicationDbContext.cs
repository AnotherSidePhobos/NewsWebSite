using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ArticleItem> ArticleItems { get; set; }
        public DbSet<TextField> TextFields { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
        //        Name = "admin",
        //        NormalizedName = "ADMIN"
        //    });

        //    modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        //    {
        //        Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
        //        UserName = "admin",
        //        NormalizedUserName = "ADMIN",
        //        Email = "my@email.com",
        //        NormalizedEmail = "MY@EMAIL.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
        //        SecurityStamp = string.Empty
        //    });

        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
        //        UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
        //    });

        //    modelBuilder.Entity<TextField>().HasData(new TextField
        //    {
        //        Id = 1,
        //        CodeWord = "PageIndex",
        //        Title = "Главная"
        //    });
        //    modelBuilder.Entity<TextField>().HasData(new TextField
        //    {
        //        Id = 2,
        //        CodeWord = "PageServices",
        //        Title = "Статьи"
        //    });
        //    modelBuilder.Entity<TextField>().HasData(new TextField
        //    {
        //        Id = 3,
        //        CodeWord = "PageContacts",
        //        Title = "Контакты"
        //    });
        //}

    }
}
