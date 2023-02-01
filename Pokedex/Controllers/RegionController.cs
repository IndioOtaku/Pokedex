using Application.Services;
using Application.ViewModels.Pokemon;
using Application.ViewModels.Region;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PokedexWebApp.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionService _regionService;

        public RegionController(ApplicationContext dbcontext)
        {
            _regionService = new(dbcontext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(SaveRegionViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", rvm);
            }

            await _regionService.Add(rvm);
            return RedirectToRoute(new { Controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {

            return View("SaveRegion", await _regionService.GetByIdSaveRegionViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(SaveRegionViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", rvm);
            }

            await _regionService.Update(rvm);
            return RedirectToRoute(new { Controller = "Region", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _regionService.GetByIdSaveRegionViewModel(id);
            await _regionService.Delete(id);
            return RedirectToRoute(new { Controller = "Region", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _regionService.Delete(id);

            return View(new { Controller = "Region", action = "Index" });
        }
    }
}
