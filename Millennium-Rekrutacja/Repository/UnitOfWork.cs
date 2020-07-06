using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Common.DbConenction;
using Millennium_Rekrutacja.Repository.Interface;

namespace Millennium_Rekrutacja.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RekrutacjaDbContext _dbContext;
        public UnitOfWork(RekrutacjaDbContext dbContext, IArticleRepository article)
        {
            _dbContext = dbContext;
            Article = article;
        }

        public IArticleRepository Article { get; }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
