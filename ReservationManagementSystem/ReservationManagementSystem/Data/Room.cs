
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationManagementSystem.Data
{
    [Table("Room")]
    public class Room : RoomAbstract
    {
        public int Id { get; set; }
    }
}
