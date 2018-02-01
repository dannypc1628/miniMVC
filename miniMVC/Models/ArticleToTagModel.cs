using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class ArticleToTagModel
    {
        public int Id { get; set; }
        public int Article_Id { get; set; }
        public int Tag_Id { get; set; }
    }
}