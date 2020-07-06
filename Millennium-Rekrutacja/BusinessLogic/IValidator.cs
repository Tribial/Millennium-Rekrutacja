using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Millennium_Rekrutacja.BusinessLogic
{
    public interface IValidator<in T>
    {
        void Validate(T param);
    }
}
