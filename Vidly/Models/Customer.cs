using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth")]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Member16yo]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }


        [Range(1, 4)]
        [MembershipOver18Only]
        public byte MembershipTypeId { get; set; }
    }
}