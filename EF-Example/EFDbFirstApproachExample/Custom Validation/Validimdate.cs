using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Custom_Validation
{
    public class Validimdate: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var data = Convert.ToDateTime(value);
            if (data< DateTime.Now)
            {
                return new ValidationResult(this.ErrorMessage);
            }
            else
            {
              
              return   ValidationResult.Success;
            }
        }

    }
}