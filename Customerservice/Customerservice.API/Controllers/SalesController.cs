using Customerservice.API.Models.SalesFoldr;
using Customerservice.Framework.Entites;
using Customerservice.Framework.Repositories;
using Customerservice.Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customerservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesServices _salesServices;
        public SalesController(ISalesServices salesServices)
        {
            _salesServices = salesServices;  
        }

        [HttpPost("Create-Sales")]

        public IActionResult CreateSales([FromBody]CreateSalesModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var data = new Sales
            {
                CustomerId = model.CustomerId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,

            };
            _salesServices.CreateSales(data);

            return Ok("Sales created successfully");
        }
        [HttpGet("ListOf-AllSells")]
        public IActionResult GetAllSell()
        {
            var data=_salesServices.GetAllSales().Select(s => new SaleDto
            {
                Id = s.Id,
                ProductName = s.Product.Name,
                TotalAmount = s.TotalPrice,
                CustomerName = s.Customer.Name
            }).ToList(); 
            return Ok(data);    
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
        [FromQuery] int customerId,
        [FromQuery] int productId,
        [FromQuery] DateTime dateTime)
        {
            var data = _salesServices.SalesFilter(dateTime, customerId, productId);

            return Ok(data);
        }

    }
}
