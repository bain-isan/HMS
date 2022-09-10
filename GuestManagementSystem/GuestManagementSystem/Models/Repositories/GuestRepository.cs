using GuestManagementSystem.Data;
using System.Linq;
using System.Collections.Generic;

namespace GuestManagementSystem.Models.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private GuestDbContext _context;

        public GuestRepository(GuestDbContext context)
        {
            _context = context;
        }
        public Guest AddGuest(OperationOnGuest opGuest)
        {
            var guest = new Guest
            {
                Name = opGuest.Name,

                MemberCode = opGuest.MemberCode,
                PhoneNumber = opGuest.PhoneNumber,
                Email = opGuest.Email,
                Gender = opGuest.Gender,
                Address = opGuest.Address
            };

            try
            {
                _context.Guests.Add(guest);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }
            
            return guest;
        }

        public Guest UpdateGuest(OperationOnGuest opGuest, int code)
        {
            var guest = _context.Guests.FirstOrDefault(x => x.MemberCode == code);
            if(guest != null)
            {
                guest = new Guest
                {
                    Id = guest.Id,
                    Name = opGuest.Name,
                    MemberCode = opGuest.MemberCode,
                    PhoneNumber = opGuest.PhoneNumber,
                    Email = opGuest.Email,
                    Gender = opGuest.Gender,
                    Address = opGuest.Address
                };

                _context.SaveChanges();
            }
            
            return guest;
        }

        public Guest DeleteGuest(int code)
        {
            var guest = _context.Guests.FirstOrDefault(x => x.MemberCode == code);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
            }
            return guest;
        }

        public Guest GetGuestById(int? code)
        {
            var guest = _context.Guests.FirstOrDefault(x => x.MemberCode == code);
            return guest;
        }

        public List<Guest> GetAllGuests()
        {
            return _context.Guests.ToList();
        }

        public UniqueError UniqueCheck(OperationOnGuest opGuest)
        {
            foreach (var check in GetAllGuests())
            {
                if (check.MemberCode == opGuest.MemberCode)
                {
                    return UniqueError.MemberCodeExists;
                }
                else if (check.PhoneNumber.Contains(opGuest.PhoneNumber))
                {
                    return UniqueError.PhoneNumberExists;
                }
                else if (check.Email.Contains(opGuest.Email))
                {
                    return UniqueError.EmailExists;
                }
                                
            }
            return UniqueError.None;
        }

        public string UniqueCheckMsg(UniqueError err)
        {
            switch (err)
            {
                case UniqueError.None:              return  "All Fields are Unique";

                case UniqueError.PhoneNumberExists: return "Phone Number Already Exists...";

                case UniqueError.EmailExists:       return "Email Already Exists...";

                case UniqueError.MemberCodeExists:  return "MemberCode Already Exists...";

                default: return "Something Went Wrong...";
            }
        }

        public bool IsUnique(UniqueError err)
        {
            if(err == UniqueError.EmailExists || err == UniqueError.MemberCodeExists || err == UniqueError.PhoneNumberExists)
                return false;
            return true;
        }
    }

    public enum UniqueError
    {
        None,
        PhoneNumberExists,
        EmailExists,
        MemberCodeExists
    }
}
