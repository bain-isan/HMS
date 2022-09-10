using InventoryManagementSystem.Data;
using System.Linq;
using System.Collections.Generic;
using InventoryManagementSystem.Models.Repositories;

namespace InventoryManagementSystem.Models.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public Inventory AddInventory(OperationOnInventory opInventory)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == opInventory.RoomNumber);
            var inventory = new Inventory
            {
                InventoryCode = opInventory.InventoryCode,
                InventoryName = opInventory.InventoryName,
                Room = room
            };

            try
            {
                _context.Inventorys.Add(inventory);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }
            
            return inventory;
        }

        public Inventory UpdateInventory(OperationOnInventory opInventory, int code)
        {
            var inventory = _context.Inventorys.FirstOrDefault(x => x.InventoryCode == code);
            if(inventory != null)
            {
                var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == opInventory.RoomNumber);
                if(room != null)
                {
                    inventory = new Inventory
                    {
                        Id = inventory.Id,
                        InventoryCode = opInventory.InventoryCode,
                        InventoryName = opInventory.InventoryName,
                        Room = room
                };

                    _context.SaveChanges();
                }
            }
            
            return inventory;
        }

        public Inventory DeleteInventory(int number)
        {
            var inventory = _context.Inventorys.FirstOrDefault(x => x.InventoryCode == number);
            if(inventory != null)
            {
                _context.Inventorys.Remove(inventory);
                _context.SaveChanges();
            }
            return inventory;
        }

        public Inventory GetInventoryByNumber(int? number)
        {
            var inventory = _context.Inventorys.FirstOrDefault(x => x.InventoryCode == number);
            return inventory;
        }

        public List<Inventory> GetAllInventorys()
        {
            return _context.Inventorys.ToList();
        }

        public UniqueError UniqueCheck(OperationOnInventory opInventory)
        {
            foreach (var check in GetAllInventorys())
            {
                if (check.InventoryCode == opInventory.InventoryCode)
                {
                    return UniqueError.InventoryNumberExists;
                }

                return this.RoomCheck(opInventory);

                
                                
            }
            return UniqueError.None;
        }

        public string UniqueCheckMsg(UniqueError err)
        {
            switch (err)
            {
                case UniqueError.None:              return  "Fields are Unique";

                case UniqueError.InventoryNumberExists:  return "Inventory Number Already Exists...";

                case UniqueError.RoomNotExist: return "Room Not Exists...";

                default: return "Something Went Wrong...";
            }
        }

        public bool IsUnique(UniqueError err)
        {
            if(err == UniqueError.InventoryNumberExists || err == UniqueError.RoomNotExist)
                return false;
            return true;
        }

        public UniqueError RoomCheck(OperationOnInventory opInventory)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.RoomNumber == opInventory.RoomNumber);
            if (room == null)
            {
                return UniqueError.RoomNotExist;
            }
            return UniqueError.None;
        }
    }

    public enum UniqueError
    {
        None,
        InventoryNumberExists,
        RoomNotExist
    }
}
