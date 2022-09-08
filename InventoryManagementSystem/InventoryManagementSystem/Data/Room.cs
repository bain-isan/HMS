using InventoryManagementSystem.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    [Table("Room")]
    public class Room : RoomAbstract
    {
        public int Id { get; set; }
    }
}
