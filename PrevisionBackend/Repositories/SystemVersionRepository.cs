using Microsoft.EntityFrameworkCore;
using PrevisionBackend.Data;
using PrevisionBackend.Models;

namespace PrevisionBackend.Repositories
{
    public class SystemVersionRepository
    {
        private ApplicationDbContext _context;

        public SystemVersionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task createSystemVersionAsync(SystemVersion system)
        {
           _context.SystemVersions.Add(system);
            await _context.SaveChangesAsync();
        }

        public async Task<SystemVersion> GetByIdAsync(int systemId)
        {
            return await _context.SystemVersions.Where(s => s.Id ==systemId).Include(s=>s.Versions).FirstOrDefaultAsync();
        }

        public async Task<List<SystemVersion>> GetAllAsync()
        {
            return await _context.SystemVersions.Include(s => s.Versions).ToListAsync();
        }

        public async Task<SystemVersion> GetSystemVersionByFarmIdAsync(string fermeId)
        {
            var system= await _context.SystemVersions           // Start from the SystemVersions DbSet
                                  .Include(sv => sv.Versions) // Eagerly load Versions *on SystemVersion*
                                  .Where(sv => sv.Fermes.Any(f => f.CodFerm == fermeId)) // Filter SystemVersions based on their associated Fermes
                                  .FirstOrDefaultAsync();
            return system;
        }


    }
}
