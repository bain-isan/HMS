using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RoomManagementSystem.Models.Repositories
{
    public interface IRoomRepository
    {
        Room AddRoom(OperationOnRoom opRoom);

        Room UpdateRoom(OperationOnRoom opRoom, int number);

        Room DeleteRoom(int number);

        Room GetRoomByNumber(int? number);

        List<Room> GetAllRooms();

        UniqueError UniqueCheck(OperationOnRoom opRoom);
        string UniqueCheckMsg(UniqueError err);
        bool IsUnique(UniqueError err);
    }
}
