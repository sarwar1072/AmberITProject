using CustomerServices.MVC.Models.CustomerFold;
using CustomerServices.MVC.Models.ProductFold;
using CustomerServices.MVC.Models.SalesFold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace CustomerServices.MVC.Controllers
{
    public class SaleController : Controller
    {
        private readonly HttpClient _http;

        public SaleController(HttpClient httpClient)
        {
            _http = httpClient;
           // _httpClient.BaseAddress = new Uri("https://localhost:44370/api/customer/");
        }
        public async Task<IActionResult> Index()
        {
            // ListOf-AllSells
            var response = await _http.GetFromJsonAsync<List<SaleDto>>("api/sales/ListOf-AllSells");

            return View(response);  
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateSaleViewModel
            {
                Customers = await GetCustomersAsync(),
                Products = await GetProductsAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleViewModel model)
        {
             await _http.PostAsJsonAsync("api/sales/Create-Sales", model);
          
            return RedirectToAction("Index");
        }

        private async Task<List<SelectListItem>> GetCustomersAsync()
        {
            var customers = await _http.GetFromJsonAsync<List<CustomerModel>>("api/customer/GetAll-Customer");


            return customers.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();
        }

        private async Task<List<SelectListItem>> GetProductsAsync()
        {
            var products = await _http.GetFromJsonAsync<List<ProductModel>>("api/customer/Get-allProduct");

            return products.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToList();
        }

    }
}
