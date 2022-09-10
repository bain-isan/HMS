using Microsoft.EntityFrameworkCore;
using ReservationManagementSystem.Data;
using System.Collections.Generic;

namespace ReservationManagementSystem.Models.Repositories
{
    public interface IReservationRepository
    {
        Reservation AddReservation(OperationOnReservation opReservation);

        Reservation UpdateReservation(OperationOnReservation opReservation, int id);

        Reservation GetReservationById(int? id);

        List<Reservation> GetAllReservations();

        List<Room> SearchEmptyRoom();

        UniqueError UniqueCheck(OperationOnReservation opReservation);
        string UniqueCheckMsg(UniqueError err);
        bool IsUnique(UniqueError err);
    }
}
