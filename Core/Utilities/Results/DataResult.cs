using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result , IDataResult<T>
    {
        public DataResult(T Data,bool success,string message):base(success,message)
        {
            data = Data;
        }
        public DataResult(T Data,bool success):base(true)
        {
            data = Data;
        }
        public T data { get; }
    }
}
