using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDbFirstApproachExample.Models
{
    public class Brand
    {     [Key]
        [Display(Name = "Brand Id")]
        public long BrandID { get; set; }

        [Required(ErrorMessage = "Duhet te plotesoni emrin e brandit !")]
        [StringLength(10, MinimumLength = 4)]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Hapesirat dhe numrat nuk lejohen te vendosen !")]
        public string BrandName { get; set; }

    }
}