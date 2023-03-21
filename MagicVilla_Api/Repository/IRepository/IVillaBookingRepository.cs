using MagicVilla_Api.Models;
using System.Linq.Expressions;

namespace MagicVilla_Api.Repository.IRepository
{
    public interface IVillaBookingRepository : IRepository<VillaBooking>
    {
        Task <VillaBooking> UpdateAsync(VillaBooking entity);
    }
}
