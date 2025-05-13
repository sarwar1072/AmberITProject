using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerServices.MVC.Models.SalesFold
{
    public class CreateSaleViewModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Products { get; set; }
    }
}
