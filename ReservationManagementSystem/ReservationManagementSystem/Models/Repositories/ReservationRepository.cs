using ReservationManagementSystem.Data;
using System.Linq;
using System.Collections.Generic;

namespace ReservationManagementSystem.Models.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private ReservationDbContext _context;

        public ReservationRepository(ReservationDbContext context)
        {
            _context = context;
        }
        public Reservation AddReservation(OperationOnReservation opReservation)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == opReservation.RoomNumber);
            var guest = _context.Guests.FirstOrDefault(x => x.MemberCode == opReservation.GuestMemberCode);
            var reservation = new Reservation
            {
                GuestId = guest.Id,
                RoomId = room.Id,
                Guest = guest,
                Room = room,
                NumberOfChild = opReservation.NumberOfChild,
                NumberOfAdults = opReservation.NumberOfAdults,
                CheckIn = opReservation.CheckIn,
                CheckOut = opReservation.CheckOut,
                Status = opReservation.Status,
                NumberOfNight = opReservation.NumberOfNight
            };

            try
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }
            
            return reservation;
        }

        public Reservation UpdateReservation(OperationOnReservation opReservation, int id)
        {
            var reservation = _context.Reservations.Find(id);
            if(reservation != null)
            {

                reservation = new Reservation
                {
                    Id = reservation.Id,
                    Guest = reservation.Guest,
                    Room = reservation.Room,
                    NumberOfChild = opReservation.NumberOfChild,
                    NumberOfAdults = opReservation.NumberOfAdults,
                    CheckIn = opReservation.CheckIn,
                    CheckOut = opReservation.CheckOut,
                    Status = opReservation.Status,
                    NumberOfNight = opReservation.NumberOfNight
                };

                _context.SaveChanges();
            }
            
            return reservation;
        }

        

        public Reservation GetReservationById(int? id)
        {
            var Reservation = _context.Reservations.Find(id);
            return Reservation;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public List<Room> SearchEmptyRoom()
        {
            var emptyRoom = new List<Room>();
            var AllRooms = _context.Rooms.ToList();
            foreach(var rooms in AllRooms)
            {
                Reservation reservation = this.GetAllReservations().FirstOrDefault(x => (x.Room.Id == rooms.Id));
                if(reservation == null)
                    emptyRoom.Add(rooms);
            }
            
            return emptyRoom;
        }






        public UniqueError UniqueCheck(OperationOnReservation opReservation)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == opReservation.RoomNumber);
            var guest = _context.Guests.FirstOrDefault(x => x.MemberCode == opReservation.GuestMemberCode);
            if (room == null)
            {
                return UniqueError.RoomNotExists;
            }
            if(guest == null)
            {
                return UniqueError.GuestNotExists;
            }
            room = SearchEmptyRoom().FirstOrDefault(x => x.RoomNumber == opReservation.RoomNumber);
            if (room != null)
            {
                return UniqueError.RoomAlreadyBooked;
            }
                
            return UniqueError.None;
        }

        public string UniqueCheckMsg(UniqueError err)
        {
            switch (err)
            {
                case UniqueError.None:              return  "All Fields are Unique";

                case UniqueError.RoomNotExists:     return "Room Not Exists...";

                case UniqueError.GuestNotExists:    return "Guest NotExists...";

                case UniqueError.RoomAlreadyBooked: return "Room Already Booked";

                default: return "Something Went Wrong...";
            }
        }

        public bool IsUnique(UniqueError err)
        {
            if(err == UniqueError.RoomNotExists || err == UniqueError.GuestNotExists || err == UniqueError.RoomAlreadyBooked)
                return false;
            return true;
        }

        
    }

    public enum UniqueError
    {
        None,
        RoomNotExists,
        GuestNotExists,
        RoomAlreadyBooked
    }
}
