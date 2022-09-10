using ReservationManagementSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace ReservationManagementSystem.Models
{
    public class OperationOnReservation : ReservationAbstract
    {
        [Required]
        public int GuestMemberCode { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
