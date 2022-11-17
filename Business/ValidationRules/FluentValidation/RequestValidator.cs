using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(r => r.ReasonRequest).NotEmpty();
            RuleFor(r => r.ReasonRequest).MinimumLength(2);
            //RuleFor(r => r.CollectedAid).NotEmpty();
            //RuleFor(r => r.CollectedAid).GreaterThan(0);
        }
    }
}
