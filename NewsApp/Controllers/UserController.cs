using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsApp.Domain;
using NewsApp.Models;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext _db;
        public UserController(DataManager dataManager, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            this.signInManager = signInManager;
            _db = db;
        }
        //public IActionResult Edit(string name)
        //{
        //    var user = _dataManager.userRepository.GetUserByName(name);
            
        //    return View(user);
        //}
        //[HttpPost]
        //public IActionResult Edit(ApplicationUser model, IFormFile titleImageFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (titleImageFile != null)
        //        {
        //            using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "/images/", titleImageFile.FileName), FileMode.Create))
        //            {
        //                titleImageFile.CopyTo(stream);
        //            }
        //        }
        //        _dataManager.userRepository.SaveUser(model);
        //        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        //    }
        //    return View(model);
        //}


        public async Task UpdateUserDisaplyName(string userId, string displayName, string filename)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.UserName = displayName;
                user.ImagePath = "/images/" + filename;
                string DISPNAME = displayName.ToUpper();
                user.NormalizedUserName = DISPNAME;
                await _db.SaveChangesAsync();
            }
        }


        public IActionResult Edit(string name)
        {
            var user = _dataManager.userRepository.GetUserByName(name);

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                {
                    titleImageFile.CopyTo(stream);
                }
                await UpdateUserDisaplyName(user.Id, model.UserName, titleImageFile.FileName);
            }
            signInManager.SignOutAsync();
            return RedirectToAction("End");
        }

        public IActionResult End()
        {

            return View();
        }

    }
}
