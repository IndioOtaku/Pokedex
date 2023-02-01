using DataBase.Models;
using DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TipoRepository
    {
        private readonly ApplicationContext _dbcontext;

        public TipoRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(TipoPrimario tipoPrimario, TipoSecundario tipoSecundario)
        {
            await _dbcontext.TipoPrimario.AddAsync(tipoPrimario);
            await _dbcontext.TipoSecundario.AddAsync(tipoSecundario);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TipoPrimario tipoPrimario, TipoSecundario tipoSrimario)
        {
            _dbcontext.Entry(tipoPrimario).State = EntityState.Modified;
            _dbcontext.Entry(tipoSrimario).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(TipoPrimario entityPrimario, TipoSecundario entitySecundario)
        {
            _dbcontext.Set<TipoPrimario>().Remove(entityPrimario);
            _dbcontext.Set<TipoSecundario>().Remove(entitySecundario);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<TipoPrimario>> GetAllAsync()
        {
            return await _dbcontext.Set<TipoPrimario>().ToListAsync();
        }
        public async Task<List<TipoSecundario>> GetAllTipoSecundarioAsync()
        {
            return await _dbcontext.Set<TipoSecundario>().ToListAsync();
        }
        public async Task<TipoPrimario> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<TipoPrimario>().FindAsync(id);
        }
        public async Task<TipoSecundario> GetByIdTipoSecundarioAsync(int id)
        {
            return await _dbcontext.Set<TipoSecundario>().FindAsync(id);
        }
    }
}
