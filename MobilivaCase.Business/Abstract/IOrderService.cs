using MobilivaCase.Entity.Concrete;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobilivaCase.Core.Utilities.Results;

namespace MobilivaCase.Business.Abstract
{
    public interface IOrderService
    {
       Task<ApiResponse> CreateOrder([FromBody] CreateOrderRequestDto createOrderRequest); 
    }
}
 