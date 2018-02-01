using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace miniMVC.Models
{
    public class BoardModel
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "請輸入名稱")]
        public string name { get; set; }

        [Required(ErrorMessage = "請輸入留言訊息")]
        public string message { get; set; }

        [Required]
        public DateTime time { get; set; }
    }
}