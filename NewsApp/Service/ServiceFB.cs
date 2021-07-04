using NewsApp.Domain;
using NewsApp.Models;
using NewsApp.Models.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public class ServiceFB : IServiceFB
    {
        private readonly ApplicationDbContext _db;

        public ServiceFB(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddFeedBack(FeedBackVM model)
        {
            FeedBack feedBack = new FeedBack()
            {
                Comment = model.Comment,
                Author = model.Author,
                //Date = model.Date
            };
            _db.FeedBacks.Add(feedBack);
            _db.SaveChanges();
        }
    }
}
