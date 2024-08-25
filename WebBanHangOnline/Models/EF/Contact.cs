using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Contact")]
    public class Contact: CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name cannot be empty!")]
        [StringLength(150,ErrorMessage = "The length cannot greater than 150 chars!")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "The length cannot greater than 150 chars!")]

        public string Email { get; set; }
        public string Website { get; set; }
        [StringLength(4000)]

        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}