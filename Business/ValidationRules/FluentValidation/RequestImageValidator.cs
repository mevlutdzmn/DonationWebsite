using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RequestImageValidator : AbstractValidator<RequestImage>
    {
        public RequestImageValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Id).NotNull();
        }
    }
}