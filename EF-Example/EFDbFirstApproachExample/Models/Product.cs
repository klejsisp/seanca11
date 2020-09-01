using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EFDbFirstApproachExample.Custom_Validation;


namespace EFDbFirstApproachExample.Models
{
    public class Product
    {   [Key]
      [Display(Name ="Product Id")]
        public int ProductID { get; set; }


        [Display(Name = "Pershkrimi")]
        public string pershkrim { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Emri i produktit sduhet te jete bosh")]
       [MaxLength(20)]
       [MinLength(4)]
        public string ProductName { get; set; }


        [Display(Name = "Product Price")]
        [Required (ErrorMessage ="Duhet te vendosni cmimin !")]
        [Validimklas(ErrorMessage = "Cmimi duhet te jete i pjesetueshem me 10")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date of Purchase")]
        [DataType(DataType.Date)]
        [Validimdate(ErrorMessage = "Data nuk duhet te jete me e vogel se data e sotme !")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }


        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "Duhet te plotesoni statusin !")]

        public string AvailabilityStatus { get; set; }
        [Required(ErrorMessage = "Duhet te vendosni kategorine !")]
        public Nullable<long> CategoryID { get; set; }
        [Required(ErrorMessage = "Duhet te vendosni brandin !")]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
   
        
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}