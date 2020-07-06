using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Millennium_Rekrutacja.Repository.Interface
{
    public interface IUnitOfWork
    {
        IArticleRepository Article { get; }
        Task SaveAsync();
    }
}
