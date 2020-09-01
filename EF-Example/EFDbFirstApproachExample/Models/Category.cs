using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Category
    {   [Key]
        [Display(Name = "Category Id")]
        public long CategoryID { get; set; }
        [Required(ErrorMessage ="Duhet te plotesoni emrin e kategorise !")]
        [StringLength(10, MinimumLength = 4)]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Hapesirat dhe numrat nuk lejohen te vendosen !")]
        public string CategoryName { get; set; }
    }
}