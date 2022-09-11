
using HotelManagementSystem.Data.Guests;
using HotelManagementSystem.Data.Rooms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Reservations
{
    public class Reservation : ReservationAbstract
    {
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [ForeignKey("GuestId")]
        public Room Room { get; set; }

        [ForeignKey("RoomId")]
        public Guest Guest { get; set; }
    }
}
