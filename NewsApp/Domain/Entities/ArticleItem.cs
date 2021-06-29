using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Domain.Entities
{
    public class ArticleItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название статьи")]
        [Display(Name = "Название статьи")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание заголовка")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание статьи")]
        public override string FullText { get; set; }
        [Display(Name = "Краткое описание статьи")]
        public string ShortText { get; set; }
    }
}
