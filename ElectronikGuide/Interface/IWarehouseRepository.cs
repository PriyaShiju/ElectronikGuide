using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronikGuide.Models;

namespace ElectronikGuide.Interface
{
    public interface IWarehouseRepository
    {

         List<WarehouseEntry> Products { get; }

         List<WarehouseEntry> GetProducts();

        //WarehouseEntry ReceiveProduct(int productId, int qty);



    }
    //internal class MemoryRepository
    //{
    //    public MemoryRepository()
    //    {
    //    }
    //}
}
