using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Data.Reservations
{
    public class CreateReservation : ReservationAbstract
    {
        [Required]
        public int GuestMemberCode { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
