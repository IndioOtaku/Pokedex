using Application.Services;
using Application.ViewModels.Pokemon;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly TipoService _tipoService;

        public PokemonController(ApplicationContext dbcontext)
        {
            _pokemonService = new(dbcontext);
            _regionService = new(dbcontext);
            _tipoService = new(dbcontext);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Regiones = await _regionService.GetAllViewModel();
            ViewBag.TipoPrimario = await _tipoService.GetAllViewModel();
            ViewBag.TipoSecundario = await _tipoService.GetAllTipoSecundario();
            return View(await _pokemonService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            SavePokemonViewModel vm = new();
            vm.Regiones = await _regionService.GetAllViewModel();
            vm.TipoPrimario = await _tipoService.GetAllViewModel();
            vm.TipoSecundario = await _tipoService.GetAllTipoSecundario();
            return View("SavePokemon", vm);
        }

        [HttpPost]

        public async Task<IActionResult> CreatePost(SavePokemonViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", pvm);
            }

            await _pokemonService.Add(pvm);
            return RedirectToRoute(new { Controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            SavePokemonViewModel vm = await _pokemonService.GetByIdSavePokemonViewModel(id);
            vm.Regiones = await _regionService.GetAllViewModel();
            vm.TipoPrimario = await _tipoService.GetAllViewModel();
            vm.TipoSecundario = await _tipoService.GetAllTipoSecundario();
            return View("SavePokemon", vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(SavePokemonViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", pvm);
            }

            await _pokemonService.Update(pvm);
            return RedirectToRoute(new { Controller = "Pokemon", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _pokemonService.GetByIdSavePokemonViewModel(id);
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { Controller = "Pokemon", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);

            return RedirectToRoute(new { Controller = "Pokemon", action = "Index" });
        }
    }
}
