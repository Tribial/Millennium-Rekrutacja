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
    public class ArticleAddBusinessLogic : BaseBusinessLogic<ArticleBindingModel>, IArticleAddBusinessLogic
    {
        public ArticleAddBusinessLogic(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ArticleAddBusinessLogic> logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override IEnumerable<IValidator<ArticleBindingModel>> Validators =>
            new[] {new ArticleUniquenessValidator(UnitOfWork),};
        public async Task<Result<ArticleViewModel>> ExecuteAsync(ArticleBindingModel param)
        {
            return await Execute<ArticleDto, ArticleViewModel>(param, async () =>
            {
                var articleDto = Mapper.Map<ArticleDto>(param);
                var articleId = await UnitOfWork.Article.AddAsync(articleDto);

                return await UnitOfWork.Article.GetByIdAsync(articleId);
            });
        }
    }
}
