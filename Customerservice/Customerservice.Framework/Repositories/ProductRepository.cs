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
    public class ProductRepository : Repository<Product,int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public virtual Product GetDynamic(Expression<Func<Product, bool>> filter = null,
          Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null)
        {
            IQueryable<Product> queryable = _dbSet;
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
