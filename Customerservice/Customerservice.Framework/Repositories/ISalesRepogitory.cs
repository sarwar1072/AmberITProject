using Customerservice.Framework.Entites;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customerservice.Framework.Repositories
{
    public interface ISalesRepogitory:IRepository<Sales,int>
    {
        Sales GetDynamic(Expression<Func<Sales, bool>> filter = null,
          Func<IQueryable<Sales>, IIncludableQueryable<Sales, object>> include = null);
    }
}
