using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApp.Domain;
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

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        public IActionResult Index()
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