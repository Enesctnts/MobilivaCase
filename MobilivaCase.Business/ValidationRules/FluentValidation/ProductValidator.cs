using FluentValidation;
using MobilivaCase.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Category).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.Unit).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).MaximumLength(500);
            RuleFor(p => p.UnitPrice).GreaterThan(0);
        }

     
    }
}
