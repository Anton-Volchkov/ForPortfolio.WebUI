using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForPortfolio.WebUI.Validation
{
    public class CommentValidation
    {

        [Required(ErrorMessage = "Вы не оставили свой вопрос!")]
        public string Text { get; set; }
      
    }
}
