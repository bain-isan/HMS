using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Rooms
{
    [Table("Room")]
    public class Room : RoomAbstract
    {
        public int Id { get; set; }
    }
}
