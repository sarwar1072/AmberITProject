using Customerservice.Framework.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Services
{
    public class CustomerServices: ICustomerServices
    {
        private IProjectUnitOfWork _unitOfWork;
        public CustomerServices(IProjectUnitOfWork projectUnitOf)
        {
            _unitOfWork = projectUnitOf;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidOperationException("customer is null ");
            }


            _unitOfWork.CustomerRepository.Add(customer);
            _unitOfWork.Save();

        }

        public void UpdateCustomer(Customer customer)
        {


            _unitOfWork.CustomerRepository.Edit(customer);
            _unitOfWork.Save();
        }


        public Customer GetById(int id)
        {
            return _unitOfWork.CustomerRepository.GetById(id);
        }
        public IList<Customer> GetAllCustomer() 
        { 
            return _unitOfWork.CustomerRepository.GetAll();
        }
        public void RemoveCustomer(int id)
        {
            if (id == 0)
            {
                throw new InvalidOperationException("ID is null ");

            }
            _unitOfWork.CustomerRepository.Remove(id);
            _unitOfWork.Save();
        }
        public double GetTotalPurchaseByCustomer(int id)
        {
            var total = _unitOfWork.SalesRepogitory.GetAll().Where(x => x.CustomerId == id).Sum(x => x.TotalPrice);

            return total;   
        }    

    }
}
