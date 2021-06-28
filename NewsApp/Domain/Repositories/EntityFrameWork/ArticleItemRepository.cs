using NewsApp.Domain.Entities;
using NewsApp.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Repositories.EntityFrameWork
{
    public class ArticleItemRepository : IArticleItemRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticleItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<ArticleItem> GetAllArticleItems()
        {
            return (_db.ArticleItems);
        }
        public void DeleteArticle(int id)
        {
            var arct = _db.ArticleItems.Where(i => i.Id == id).FirstOrDefault();
            _db.ArticleItems.Remove(arct);
            _db.SaveChanges();
        }
        public ArticleItem GetArticleById(int id)
        {
            return _db.ArticleItems.Where(i => i.Id == id).FirstOrDefault();
        }
        public void SaveArticle(ArticleItem article)
        {
            _db.ArticleItems.Add(article);
            _db.SaveChanges();
        }
        public void UpdateArticle(int id)
        {
            var arct = _db.ArticleItems.Where(i => i.Id == id).FirstOrDefault();
            _db.ArticleItems.Update(arct);
            _db.SaveChanges();
        }
    }
}