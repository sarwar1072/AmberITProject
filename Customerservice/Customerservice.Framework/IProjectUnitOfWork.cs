using Customerservice.Framework.Repositories;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework
{
    public interface IProjectUnitOfWork:IUnitOfWork
    {
          IProductRepository ProductRepository { get; }
         ICustomerRepository CustomerRepository {  get; }
         ISalesRepogitory SalesRepogitory {  get; }

    }
}
