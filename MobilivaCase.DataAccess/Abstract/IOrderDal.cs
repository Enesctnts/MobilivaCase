using MobilivaCase.Core.DataAccess;
using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        
    }
}
