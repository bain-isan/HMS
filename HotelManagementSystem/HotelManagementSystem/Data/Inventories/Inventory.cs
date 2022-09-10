using HotelManagementSystem.Data.Rooms;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Data.Inventories
{
    [Table("Inventory")]
    public class Inventory : InventoryAbstract
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

    }
}
