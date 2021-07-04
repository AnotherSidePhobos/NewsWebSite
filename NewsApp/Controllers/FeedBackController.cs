using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain;
using NewsApp.Models;
using NewsApp.Models.ViewModals;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Controllers
{
    [Route("FeedBack")]
    [ApiController]
    public class FeedBackController : Controller
    {
        private readonly IServiceFB _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SendingEmail _sendingEmail;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        public FeedBackController(IServiceFB service, IHttpContextAccessor httpContextAccessor, SendingEmail sendingEmail, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _sendingEmail = sendingEmail;
            _signInManager = signInManager;
            _db = db;
        }
        [HttpPost]
        [Route("SaveFeedBack")]
        public void SaveFeedBack(FeedBackVM data)
        {

            var user = _db.Users.Where(n => n.UserName == _signInManager.Context.User.Identity.Name).Select(s => s.Email);
            string email = "";
            foreach (var item in user)
            {
                email += item;
            }
            //string em = email
            _service.AddFeedBack(data);
            _sendingEmail.SendEmailAboutFeedBack(data, email);

        }
    }
}
