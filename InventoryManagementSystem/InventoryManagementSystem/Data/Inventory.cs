using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Data
{
    [Table("Inventory")]
    public class Inventory : InventoryAbstract
    {
        public int Id { get; set; }
    }
}
