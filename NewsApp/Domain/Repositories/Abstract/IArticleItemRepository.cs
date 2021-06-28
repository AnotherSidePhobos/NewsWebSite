using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Repositories.Abstract
{
    public interface IArticleItemRepository
    {
        IQueryable<ArticleItem> GetAllArticleItems();
        ArticleItem GetArticleById(int id);
        void SaveArticle(ArticleItem article);
        void DeleteArticle(int id);
        void UpdateArticle(int id);
    }
}
