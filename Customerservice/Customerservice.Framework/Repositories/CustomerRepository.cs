using Customerservice.Framework.Entites;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Repositories
{
    public class CustomerRepository:Repository<Customer,int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext):base(dbContext) { }
        
    }
}
