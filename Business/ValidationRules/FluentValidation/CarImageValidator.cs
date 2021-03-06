using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.ImagePath).NotEmpty();
        }
    }
}
