using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GuestManagementSystem.Models.Repositories
{
    public interface IGuestRepository
    {
        Guest AddGuest(OperationOnGuest opGuest);

        Guest UpdateGuest(OperationOnGuest opGuest, int id);

        Guest DeleteGuest(int id);

        Guest GetGuestById(int? id);

        List<Guest> GetAllGuests();

        UniqueError UniqueCheck(OperationOnGuest opGuest);
        string UniqueCheckMsg(UniqueError err);
        bool IsUnique(UniqueError err);
    }
}
