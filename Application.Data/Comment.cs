using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string Answer { get; set; }        
        public bool Ispublish { get; set; }
    }
}
