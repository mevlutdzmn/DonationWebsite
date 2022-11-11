using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    //iş kuralları motoru 
    public class BusinessRules
    {
        //iş kurallarını çalıştırmak için yazıldı
        //params kullanıldığında run içerisine istediğiniz kadar IResult verilebilir 
        public static IResult Run(params IResult[] logics)
        {
            //her bir iş kuralını(logic) gez
            foreach (var logic in logics)
            {
                //başarısızsa logic döndür(errorresult)
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;

        }
    }
}
