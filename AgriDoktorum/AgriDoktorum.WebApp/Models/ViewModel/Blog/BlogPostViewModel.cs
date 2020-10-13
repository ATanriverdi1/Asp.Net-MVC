using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.ViewModel.Blog
{
    public class BlogPostViewModel
    {
        public int PageCount { get; set; }
        public List<Entity.Blog> GetBlogs { get; set; }
        public int CurrentPage { get; set; }
    }
}