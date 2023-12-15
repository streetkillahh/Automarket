using System.Linq;
using System.Threading.Tasks;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;

namespace Automarket.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly ApplicationDbContext _db;

        public ProfileRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Profile entity)
        {
            await _db.Profiles.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _db.Profiles;
        }

        public async Task Delete(Profile entity)
        {
            _db.Profiles.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Profile> Update(Profile entity)
        {
            _db.Profiles.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}