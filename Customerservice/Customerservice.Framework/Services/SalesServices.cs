using Customerservice.Framework.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Services
{
    public class SalesServices: ISalesServices
    {
        private readonly IProjectUnitOfWork _projectUnitOfWork;
        public SalesServices(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }

        public void CreateSales(Sales sales)
        {
            if (sales == null)
            {
                throw new InvalidOperationException("Sales is null ");
            }
            var product = _projectUnitOfWork.ProductRepository
                .GetDynamic(x => x.Id == sales.ProductId, null);
                

            if (product == null)
                throw new Exception("Invalid product selected");

            sales.TotalPrice = product.Price * sales.Quantity;
            sales.Salesdate = DateTime.UtcNow;


            _projectUnitOfWork.SalesRepogitory.Add(sales);
            _projectUnitOfWork.Save();
        }

        public IList<Sales> GetAllSales()
        {
            return _projectUnitOfWork.SalesRepogitory.Get(null, null, x => x.Include(x => x.Product).Include(y => y.Customer), false);
        }
        public IList<Sales> SalesFilter(DateTime dateTime,int CustomerId,int ProductId)
        {
            var filterData=_projectUnitOfWork.SalesRepogitory.Get(x=>x.Salesdate==dateTime || x.CustomerId==CustomerId || x.ProductId==ProductId
            ,null,c=>c.Include(c=>c.Product).Include(c=>c.Customer),false);
            return filterData;
        }

    }
}
