using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HotelManagementSystem.Data.Reservations
{
    public class ReservationModel
    {
        public int Number { get; set; }
        public OperationOnReservation Reservation { get; set; }
    }
}
