using MobilivaCase.Core.Utilities.Result;
using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.Abstract
{
    public interface IOrderService
    {
        int Add(CreateOrderRequestDto orderRequest);

    }
}
