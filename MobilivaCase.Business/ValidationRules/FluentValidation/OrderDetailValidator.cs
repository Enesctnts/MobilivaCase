using FluentValidation;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.ValidationRules.FluentValidation
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {

        public OrderDetailValidator()
        {
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
        }



    }
}
