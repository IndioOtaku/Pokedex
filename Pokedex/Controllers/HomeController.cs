using Application.Services;
using Application.ViewModels.Pokemon;
using DataBase;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;
        private readonly RegionService _regionService;
        private readonly TipoService _tipoService;

        public HomeController(ApplicationContext dbcontext)
        {
            _pokemonService = new(dbcontext);
            _regionService = new(dbcontext);
            _tipoService = new(dbcontext);
        }

        public async Task<IActionResult> Index(FilterPokemonViewModel vm)
        {
            ViewBag.Regiones = await _regionService.GetAllViewModel();
            ViewBag.TipoPrimario = await _tipoService.GetAllViewModel();
            ViewBag.TipoSecundario = await _tipoService.GetAllTipoSecundario();
            return View(await _pokemonService.GetAllViewModelWithFilters(vm));
        }
    }
}
