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
            var inventory = new Inventory
            {
                InventoryCode = opInventory.InventoryCode,
                InventoryName = opInventory.InventoryName,
                RoomId = opInventory.RoomId
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
                inventory = new Inventory
                {
                    Id = inventory.Id,
                    InventoryCode = opInventory.InventoryCode,
                    InventoryName = opInventory.InventoryName,
                    RoomId = opInventory.RoomId
                };

                _context.SaveChanges();
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
                                
            }
            return UniqueError.None;
        }

        public string UniqueCheckMsg(UniqueError err)
        {
            switch (err)
            {
                case UniqueError.None:              return  "Fields are Unique";

                case UniqueError.InventoryNumberExists:  return "Inventory Number Already Exists...";

                default: return "Something Went Wrong...";
            }
        }

        public bool IsUnique(UniqueError err)
        {
            if(err == UniqueError.InventoryNumberExists)
                return false;
            return true;
        }

        
    }

    public enum UniqueError
    {
        None,
        InventoryNumberExists
    }
}
