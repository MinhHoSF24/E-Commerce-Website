using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Order")]
    public class Order: CommonAbstract
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();

        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "The name of customer cannot greater than 250 chars!")]
        [StringLength(250)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(500)]
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int TypePayment { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}