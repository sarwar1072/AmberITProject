using Customerservice.API.Models.ProductFold;
using Customerservice.Framework.Entites;
using CustomerService.Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customerservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
                _productServices = productServices;
        }


        [HttpPost("CreatePrduct")]
        public IActionResult CreatePrduct([FromBody] ProductModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var data = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };
            _productServices.AddProduct(data);
            return Ok("Product created successfully");
        }

        [HttpPost("{id}/UpdatePrduct")]
        public IActionResult UpdatePrduct(int id,[FromBody] UpdateProductModel model)
        {
            if (model.Id != id)
            {
                return BadRequest("Id is not matched");
            }

            var data = _productServices.GetById(id);
            if (data == null)
            {
                return NotFound("no data found");
            }

            data.Name = model.Name;
            data.Price = model.Price;

            _productServices.UpdateProduct(data);
         
            return Ok("Product updated successfully");
        }


        [HttpDelete("deleteProduct")]
        public IActionResult DeleteById(int id)
        {
            var delete = _productServices.GetById(id);
            if (delete == null)
            {
                return NotFound("Product not found");
            }
            _productServices.Removeproduct(id);
            return Ok("Deleted successfully");
        }


    }
}
