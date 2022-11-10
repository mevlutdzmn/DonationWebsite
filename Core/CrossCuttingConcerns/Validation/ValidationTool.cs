using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //bana bir IValidator ver ,birde doğrulamam için varlık ver
        //IValidator validator:doğrulama kurallarının olduğu class
        //object entity:doğrulanak class
        public static void Validate(IValidator validator,object entity)
        {
            //Validate methodu kullanılaral doğru olup olmadığına bakıldı doğru değilse ValidationException i bul patlat
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
