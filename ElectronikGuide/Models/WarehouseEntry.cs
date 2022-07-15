using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronikGuide.Models
{
    public class WarehouseEntry : WarehouseRepository
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }


    }
}
