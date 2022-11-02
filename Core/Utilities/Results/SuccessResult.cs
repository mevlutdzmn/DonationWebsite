using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //sadece mesaj vermeyi sağlamak için yapıldı
        public SuccessResult(string message) : base(true, message)
        {

        }
        //true yu difoult olarak vermiş olduk
        public SuccessResult() : base(true)
        {

        }
    }
}
