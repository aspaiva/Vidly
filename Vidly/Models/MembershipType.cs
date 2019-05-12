using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Membership")]
        public string Name { get; set; }

        public static readonly byte NaoInformado = 0;
        public static readonly byte Normal = 1;
    }
}