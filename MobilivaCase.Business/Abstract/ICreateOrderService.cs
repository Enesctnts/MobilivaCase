﻿using MobilivaCase.Core.Business;
using MobilivaCase.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.Abstract
{
    public interface ICreateOrderService : IApplicationService<CreateOrderRequestDto, string>
    {

    }
}
