using ApiConciertosAWSExamen.Models;
using Microsoft.AspNetCore.Mvc;
using MvcExamenConciertos.Models;
using MvcExamenConciertos.Services;

namespace MvcExamenConciertos.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiConciertos service;
        public EventosController(ServiceApiConciertos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {

            List<CategoriaEvento> categorias =
                await this.service.GetCategoriaEventosAsync();
            ViewData["CATEGORIAS"] = categorias;

            List<Evento> eventos =
                await this.service.GetEventosAsync();
            return View(eventos);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int idcategoria)
        {
            List<CategoriaEvento> categorias =
                await this.service.GetCategoriaEventosAsync();
            ViewData["CATEGORIAS"] = categorias;


            List<Evento> eventos =
                 await this.service.FindConciertosByCategoriaAsync(idcategoria);   
            return View(eventos);
        }

        //public async Task<IActionResult> ConciertosCategoria(int idcategoria)
        //{
        //    List<Evento> eventos =
        //        await this.service.FindConciertosByCategoriaAsync(idcategoria);
        //    return View(eventos);
        //}

        public async Task<IActionResult> Categorias()
        {
            List<CategoriaEvento> categorias =
                await this.service.GetCategoriaEventosAsync();
            return View(categorias);
        }
    }
}
