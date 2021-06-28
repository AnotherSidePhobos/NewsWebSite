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
            DateAdded = DateTime.UtcNow;
        }
        [Required]
        public int Id { get; set; }
        [Display(Name = "Название (заголовок)")]
        public virtual string Title { get; set; }
        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }
        [Display(Name = "Текст статьи")]
        public virtual string Article { get; set; }
        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}