using CustomerServices.MVC.Models.CustomerFold;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace CustomerServices.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44370/api/customer/");
        }
       
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("GetAll-Customer");

            if (!response.IsSuccessStatusCode) return View("Error");

            var content = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<List<CustomerModel>>(content);

            return View(customers);  
        }
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("Create-Customer", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to create customer");
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync("GetAll-Customer");
            var customers = JsonConvert.DeserializeObject<List<CustomerModel>>(await response.Content.ReadAsStringAsync());
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            return View(new UpdateCustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateCustomerModel model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{id}/Update-customer", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Failed to update customer");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Delete-Customer?id={id}");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> TotalPurchase(int id)
        {
            var response = await _httpClient.GetAsync($"Total-purchase?id={id}");
            var total = await response.Content.ReadAsStringAsync();
            ViewBag.Total = total;
            return View();
        }
    }
}
