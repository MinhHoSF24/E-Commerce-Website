using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "The name of customer cannot greater than 250 chars!")]
        [StringLength(250)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(500)]
        public string Address { get; set; }
        public int TypePayment { get; set; }
    }
}