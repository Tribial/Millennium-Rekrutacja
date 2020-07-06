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
    public class ArticleUniquenessValidator : IValidator<ArticleBindingModel>, IValidator<ArticleUpdateBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleUniquenessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(ArticleBindingModel param)
        {
            ValidateUniquenessByTitle(param.Title);
        }

        private void ValidateUniquenessByTitle(string title)
        {
            if (_unitOfWork.Article.GetAll().Any(a => a.Title == title))
            {
                throw new BusinessException(
                    string.Format(Constants.Error.AlreadyExistsFormat, nameof(_unitOfWork.Article), title),
                    BusinessExceptionType.ArgumentError);
            }
        }

        public void Validate(ArticleUpdateBindingModel param)
        {
            ValidateUniquenessByTitle(param.Title);
        }
    }
}
