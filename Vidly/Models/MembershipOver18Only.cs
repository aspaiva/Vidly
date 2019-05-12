using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.DTO;

namespace Vidly.Models
{
    public class MembershipOver18Only: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var cust = (Customer)validationContext.ObjectInstance;

            if (cust.BirthDate == null)
                return new ValidationResult("Data de nascimento precisa ser informada");

            if (cust.MembershipTypeId == MembershipType.NaoInformado || cust.MembershipTypeId == MembershipType.Normal)
                return ValidationResult.Success;

            int age = DateTime.Today.Year - cust.BirthDate.Year;

            if (age < 18 && cust.MembershipTypeId > 1)
                return new ValidationResult("Para ser membro regular tem que ser maior de 18");
            else
                return ValidationResult.Success;
        }
    }
}