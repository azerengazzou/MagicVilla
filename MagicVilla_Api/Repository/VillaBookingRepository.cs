using MagicVilla_Api.Data;
using MagicVilla_Api.Models;
using MagicVilla_Api.Repository.IRepository;

namespace MagicVilla_Api.Repository
{
    public class VillaBookingRepository : Repository<VillaBooking>, IVillaBookingRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaBookingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<VillaBooking> UpdateAsync(VillaBooking entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.VillaBookings.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
