using ReservationManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationManagementSystem.Data
{
    public class ReservationAbstract
    {
                
        public int NumberOfChild { get; set; }

        [Required]
        public int NumberOfAdults { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CheckOut { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int NumberOfNight { get; set; }

        
    }
}
