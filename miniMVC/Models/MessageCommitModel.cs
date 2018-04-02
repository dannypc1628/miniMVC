using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class MessageCommitModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}