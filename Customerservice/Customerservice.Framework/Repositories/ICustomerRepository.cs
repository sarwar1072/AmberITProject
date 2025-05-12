using Customerservice.Framework.Entites;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Repositories
{
    public interface ICustomerRepository:IRepository<Customer,int>
    {
    }
}
