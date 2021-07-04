using NewsApp.Models.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public interface IServiceFB
    {
        void AddFeedBack(FeedBackVM model);
    }
}
