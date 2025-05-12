using Customerservice.Framework.Entites;

namespace Customerservice.API.Models.SalesFoldr
{
    public class CreateSalesModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
