using PFMApi.Database.Contracts;
using PFMApi.Database.Entity;
using PFMApi.Dto;
using PFMApi.Helpers;
using PFMApi.Services.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TinyCsvParser;
using System.IO;
using System.Text;
using PFMApi.Database.Entity.TransactionsE;
using PFMApi.Helpers.Params;
using System;
using PFMApi.Database.Repositories;

namespace PFMApi.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IRepository<Transactions> _transactionsRepository;

        public TransactionsService(IRepository<Transactions> transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }


        public async Task<bool> AddTransactions(HttpRequest request)
        {

            request.Body.Position = 0;
            var reader = new StreamReader(request.Body, Encoding.UTF8);
            var parsedDataString = await reader.ReadToEndAsync().ConfigureAwait(false);

            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { "\n" });
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');

            TransactionsMappingModel csvMapper = new TransactionsMappingModel();

            CsvParser<Transactions> csvParser = new CsvParser<Transactions>(csvParserOptions, csvMapper);
            var result = csvParser
                         .ReadFromString(csvReaderOptions, parsedDataString)
                         .ToList();

            result.Remove(result[result.Count - 1]);

            List<Transactions> list = new List<Transactions>();
            for (int i = 3; i < result.Count; i++)
            {
                Transactions dataForDb = new Transactions
                {
                    Id = result[i].Result.Id,
                    BeneficiaryName = result[i].Result.BeneficiaryName,
                    Date = result[i].Result.Date,
                    Direction = result[i].Result.Direction,
                    Amount = result[i].Result.Amount,
                    Description = result[i].Result.Description,
                    Currency = result[i].Result.Currency,
                    Kind = result[i].Result.Kind,
                    Mcc = result[i].Result.Mcc
                };
                list.Add(dataForDb);
            }

            await _transactionsRepository.AddRange(list);
            var resultFromRepo = await _transactionsRepository.SaveAll();

            if (resultFromRepo)

            {
                
                // primer za return i poraka
                //await $"Created Transaction on server with name {dataForDb.Name}",
                //    "With method: AddTransactions ", user, ip, browser);
                return true;
            }

            return false;
        }

        public async Task<PagedList<Transactions>> GetPagedListTransactions(QueryParams transactionsParams)
        {
            var query = _transactionsRepository.AsQueryable();
            query = query.OrderBy(x => x.BeneficiaryName);

            if (!string.IsNullOrEmpty(transactionsParams.BeneficiaryName))
                query = query.Where(x => x.BeneficiaryName.Contains(transactionsParams.BeneficiaryName));

            if (!string.IsNullOrEmpty(transactionsParams.Direction))
                query = query.Where(x => x.Direction.Contains(transactionsParams.Direction));

            if (transactionsParams.FromAmount > 0 && transactionsParams.ToAmount > 0)
            {
                var from = transactionsParams.FromAmount;
                var to = transactionsParams.ToAmount;
                if (from <= to)
                    query = query.Where(x => from <= x.Amount && x.Amount <= to);
            }

            if (!string.IsNullOrEmpty(transactionsParams.FromDate) && !string.IsNullOrEmpty(transactionsParams.ToDate))
            {
                var dateFrom = Convert.ToDateTime(transactionsParams.FromDate);
                var dateTo = Convert.ToDateTime(transactionsParams.ToDate);

                if (dateFrom <= dateTo) query = query.Where(x => (DateTime)(object)x.Date >= dateFrom && (DateTime)(object)x.Date <= dateTo);
            }

            return await PagedList<Transactions>.ToPagedList(query, transactionsParams.PageNumber, transactionsParams.PageSize);
        }
        //public async Task<ICollection<TransactionsDto>> GetAllTransactions()
        
            // bez paginacija

            //var dataFromDb = await _transactionsRepository.AsQueryable()
            //    .Where(x => x.DeletedBy == null && x.DeletedBy == null)
            //    .ToListAsync();

            //return null; /*_mapper.Map<ICollection<TransactionsDto>>(dataFromDb);*/
        }

  }
