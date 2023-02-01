using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbcontext;

        public PokemonRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbcontext.Pokemon.AddAsync(pokemon);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbcontext.Entry(pokemon).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Pokemon entity)
        {
            _dbcontext.Set<Pokemon>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbcontext.Set<Pokemon>().ToListAsync();
        }
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Pokemon>().FindAsync(id);
        }
        public async Task<List<Pokemon>> GetAllWithIncludeAsync(List<string> properties)
        {
            return await _dbcontext.Set<Pokemon>().ToListAsync();
        }
    }
}
