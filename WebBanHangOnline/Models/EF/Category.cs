using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<News>();

        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name cannot be empty!")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        [StringLength(150)]
        public string SellTitle { get; set; }
        [StringLength(500)]
        public string SellDescription { get; set; }
        [StringLength(150)]
        public string SellKeyWords { get; set; }
        public bool IsActive { get; set; }

        public int Position { get; set; }

        public ICollection<News> News { get; set; }
    }
}