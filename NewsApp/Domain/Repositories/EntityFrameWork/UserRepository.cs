using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsApp.Domain.Repositories.Abstract;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Repositories.EntityFrameWork
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public ApplicationUser GetUserByName(string name)
        {
            return _db.Users.Where(i => i.UserName == name).FirstOrDefault();
        }


        //public async Task UpdateUserDisaplyName(string userId, string displayName)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        //    if (user != null)
        //    {
        //        user.UserName = displayName;
        //        user.ImagePath = user.ImagePath;
        //        await _db.SaveChangesAsync();
        //    }
        //}








        public void SaveUser(ApplicationUser user)
        {




            if (user.Id == default)
                _db.Entry(user).State = EntityState.Added;
            else
                _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();


        }
    }
}
