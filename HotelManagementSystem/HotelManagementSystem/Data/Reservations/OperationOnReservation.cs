using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Data.Reservations
{
    public class OperationOnReservation : ReservationAbstract
    {
        public int Id { get; set; }
        [Required]
        public int GuestMemberCode { get; set; }

        [Required]
        public int RoomNumber { get; set; }
    }
}
