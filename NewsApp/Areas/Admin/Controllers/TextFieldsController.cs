using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain;
using NewsApp.Domain.Entities;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager _dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Edit(string codeWord)
        {
            var field = _dataManager.textFieldsRepository.GetTextFieldByCodeWord(codeWord);
            return View(field);
        }
        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.textFieldsRepository.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
