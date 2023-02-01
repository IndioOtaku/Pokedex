using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegionRepository
    {
        private readonly ApplicationContext _dbcontext;

        public RegionRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(Region region)
        {
            await _dbcontext.Region.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Region region)
        {
            _dbcontext.Entry(region).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Region entity)
        {
            _dbcontext.Set<Region>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbcontext.Set<Region>().ToListAsync();
        }
        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Region>().FindAsync(id);
        }
    }
}
