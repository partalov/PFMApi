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
using PFMApi.Database.Entity.CategoriesE;

namespace PFMApi.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Categories> _categoriesRepository;

        public CategoriesService(IRepository<Categories> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public async Task<bool> AddCategories(HttpRequest request)
        {
            request.Body.Position = 0;
            var reader = new StreamReader(request.Body, Encoding.UTF8);
            var parsedDataString = await reader.ReadToEndAsync().ConfigureAwait(false);

            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { "\n" });
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');

            CategoriesMappingModel csvMapper = new CategoriesMappingModel();

            CsvParser<Categories> csvParser = new CsvParser<Categories>(csvParserOptions, csvMapper);
            var result = csvParser
                         .ReadFromString(csvReaderOptions, parsedDataString)
                         .ToList();

            result.Remove(result[result.Count - 1]);

            List<Categories> list = new List<Categories>();
            for (int i = 0; i < result.Count; i++)
            {
                Categories dataForDb = new Categories
                {
                    Code = result[i].Result.Code,
                    ParentCode = result[i].Result.ParentCode,
                    Name = result[i].Result.Name
                };
                list.Add(dataForDb);
            }

            await _categoriesRepository.AddRange(list);
            var resultFromRepo = await _categoriesRepository.SaveAll();

            if (resultFromRepo)
            {
                // primer za return i poraka
                //await $"Created Categories on server with name {dataForDb.Name}",
                //    "With method: AddCategories ", user, ip, browser);
                return true;
            }

            return false;
        }
    }
}