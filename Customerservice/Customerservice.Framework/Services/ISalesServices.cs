using Customerservice.Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Services
{
    public interface ISalesServices
    {
        void CreateSales(Sales sales);
        IList<Sales> SalesFilter(DateTime dateTime, int CustomerId, int ProductId);
        IList<Sales> GetAllSales();

    }
}
