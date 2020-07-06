using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Millennium_Rekrutacja.Common;
using Millennium_Rekrutacja.Common.DbConenction;
using Millennium_Rekrutacja.Common.Enums;
using Millennium_Rekrutacja.Common.Exceptions;
using Millennium_Rekrutacja.Dto;
using Millennium_Rekrutacja.Model;
using Millennium_Rekrutacja.Repository.Interface;

namespace Millennium_Rekrutacja.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly RekrutacjaDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleRepository(RekrutacjaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IQueryable<ArticleDto> GetAll()
        {
            return _mapper.ProjectTo<ArticleDto>(_dbContext.Article);
        }

        public async Task<int> AddAsync(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            await _dbContext.Article.AddAsync(article);
            await _dbContext.SaveChangesAsync();
            return article.Id;
        }

        public async Task UpdateAsync(ArticleDto articleDto)
        {
            var article = await _dbContext.Article.FirstOrDefaultAsync(a => a.Id == articleDto.Id) ??
                          throw new BusinessException(string.Format(Constants.Error.NotFoundFormat,
                              nameof(_dbContext.Article),
                              articleDto.Id), BusinessExceptionType.NotFound);
            article = _mapper.Map(articleDto, article);

            _dbContext.Article.Update(article);
        }

        public async Task<ArticleDto> GetByIdAsync(int id)
        {
            return _mapper.Map<ArticleDto>(await _dbContext.Article.FirstOrDefaultAsync(a => a.Id == id) ??
                                           throw new BusinessException(string.Format(Constants.Error.NotFoundFormat,
                                               nameof(_dbContext.Article),
                                               id), BusinessExceptionType.NotFound));
        }
    }
}
