using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(100000).When(p => p.CarName == "Mercedes").WithMessage("Mercedes Daha pahalı olmalı.");
           // RuleFor(p => p.CarName).Must(StartWithUpper);
        }

        //private bool StartWithUpper(string arg)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
