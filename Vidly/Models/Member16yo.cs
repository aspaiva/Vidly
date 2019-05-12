using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.DTO;

namespace Vidly.Models
{
    public class Member16yo: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);  
            CustomerDTO cust = AutoMapper.Mapper.Map<Customer, CustomerDTO>((Customer) validationContext.ObjectInstance);

            TimeSpan ts = DateTime.Today - cust.BirthDate;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);  //Datetime = 01/01/0001, por isto tem que deduzir 1 dia e um ano para ter uma data 00/00/00 como base

            if (idade.Year >= 16)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer have to be at least 16yo");
        }
    }
}