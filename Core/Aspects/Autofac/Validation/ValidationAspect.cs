using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    // MethodInterception u imlement ediyoruz
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        //onBefor'u ez -sadece başında çalışacak AoP miz
        protected override void OnBefore(IInvocation invocation)
        {
            //örneğin requestValidatoru(validatortype) new ledi ilk satır 
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //validatortype tipind base'sindeki(abstractvalidator) generic argümanların sıfırıncısının tipini yakala 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //methodun(invocation(add)) argümanları(parametrelerini) gez,eğer ordaki tip entitytipimdeyse onlarıda validate et(doğrula)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
