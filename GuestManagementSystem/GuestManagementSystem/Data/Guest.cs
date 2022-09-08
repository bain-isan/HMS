using GuestManagementSystem.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestManagementSystem.Models
{
    [Table("Guest")]
    public class Guest : GuestAbstract
    {
        public int Id { get; set; }
    }
}
