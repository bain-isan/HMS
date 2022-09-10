using InventoryManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Data
{
    public class InventoryAbstract
    {
        [Required]
        public int InventoryCode { get; set; }

        [Required]
        public string InventoryName { get; set; }

        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        
    }
}
