using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(2018);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.Description).Must(Min);
            RuleFor(c => c.BrandId).NotEmpty();
        }

        private bool Min(string arg)
        {
            return arg.Length >= 2;
        }
    }
}
