using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApp.Domain;
using NewsApp.Domain.Entities;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly ApplicationDbContext _db;

        public HomeController(DataManager dataManager, ApplicationDbContext db)
        {
            this.dataManager = dataManager;
            _db = db;
        }


        //public IActionResult Index()
        //{
        //    var articles = dataManager.articleItemRepository.GetAllArticleItems();

        //    return View(articles);
        //}

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            return View(await PaginatedList<ArticleItem>.CreatAsync(_db.ArticleItems, pageNumber, 2));
        }

        [HttpPost]
        public IActionResult Index(ArticleItem model)
        {
            var articles = dataManager.articleItemRepository.GetAllArticleItems();

            return View(articles);
        }

        public IActionResult ShowArctcle(int Id)
        {
            var arct =  dataManager.articleItemRepository.GetArticleById(Id);
            return View(arct);
        }
        public IActionResult Contacts()
        {
            var contact = dataManager.textFieldsRepository.GetTextFieldByCodeWord("PageContacts");
            return View(contact);
        }
    }
}