using InventoryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InventoryManagementSystem.Models.Repositories
{
    public interface IInventoryRepository
    {
        Inventory AddInventory(OperationOnInventory opInventory);

        Inventory UpdateInventory(OperationOnInventory opInventory, int number);

        Inventory DeleteInventory(int number);

        Inventory GetInventoryByNumber(int? number);

        List<Inventory> GetAllInventorys();

        UniqueError UniqueCheck(OperationOnInventory opInventory);
        string UniqueCheckMsg(UniqueError err);
        bool IsUnique(UniqueError err);
    }
}
