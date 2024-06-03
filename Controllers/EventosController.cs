using Microsoft.AspNetCore.Mvc;
using MvcCoreConciertos.Models;
using MvcCoreConciertos.Services;

namespace MvcCoreConciertos.Controllers
{
    public class EventosController: Controller
    {
        private ServiceApiConciertos service;

        public EventosController(ServiceApiConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        public async Task<IActionResult> EventosCategoria(int id)
        {
            List<Evento> eventos = await this.service.GetEventosByCategoriaAsync(id);
            return View(eventos);
        }
    }
}
