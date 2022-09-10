using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HotelManagementSystem.Data.Rooms
{
    public abstract class RoomAbstract
    {
        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int RoomFloor { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public int MaxPersonAllowed { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
