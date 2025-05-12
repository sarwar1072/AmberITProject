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
    public interface IProductRepository:IRepository<Product,int>    
    {
        Product GetDynamic(Expression<Func<Product, bool>> filter = null,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null);
    }
}
