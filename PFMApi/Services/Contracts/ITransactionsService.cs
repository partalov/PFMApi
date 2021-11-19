using Microsoft.AspNetCore.Http;
using PFMApi.Database.Entity.TransactionsE;
using PFMApi.Dto;
using PFMApi.Helpers;
using PFMApi.Helpers.Params;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFMApi.Services.Contracts
{
    public interface ITransactionsService
    {
        Task<bool> AddTransactions(HttpRequest request);
        Task<PagedList<Transactions>> GetPagedListTransactions(QueryParams transactionsParams);
      //  Task<ICollection<TransactionsDto>> GetAllTransactions();

    }
}
