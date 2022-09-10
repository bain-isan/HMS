using ReservationManagementSystem.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationManagementSystem.Models
{
    [Table("Guest")]
    public class Guest : GuestAbstract
    {
        public int Id { get; set; }
    }
}
