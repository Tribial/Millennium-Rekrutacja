using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Dto;

namespace Millennium_Rekrutacja.BusinessLogic.Interface
{
    public interface IBusinessLogic<TResult>
    {
        Task<Result<TResult>> ExecuteAsync();
    }

    public interface IBusinessLogic<in TParam, TResult>
    {
        Task<Result<TResult>> ExecuteAsync(TParam param);
    }
}
