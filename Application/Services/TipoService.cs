using Application.Repository;
using Application.ViewModels.Region;
using DataBase.Models;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.TipoPrimario;

namespace Application.Services
{
    public class TipoService
    {
        private readonly TipoRepository _tipoRepository;

        public TipoService(ApplicationContext dbcontext)
        {
            _tipoRepository = new(dbcontext);
        }

        public async Task Add(SaveTipoPrimarioViewModel tpvm)
        {
            TipoPrimario tipoPrimario = new();
            tipoPrimario.idTipoPrimario = tpvm.idTipoPrimario;
            tipoPrimario.Nombre = tpvm.Nombre;

            TipoSecundario tipoSecundario = new();
            tipoSecundario.idTipoSecundario = tpvm.idTipoPrimario;
            tipoSecundario.Nombre = tpvm.Nombre;

            await _tipoRepository.AddAsync(tipoPrimario, tipoSecundario);
        }
        public async Task Update(SaveTipoPrimarioViewModel tpvm)
        {
            TipoPrimario tipoPrimario = new();
            tipoPrimario.idTipoPrimario = tpvm.idTipoPrimario;
            tipoPrimario.Nombre = tpvm.Nombre;

            TipoSecundario tipoSecundario = new();
            tipoSecundario.idTipoSecundario = tpvm.idTipoPrimario;
            tipoSecundario.Nombre = tpvm.Nombre;

            await _tipoRepository.UpdateAsync(tipoPrimario, tipoSecundario);
        }

        public async Task Delete(int id)
        {
            var tipoPrimario = await _tipoRepository.GetByIdAsync(id);
            var tipoSecundario = await _tipoRepository.GetByIdTipoSecundarioAsync(id);
            await _tipoRepository.DeleteAsync(tipoPrimario, tipoSecundario);
        }
        public async Task<SaveTipoPrimarioViewModel> GetByIdSaveTipoViewModel(int id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(id);

            SaveTipoPrimarioViewModel tpvm = new();
            tpvm.idTipoPrimario = tipo.idTipoPrimario;
            tpvm.Nombre = tipo.Nombre;

            return tpvm;
        }
        public async Task<List<TipoPrimarioViewModel>> GetAllViewModel()
        {
            var tipoList = await _tipoRepository.GetAllAsync();

            return tipoList.Select(tipo => new TipoPrimarioViewModel
            {
                idTipoPrimario = tipo.idTipoPrimario,
                Nombre = tipo.Nombre,
            }).ToList();
        }
        public async Task<List<TipoSecundarioViewModel>> GetAllTipoSecundario()
        {
            var tipoList = await _tipoRepository.GetAllTipoSecundarioAsync();

            return tipoList.Select(tipo => new TipoSecundarioViewModel
            {
                idTipoSecundario = tipo.idTipoSecundario,
                Nombre = tipo.Nombre,
            }).ToList();
        }
    }
}
