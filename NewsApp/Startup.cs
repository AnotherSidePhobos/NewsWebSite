using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsApp.Domain;
using NewsApp.Domain.Repositories.Abstract;
using NewsApp.Domain.Repositories.EntityFrameWork;
using NewsApp.Models;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public Startup(IConfiguration configuration/*, ApplicationDbContext db, SignInManager<ApplicationUser> signInManager*/)
        {
            Configuration = configuration;
            //_db = db;
            //_signInManager = signInManager;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IServiceFB, ServiceFB>();
            services.AddTransient<SendingEmail>();
            services.AddTransient<IArticleItemRepository, ArticleItemRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITextFieldsRepository, TextFieldsRepository>();
            services.AddTransient<DataManager>();
            //services.AddTransient<NewsApp.Domain.Repositories.Abstract.IUserRepository, NewsApp.Domain.Repositories.EntityFrameWork.UserRepository>();
            services.AddDbContext<ApplicationDbContext>(s => s.UseSqlServer(Config.ConnectionString));
            services.AddControllersWithViews();
            services.AddPaging();


            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "News";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            Configuration.Bind("Project", new Config());

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
                // мы добавляем политику с название: AdminArea
                // и тем самым требуем от пользователя, чтобы у него была роль admin.
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();



            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //if (_signInManager.Context.User.Identity.IsAuthenticated)
                //{
                //    var NameOfuser = _signInManager.Context.User.Identity.Name;
                //    var currentUser = _db.Users.Where(n => n.UserName == NameOfuser).FirstOrDefault();
                //}
                

                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}