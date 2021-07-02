using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByName(string name);
        void SaveUser(ApplicationUser user);

        //Task UpdateUserDisaplyName(string userId, string displayName);
    }
}
