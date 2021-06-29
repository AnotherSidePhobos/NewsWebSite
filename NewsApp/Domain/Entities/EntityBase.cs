using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            DateAdded = DateTime.Now;
        }
        [Required]
        public int Id { get; set; }
        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }
        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }
        [Display(Name = "Текст статьи")]
        public virtual string FullText { get; set; }
        [Display(Name = "Краткий Текст статьи")]
        [MaxLength(100)]
        public string ShortText { get; set; }
        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }
        [Display(Name = "Автор")]
        public virtual string Author { get; set; }
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}