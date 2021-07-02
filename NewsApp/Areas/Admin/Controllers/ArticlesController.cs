using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain;
using NewsApp.Domain.Entities;
using NewsApp.Models;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {

        private readonly DataManager _dataManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ArticlesController(DataManager dataManager, IWebHostEnvironment hostEnvironment, SignInManager<ApplicationUser> signInManager)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
            _signInManager = signInManager;
        }
        public IActionResult Edit(int id)
        {
            var entity = id == default ? new ArticleItem() : _dataManager.articleItemRepository.GetArticleById(id);
            entity.DateAdded = DateTime.Now;
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(ArticleItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {

                    model.TitleImagePath = "/images/" + titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                if (_signInManager.IsSignedIn(User))
                {
                    model.Author = User.Identity.Name;
                }
                if (model.FullText.Length > 99)
                {
                    model.ShortText = model.FullText.Substring(0, 100) + "...";
                }
                _dataManager.articleItemRepository.SaveArticle(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _dataManager.articleItemRepository.DeleteArticle(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
