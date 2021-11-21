using PFMApi.Database.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PFMApi.Database.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByCode(string code);
        Task<ICollection<T>> List();
        Task AddRange(ICollection<T> collection);
        Task Add(T entity);
        void Update(T entity);
        //void AddorUpdate(T entity);
        void Delete(T entity);
        IQueryable<T> AsQueryable();
        Task<bool> SaveAll();
        List<Categories> GetCategoriesByCode(string code);

        List<Categories> GetCategories();
    }
}
