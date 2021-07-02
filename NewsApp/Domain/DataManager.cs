using NewsApp.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain
{
    public class DataManager
    {
        public IArticleItemRepository articleItemRepository;
        public ITextFieldsRepository textFieldsRepository;
        public IUserRepository userRepository;
        public DataManager(IArticleItemRepository articleItemRepository,
           ITextFieldsRepository textFieldsRepository, IUserRepository userRepository)
        {
            this.articleItemRepository = articleItemRepository;
            this.textFieldsRepository = textFieldsRepository;
            this.userRepository = userRepository;
        }
    }
}
