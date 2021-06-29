using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Areas.Admin
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {

            return View(_dataManager.articleItemRepository.GetAllArticleItems());
        }
    }
}