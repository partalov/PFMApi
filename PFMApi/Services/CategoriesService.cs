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
using PFMApi.Helpers.Params;
using System;
using PFMApi.Database.Repositories;

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
            var resultFromRepo = false;
            for (int i = 3; i < result.Count; i++)
            {
                Categories dataForDb = new Categories
                {
                    Code = result[i].Result.Code,
                    ParentCode = result[i].Result.ParentCode,
                    Name = result[i].Result.Name
                };

                var isExisting = _categoriesRepository.GetCategoriesByCode(result[i].Result.Code);

                if (isExisting.Count > 0)
                {
                    if(dataForDb.ParentCode == isExisting.FirstOrDefault().ParentCode 
                        && dataForDb.Name == isExisting.FirstOrDefault().Name)
                    {
                        //do nothing
                    }
                    else
                    {
                        _categoriesRepository.Update(dataForDb);
                    }
                }
                else
                {
                    await _categoriesRepository.Add(dataForDb);
                }

                
                resultFromRepo = await _categoriesRepository.SaveAll();

                
            }

            //await _categoriesRepository.AddRange(list);
            //var resultFromRepo = await _categoriesRepository.SaveAll();

            if (resultFromRepo)
            {
                
                return true;
            }

            return false;
        }
    }
}