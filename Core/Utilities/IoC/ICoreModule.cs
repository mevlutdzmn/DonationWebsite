using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
   public interface ICoreModule
    {
        //Bağımlılıkları yükleyecek -servisleri burası yükleyecek 
        void Load(IServiceCollection serviceCollection);
    }
}
