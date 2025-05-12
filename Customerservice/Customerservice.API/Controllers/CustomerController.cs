using Customerservice.API.Models.CustomerFold;
using Customerservice.API.Models.ProductFold;
using Customerservice.Framework.Entites;
using Customerservice.Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customerservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;
        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }

        [HttpPost("Create-Customer")]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var data = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
            };
            _services.AddCustomer(data);
            return Ok("Customer created successfully");
        }

        [HttpPost("{id}/Update-customer")]
        public IActionResult UpdatePrduct(int id, [FromBody] UpdateCustomerModel model)
        {
            if (model.Id != id)
            {
                return BadRequest("Id is not matched");
            }

            var data = _services.GetById(id);
            if (data == null)
            {
                return NotFound("No data found related to customer");
            }

            data.Name = model.Name;
            data.Email = model.Email;
            data.Phone = model.Phone;

            _services.UpdateCustomer(data);

            return Ok("Customer updated successfully");
        }


        [HttpDelete("Delete-Customer")]
        public IActionResult DeleteCustomer(int id)
        {
            var delete = _services.GetById(id);
            if (delete == null)
            {
                return NotFound("No customer   found");
            }
            _services.RemoveCustomer(id);

            return Ok("Customer deleted successfully");
        }

        [HttpGet("GetAll-Customer")]
        public IActionResult GetAllCustomer()
        {
            var data = _services.GetAllCustomer();
            if (data == null)
            {
                return BadRequest();
            }
            var model = new List<CustomerModel>();
            foreach (var item in data)
            {
                model.Add(new CustomerModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                });
            }
            return Ok(model);
        }

        [HttpGet("{id}")]

        public IActionResult TotalPurchaseByCustomer(int id)
        {
            var total=_services.GetTotalPurchaseByCustomer(id);
            return Ok(total);
        }

    }
}
