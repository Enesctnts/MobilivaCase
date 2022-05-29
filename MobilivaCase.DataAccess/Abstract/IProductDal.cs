using MobilivaCase.Core.DataAccess;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
