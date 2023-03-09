using MagicVilla_Api.Models;
using System.Linq.Expressions;

namespace MagicVilla_Api.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllAsync(Expression<Func<Villa,bool>> filter = null);
        Task<Villa> GetAsync(Expression<Func<Villa,bool>> filter = null, bool tracked=true);
        Task CreateAsync(Villa entity);
        Task RemoveAsync(Villa entity);
        Task Save();
        Task UpdateAsync(Villa entity);
    }
}
