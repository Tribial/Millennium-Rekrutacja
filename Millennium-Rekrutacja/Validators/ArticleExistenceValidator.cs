using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.BindingModel;
using Millennium_Rekrutacja.BusinessLogic;
using Millennium_Rekrutacja.Common;
using Millennium_Rekrutacja.Common.Enums;
using Millennium_Rekrutacja.Common.Exceptions;
using Millennium_Rekrutacja.Repository.Interface;

namespace Millennium_Rekrutacja.Validators
{
    public class ArticleExistenceValidator : IValidator<int>, IValidator<ArticleUpdateBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleExistenceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(int param)
        {
            throw new NotImplementedException();
        }

        private void ValidateExistenceById(int id)
        {
            if (!_unitOfWork.Article.GetAll().Any(a => a.Id == id))
            {
                throw new BusinessException(
                    string.Format(Constants.Error.NotFoundFormat, nameof(_unitOfWork.Article), id),
                    BusinessExceptionType.ArgumentError);
            }
        }

        public void Validate(ArticleUpdateBindingModel param)
        {
            ValidateExistenceById(param.Id);
        }
    }
}
