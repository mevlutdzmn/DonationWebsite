using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        //message vermek istemiyoruz ,true yu default olarak vermek istiyoruz
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        //data yı default olarak vermek istiyoruz
        public SuccessDataResult(string message) : base(default,true, message)
        {

        }
        //herşey default olarak verilecek
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
