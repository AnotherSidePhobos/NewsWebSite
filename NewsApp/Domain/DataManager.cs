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
        public DataManager(IArticleItemRepository articleItemRepository,
           ITextFieldsRepository textFieldsRepository)
        {
            this.articleItemRepository = articleItemRepository;
            this.textFieldsRepository = textFieldsRepository;
        }
    }
}
