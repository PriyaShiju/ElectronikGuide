using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronikGuide.Interface;
using ElectronikGuide.Models;

namespace ElectronikGuide.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        
        private readonly IWarehouseRepository _warehouseRepository = new WarehouseRepository();
        //private IRepository repository;
        public WarehouseController(WarehouseRepository warehouseRepository)
        {
           // repository = new MemoryRepository();
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // Return OkObjectResult(IEnumerable<WarehouseEntry>)
        public ActionResult<IEnumerable<WarehouseEntry>> GetProducts()
        {
            // Console.WriteLine("Sample debug output");
            //throw new NotImplementedException();

            return  _warehouseRepository.GetProducts();
        }

        [HttpPut("{productId}/{capacity}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // Return OkResult, BadRequestObjectResult(NotPositiveQuantityMessage), or BadRequestObjectResult(QuantityTooLowMessage)
        public ActionResult<WarehouseEntry> SetProductCapacity(int productId, int capacity)
        {
            //throw new NotImplementedException();
            
            var Product = _warehouseRepository.GetProducts().FirstOrDefault(x => x.ProductId == productId);  //.GetProducts(ProductId);
            if (Product == null)
                return new BadRequestObjectResult("NotPositiveQuantityMessage");
            else if (capacity == 0)
                return new BadRequestObjectResult("QuantityTooLowMessage");
            else
            {
                Product.Quantity = capacity;
                return new OkObjectResult("Product Updated successfully");
            }


        }
        [HttpGet("{productId}/{qty}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // Return OkResult, BadRequestObjectResult(NotPositiveQuantityMessage), or BadRequestObjectResult(QuantityTooHighMessage)
        public ActionResult<WarehouseEntry> ReceiveProduct(int productId, int qty)
        {
            //throw new NotImplementedException();

            var Product = _warehouseRepository.GetProducts().FirstOrDefault(x => x.ProductId == productId);  //.GetProducts(ProductId);

            if (Product == null)
                return new BadRequestObjectResult("NotPositiveQuantityMessage"); //NotPositiveQuantityMessage
            else if (Product.Quantity < qty)
                return new BadRequestObjectResult("QuantityTooHighMessage"); //QuantityTooHighMessage
            else
                return Product;
        }
        [HttpDelete("{productId}/{qty}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // Return OkResult, BadRequestObjectResult(NotPositiveQuantityMessage), or BadRequestObjectResult(QuantityTooHighMessage)
        public ActionResult<WarehouseEntry> DispatchProduct(int productId, int qty)
        {
            //throw new NotImplementedException();
            var Product = _warehouseRepository.GetProducts().FirstOrDefault(x => x.ProductId == productId);  //.GetProducts(ProductId);


            if ((Product == null) || (qty==0))
                return new BadRequestObjectResult("NotPositiveQuantityMessage");
            else if (Product.Quantity < qty )
                return new BadRequestObjectResult("QuantityTooHighMessage");
            else
            {

                Product.Quantity = Product.Quantity - qty;

                return new OkObjectResult("Dispatched successfully");
            }

        }

    }
}
