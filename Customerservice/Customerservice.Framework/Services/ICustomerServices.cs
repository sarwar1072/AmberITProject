using Customerservice.Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Services
{
    public interface ICustomerServices
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer GetById(int id);
        void RemoveCustomer(int id);
        IList<Customer> GetAllCustomer();
        double GetTotalPurchaseByCustomer(int id);


    }
}
