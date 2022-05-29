using MobilivaCase.Core.DataAccess.EntityFramework;
using MobilivaCase.DataAccess.Abstract;
using MobilivaCase.DataAccess.Context;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.DataAccess.Concrete.EntityFrameworkk
{
    public class EfOrderDal : EfEntityFrameworkBase<Order, MobilivaDbContext>, IOrderDal
    {
        public EfOrderDal(MobilivaDbContext context) : base(context)
        {

        }
    }
}
