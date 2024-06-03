using Microsoft.AspNetCore.Mvc;
using MvcCoreConciertos.Models;
using MvcCoreConciertos.Services;

namespace MvcCoreConciertos.Controllers
{
    public class CategoriasController : Controller
    {
        private ServiceApiConciertos service;

        public CategoriasController(ServiceApiConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            return View(categorias);
        }
    }
}
