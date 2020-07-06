using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Millennium_Rekrutacja.Common;
using Millennium_Rekrutacja.Common.Enums;
using Millennium_Rekrutacja.Common.Exceptions;
using Millennium_Rekrutacja.Dto;
using Millennium_Rekrutacja.Repository.Interface;

namespace Millennium_Rekrutacja.BusinessLogic
{
    public abstract class BaseLogic
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;
        private readonly ILogger _logger;

        protected BaseLogic(IMapper mapper, IUnitOfWork context, ILogger logger)
        {
            Mapper = mapper;
            UnitOfWork = context;
            _logger = logger;
        }

        public virtual async Task<Result<TOut>> Execute<TIn, TOut>(Func<Task<TIn>> task)
        {
            try
            {
                var result = await task();

                return new Result<TOut>
                {
                    Data = Mapper.Map<TOut>(result),
                };
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex.Message);
                return new Result<TOut>
                {
                    Error = ex.Message,
                    BusinessExceptionType = ex.BusinessExceptionType
                };
            }
            catch (Exception ex)
            {
                do
                {
                    _logger.LogError(ex.Message);
                    ex = ex.InnerException;
                } while (ex != null);

                return new Result<TOut>
                {
                    Error = Constants.Error.Default,
                    BusinessExceptionType = BusinessExceptionType.InternalServerError
                };
            }
        }
    }

    public abstract class BaseBusinessLogic : BaseLogic
    {
        protected BaseBusinessLogic(IMapper mapper, IUnitOfWork context, ILogger logger) : base(mapper, context, logger)
        { }

        //public override async Task<Result<TOut>> Execute<TIn, TOut>(Func<Task<TIn>> task)
        //{
        //    return await base.Execute<TIn, TOut>(async () => await task());
        //}
    }

    public abstract class BaseBusinessLogic<TParam> : BaseBusinessLogic
    {
        protected abstract IEnumerable<IValidator<TParam>> Validators { get; }
        protected BaseBusinessLogic(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }


        [Obsolete]
        public override Task<Result<TOut>> Execute<TIn, TOut>(Func<Task<TIn>> task)
        {
            return base.Execute<TIn, TOut>(task);
        }

        public async Task<Result<TOut>> Execute<TIn, TOut>(TParam parameter, Func<Task<TIn>> task)
        {
            return await base.Execute<TIn, TOut>(async () =>
            {
                foreach (var validator in Validators)
                {
                    validator.Validate(parameter);
                }

                return await task();
            });
        }
    }
}
