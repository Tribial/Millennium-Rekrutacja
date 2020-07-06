using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Millennium_Rekrutacja.BindingModel;
using Millennium_Rekrutacja.BusinessLogic.Interface;
using Millennium_Rekrutacja.Dto;
using Millennium_Rekrutacja.Repository.Interface;
using Millennium_Rekrutacja.Validators;
using Millennium_Rekrutacja.ViewModel;

namespace Millennium_Rekrutacja.BusinessLogic
{
    public class ArticleUpdateBusinessLogic : BaseBusinessLogic<ArticleUpdateBindingModel>, IArticleUpdateBusinessLogic
    {
        public ArticleUpdateBusinessLogic(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override IEnumerable<IValidator<ArticleUpdateBindingModel>> Validators =>
            new IValidator<ArticleUpdateBindingModel>[]
                {
                    new ArticleUniquenessValidator(UnitOfWork), 
                    new ArticleExistenceValidator(UnitOfWork),
                };
        public async Task<Result<ArticleViewModel>> ExecuteAsync(ArticleUpdateBindingModel param)
        {
            return await Execute<ArticleDto, ArticleViewModel>(param, async () =>
            {
                var articleDto = Mapper.Map<ArticleDto>(param);
                await UnitOfWork.Article.UpdateAsync(articleDto);
                await UnitOfWork.SaveAsync();
                return await UnitOfWork.Article.GetByIdAsync(articleDto.Id);
            });
        }
    }
}
