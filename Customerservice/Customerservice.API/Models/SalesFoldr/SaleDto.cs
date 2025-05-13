namespace Customerservice.API.Models.SalesFoldr
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalAmount { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
    }
}
