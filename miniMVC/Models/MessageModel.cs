using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int Member_ID { get; set; }
        public int Artlic_Id { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }

        
    }
}