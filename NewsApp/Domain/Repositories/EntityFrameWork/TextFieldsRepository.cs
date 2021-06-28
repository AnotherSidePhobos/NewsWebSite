using NewsApp.Domain.Entities;
using NewsApp.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Repositories.EntityFrameWork
{
    public class TextFieldsRepository : ITextFieldsRepository
    {
        private readonly ApplicationDbContext _db;
        public TextFieldsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void DeleteTextField(int id)
        {
            var item = GetAllTextFields().Where(i => i.Id == id).FirstOrDefault();
            _db.TextFields.Remove(item);
            _db.SaveChanges();
        }

        public IQueryable<TextField> GetAllTextFields()
        {
            return (_db.TextFields);
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
           return GetAllTextFields().Where(c => c.CodeWord == codeWord).FirstOrDefault();
        }

        public TextField GetTextFieldById(int id)
        {
            return GetAllTextFields().Where(i => i.Id == id).FirstOrDefault();
        }

        public void SaveTextField(TextField entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }
    }
}
