using Application.ViewModels.Pokemon;
using Application.ViewModels.TipoPrimario;
using DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository;

        public PokemonService(ApplicationContext dbcontext)
        {
            _pokemonRepository = new(dbcontext);
        }

        public async Task Add(SavePokemonViewModel pvm)
        {
            Pokemon pokemon = new();
            pokemon.imgPokemon = pvm.imgPokemon;
            pokemon.nombre = pvm.nombre;
            pokemon.TipoPrimarioId = pvm.idTipoPrimario;
            pokemon.TipoSecundarioId = pvm.idTipoSecundario;
            pokemon.RegionId = pvm.RegionId;

            await _pokemonRepository.AddAsync(pokemon);
        }
        public async Task Update(SavePokemonViewModel pvm)
        {
            Pokemon pokemon = new();
            pokemon.idPokemon = pvm.idPokemon;
            pokemon.imgPokemon = pvm.imgPokemon;
            pokemon.nombre = pvm.nombre;
            pokemon.TipoPrimarioId = pvm.idTipoPrimario;
            pokemon.TipoSecundarioId = pvm.idTipoSecundario;
            pokemon.RegionId = pvm.RegionId;

            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }
        public async Task<SavePokemonViewModel> GetByIdSavePokemonViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel pmv = new();
            pmv.idPokemon = pokemon.idPokemon;
            pmv.imgPokemon = pokemon.imgPokemon;
            pmv.nombre = pokemon.nombre;
            pmv.idTipoPrimario = pokemon.TipoPrimarioId;
            pokemon.TipoSecundarioId = pokemon.TipoSecundarioId;
            pmv.RegionId = pokemon.RegionId;

            return pmv;
        }
        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllWithIncludeAsync(new List<string> { "Propiedades" });

            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                idPokemon = pokemon.idPokemon,
                imgPokemon = pokemon.imgPokemon,
                nombre = pokemon.nombre,
                TipoPrimarioId = pokemon.TipoPrimario.idTipoPrimario,
                TipoSecundarioId = pokemon.TipoSecundario.idTipoSecundario,
                RegionId = pokemon.Region.idRegion,
                TipoPrimarioName = pokemon.TipoPrimario.Nombre,
                TipoSecundarioName = pokemon.TipoSecundario.Nombre,
                RegionName = pokemon.Region.Nombre
            }).ToList();
        }
        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FilterPokemonViewModel filters)
        {
            var pokemonList = await _pokemonRepository.GetAllWithIncludeAsync(new List<string> { "Propiedades" });

            var listViewModels = pokemonList.Select(pokemon => new PokemonViewModel
            {
                idPokemon = pokemon.idPokemon,
                imgPokemon = pokemon.imgPokemon,
                nombre = pokemon.nombre,
                TipoPrimarioId = pokemon.TipoPrimario.idTipoPrimario,
                TipoSecundarioId = pokemon.TipoSecundario.idTipoSecundario,
                RegionId = pokemon.Region.idRegion,
                TipoPrimarioName = pokemon.TipoPrimario.Nombre,
                TipoSecundarioName = pokemon.TipoSecundario.Nombre,
                RegionName = pokemon.Region.Nombre
            }).ToList();

            if (filters.RegionId != null)
            {
                listViewModels = listViewModels.Where(ad => ad.RegionId == filters.RegionId.Value).ToList();
            }

            return listViewModels;
        }
    }
}
