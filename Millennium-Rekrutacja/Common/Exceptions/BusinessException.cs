using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Common.Enums;

namespace Millennium_Rekrutacja.Common.Exceptions
{
    public class BusinessException : ApplicationException
    {
        public BusinessExceptionType BusinessExceptionType { get; set; }

        public BusinessException(string message, BusinessExceptionType businessExceptionType) : base(message)
        {
            BusinessExceptionType = businessExceptionType;
        }
    }
}
