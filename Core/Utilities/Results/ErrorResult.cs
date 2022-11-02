using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        //sadece mesaj vermeyi sağlamak için yapıldı
        public ErrorResult(string message) : base(false, message)
        {

        }
        //false u difoult olarak vermiş olduk
        public ErrorResult() : base(false)
        {

        }
    }
}
