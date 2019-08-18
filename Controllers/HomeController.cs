using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly InmobiliariaContext _contexto;

        public HomeController(InmobiliariaContext context)
        {
            _contexto = context;
        }
        public async Task<IActionResult> Index(int? roomsInmueble, string searchString, string operacionInmueble)
        {
            IQueryable<int> roomsQuery = from m in _contexto.Inmueble
                                         orderby m.Rooms
                                         select m.Rooms;
            IQueryable<string> operacionesQuery = from m in _contexto.Inmueble
                                                  orderby m.Operacion
                                                  select m.Operacion;
            var inmuebles = from m in _contexto.Inmueble
                            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                inmuebles = inmuebles.Where(s => s.Ubicación.Contains(searchString));
            }

            if (roomsInmueble != null)
            {
                inmuebles = inmuebles.Where(x => x.Rooms == roomsInmueble);
            }

            if (!string.IsNullOrEmpty(operacionInmueble))
            {
                inmuebles = inmuebles.Where(x => x.Operacion == operacionInmueble);
            }

            var roomsInmuebleVM = new RoomsInmuebleViewModel
            {
                Rooms = new SelectList(await roomsQuery.Distinct().ToListAsync()),
                Operaciones = new SelectList(await operacionesQuery.Distinct().ToListAsync()),
                Inmuebles = await inmuebles.ToListAsync()
            };

            return View(roomsInmuebleVM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
