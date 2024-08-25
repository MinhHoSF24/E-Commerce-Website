using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_News")]
    public class News: CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name cannot be empty!")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Details { get; set; }
        public string SellTitle { get; set; }
        public string SellDescription { get; set; }
        public string SellKeyWords { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
    }
}