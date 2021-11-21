using Microsoft.EntityFrameworkCore;
using PFMApi.Database.Contracts;
using PFMApi.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFMApi.Database
{ 
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly AppDbContext _dbContext;
            private readonly DbSet<T> models;
        
            public Repository(AppDbContext dbContext)
            {
            _dbContext = dbContext;
            models = _dbContext.Set<T>();
            }

            public async Task Add(T entity)
            {
                await models.AddAsync(entity);
            }

        public void Update(T entity)
        {
            try
            {
                models.Update(entity);
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task AddRange(ICollection<T> collection)
            {
                await models.AddRangeAsync(collection);
            }

            public IQueryable<T> AsQueryable()
            {
                return models.AsQueryable<T>();
            }

            public void Delete(T entity)
            {
                models.Remove(entity);
            }

            public async Task<T> GetById(int id)
            {
                return await models.FindAsync(id);
            }
            public async Task<T> GetByCode(string code)
            {
                return await models.FindAsync(code);
            }

        public List<Categories> GetCategories()
        {
            var allCategories = _dbContext.Categories.ToList();
            return allCategories;
        }

        public List<Categories> GetCategoriesByCode(string code)
        {
            var allCategories = _dbContext.Categories.Where(x => x.Code == code).ToList();
            return allCategories;
        }

        public async Task<ICollection<T>> List()
            {
                return await models.ToListAsync();
            }
            public async Task<bool> SaveAll()
            {

                return await _dbContext.SaveChangesAsync() > 0;
            }
        }
}

