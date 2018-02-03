using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }
    }
}