using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Common.Enums;

namespace Millennium_Rekrutacja.Dto
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
        public BusinessExceptionType BusinessExceptionType { get; set; }
        public bool IsValid => string.IsNullOrWhiteSpace(Error);
    }
}
