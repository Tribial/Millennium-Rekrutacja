using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Millennium_Rekrutacja.BusinessLogic.Interface;
using Millennium_Rekrutacja.Common.Enums;
using Millennium_Rekrutacja.Dto;
using Millennium_Rekrutacja.Repository.Interface;
using Millennium_Rekrutacja.Validators;
using Millennium_Rekrutacja.ViewModel;

namespace Millennium_Rekrutacja.BusinessLogic
{
    public class ArticleDeleteBusinessLogic : BaseBusinessLogic<int>, IArticleDeleteBusinessLogic
    {
        public ArticleDeleteBusinessLogic(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override IEnumerable<IValidator<int>> Validators => new[]
        {
            new ArticleExistenceValidator(UnitOfWork),
        };
        public async Task<Result<ArticleViewModel>> ExecuteAsync(int param)
        {
            return await Execute<ArticleDto, ArticleViewModel>(param, async () =>
            {
                var articleDto = await UnitOfWork.Article.GetByIdAsync(param);
                articleDto.Status = ArticleStatus.DeletedByUser;
                await UnitOfWork.Article.UpdateAsync(articleDto);
                await UnitOfWork.SaveAsync();

                return await UnitOfWork.Article.GetByIdAsync(articleDto.Id);
            });
        }
    }
}
