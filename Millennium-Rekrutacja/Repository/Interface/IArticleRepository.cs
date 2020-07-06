using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Dto;

namespace Millennium_Rekrutacja.Repository.Interface
{
    public interface IArticleRepository
    {
        IQueryable<ArticleDto> GetAll();
        Task<int> AddAsync(ArticleDto articleDto);
        Task UpdateAsync(ArticleDto articleDto);
        Task<ArticleDto> GetByIdAsync(int id);
    }
}
