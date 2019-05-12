using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Member16yo]
        public DateTime BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Range(1, 4)]
        [MembershipOver18Only]
        public byte MembershipTypeId { get; set; }
    }
}