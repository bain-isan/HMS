using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Guests
{
    [Table("Guest")]
    public class Guest : GuestAbstract
    {
        public int Id { get; set; }
    }
}
