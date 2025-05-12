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
    public class SalesRepogitory:Repository<Sales,int> , ISalesRepogitory
    {
        public SalesRepogitory(ApplicationDbContext dbContext):base(dbContext) { }

        public virtual Sales GetDynamic(Expression<Func<Sales, bool>> filter = null,
          Func<IQueryable<Sales>, IIncludableQueryable<Sales, object>> include = null)
        {
            IQueryable<Sales> queryable = _dbSet;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (include != null)
            {
                queryable = include(queryable);
            }

            return queryable.FirstOrDefault();
        }

    }
}
