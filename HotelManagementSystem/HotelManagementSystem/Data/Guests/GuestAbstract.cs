using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Guests
{
    public abstract class GuestAbstract
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int MemberCode { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [MaxLength(10, ErrorMessage = "Maximum Number Allowed is 10")]
        [MinLength(10, ErrorMessage = "Minimum Number Allowed is 10")]
        
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
