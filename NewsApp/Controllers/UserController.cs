using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        private readonly ILogger<UserController> logger;

        public UserController(DataManager dataManager, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, ILogger<UserController> logger)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            _db = db;
        }

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


        private void Rename(string oldName, string newName)
        {

            try
            {
                System.IO.File.Move(oldName, newName);

                if (System.IO.File.Exists(oldName))
                {
                    System.IO.File.Delete(oldName);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                var nameOfPic = model.UserName;


                var user = await _userManager.FindByIdAsync(model.Id);

                if (titleImageFile != null)
                {
                    using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "images/", nameOfPic + ".jpg"/*titleImageFile.FileName*/), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                else
                {
                    string oldName = "wwwroot/images/" + user.UserName + ".jpg";
                    string newName = "wwwroot/images/" + model.UserName + ".jpg";

                    Rename(oldName, newName);
                }

                await UpdateUserDisaplyName(user.Id, model.UserName, nameOfPic + ".jpg"/* titleImageFile.FileName*/);
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
