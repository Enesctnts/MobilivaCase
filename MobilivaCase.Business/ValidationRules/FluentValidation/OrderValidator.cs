using FluentValidation;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {

        public OrderValidator()
        {
            RuleFor(p => p.CustomerName).NotEmpty();
            RuleFor(p => p.CustomerEmail).NotEmpty();
            RuleFor(p => p.CustomerGSM).NotEmpty();
            RuleFor(p => p.TotalAmount).NotEmpty();
            RuleFor(p => p.CustomerName).MinimumLength(2);
            RuleFor(p => p.CustomerName).MaximumLength(30);
            RuleFor(p => p.CustomerEmail).EmailAddress();
            RuleFor(p => p.CustomerGSM).MinimumLength(11).MaximumLength(11);
        }



    }
}
