using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //message vermek istemiyoruz ,false u default olarak vermek istiyoruz
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //data yı default olarak vermek istiyoruz
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //herşey default olarak verilecek
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
