using RoomManagementSystem.Data;
using System.Linq;
using System.Collections.Generic;

namespace RoomManagementSystem.Models.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private RoomDbContext _context;

        public RoomRepository(RoomDbContext context)
        {
            _context = context;
        }
        public Room AddRoom(OperationOnRoom opRoom)
        {
            var room = new Room
            {
                RoomNumber = opRoom.RoomNumber,
                RoomFloor = opRoom.RoomFloor,
                RoomType = opRoom.RoomType,
                MaxPersonAllowed = opRoom.MaxPersonAllowed,
                Price = opRoom.Price
            };

            try
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }
            
            return room;
        }

        public Room UpdateRoom(OperationOnRoom opRoom, int number)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == number);
            if(room != null)
            {
                room = new Room
                {
                    Id = room.Id,
                    RoomNumber = opRoom.RoomNumber,
                    RoomFloor= opRoom.RoomFloor,
                    RoomType= opRoom.RoomType,
                    MaxPersonAllowed = opRoom.MaxPersonAllowed,
                    Price= opRoom.Price
                };

                _context.SaveChanges();
            }
            
            return room;
        }

        public Room DeleteRoom(int number)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == number);
            if(room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
            return room;
        }

        public Room GetRoomByNumber(int? number)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == number);
            return room;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public UniqueError UniqueCheck(OperationOnRoom opRoom)
        {
            foreach (var check in GetAllRooms())
            {
                if (check.RoomNumber == opRoom.RoomNumber)
                {
                    return UniqueError.RoomNumberExists;
                }
                                
            }
            return UniqueError.None;
        }

        public string UniqueCheckMsg(UniqueError err)
        {
            switch (err)
            {
                case UniqueError.None:              return  "Fields are Unique";

                case UniqueError.RoomNumberExists:  return "Room Number Already Exists...";

                default: return "Something Went Wrong...";
            }
        }

        public bool IsUnique(UniqueError err)
        {
            if(err == UniqueError.RoomNumberExists)
                return false;
            return true;
        }

        
    }

    public enum UniqueError
    {
        None,
        RoomNumberExists
    }
}
