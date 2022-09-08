using RoomManagementSystem.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomManagementSystem.Models
{
    [Table("Room")]
    public class Room : RoomAbstract
    {
        public int Id { get; set; }
    }
}
