using Application.Repository;
using Application.ViewModels.Pokemon;
using Application.ViewModels.Region;
using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;

        public RegionService(ApplicationContext dbcontext)
        {
            _regionRepository = new(dbcontext);
        }

        public async Task Add(SaveRegionViewModel rvm)
        {
            Region region = new();
            region.idRegion = rvm.idRegion;
            region.Nombre = rvm.Nombre;

            await _regionRepository.AddAsync(region);
        }
        public async Task Update(SaveRegionViewModel rvm)
        {
            Region region = new();
            region.idRegion = rvm.idRegion;
            region.Nombre = rvm.Nombre;

            await _regionRepository.UpdateAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(region);
        }
        public async Task<SaveRegionViewModel> GetByIdSaveRegionViewModel(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            SaveRegionViewModel rvm = new();
            rvm.idRegion = region.idRegion;
            rvm.Nombre = region.Nombre;

            return rvm;
        }
        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllAsync();

            return regionList.Select(region => new RegionViewModel
            {
                idRegion = region.idRegion,
                Nombre = region.Nombre,
            }).ToList();
        }
    }
}
