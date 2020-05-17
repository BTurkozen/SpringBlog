using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringBlog.ViewModels
{
    public class CommentViewModel
    {
        [Required, StringLength(4000)]
        public string Content { get; set; }

        public int? ParentId { get; set; }
    }
}