using Application.Services;
using Application.ViewModels.Region;
using Application.ViewModels.TipoPrimario;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PokedexWebApp.Controllers
{
    public class TipoController : Controller
    {
        private readonly TipoService _tipoService;

        public TipoController(ApplicationContext dbcontext)
        {
            _tipoService = new(dbcontext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipoService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveTipo", new SaveTipoPrimarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(SaveTipoPrimarioViewModel tpvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", tpvm);
            }

            await _tipoService.Add(tpvm);
            return RedirectToRoute(new { Controller = "Tipo", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {

            return View("SaveTipo", await _tipoService.GetByIdSaveTipoViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(SaveTipoPrimarioViewModel tpvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", tpvm);
            }

            await _tipoService.Update(tpvm);
            return RedirectToRoute(new { Controller = "Tipo", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _tipoService.GetByIdSaveTipoViewModel(id);
            await _tipoService.Delete(id);
            return RedirectToRoute(new { Controller = "Tipo", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _tipoService.Delete(id);

            return View(new { Controller = "Tipo", action = "Index" });
        }
    }
}
