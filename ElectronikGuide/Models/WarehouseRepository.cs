using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronikGuide.Interface;

namespace ElectronikGuide.Models
{
    public class WarehouseRepository : IWarehouseRepository
    {
        //public List<WarehouseEntry> _warehouseEntry;//= new List<WarehouseEntry>();
        public List<WarehouseEntry> warehouse = new ()
        {
            new WarehouseEntry {ProductId = 1 ,Quantity=30 },
            new WarehouseEntry {ProductId = 2 ,Quantity=30 },
            new WarehouseEntry {ProductId = 3 ,Quantity=40 }
        };

        public List<WarehouseEntry> Products => warehouse;
        public List<WarehouseEntry> GetProducts()
        {

            //throw new NotImplementedException();
            return Products;
        }
        

    }
    //public internal class MemoryRepository
    //{
    //    public MemoryRepository()
    //    {
    //    }
    //}
}
