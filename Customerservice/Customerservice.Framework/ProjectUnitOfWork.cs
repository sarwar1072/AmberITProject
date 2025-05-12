using Customerservice.Framework.Repositories;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework
{
    public class ProjectUnitOfWork:UnitOfWork, IProjectUnitOfWork
    {
        public  IProductRepository ProductRepository { private set;   get; }
        public ICustomerRepository CustomerRepository { private set; get; }
        public ISalesRepogitory SalesRepogitory { private set; get; }
        public ProjectUnitOfWork(ApplicationDbContext applicationDb,IProductRepository productRepository,
            ICustomerRepository customerRepository,
            ISalesRepogitory salesRepogitory) : base(applicationDb)
        {
            ProductRepository = productRepository;
            CustomerRepository = customerRepository;    
            SalesRepogitory = salesRepogitory;
        }
    }
}
