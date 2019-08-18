using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly InmobiliariaContext _context;

        public InmueblesController(InmobiliariaContext context)
        {
            _context = context;
        }

        // GET: Inmuebles
        public async Task<IActionResult> Index(int? roomsInmueble, string searchString, string operacionInmueble)
        {
            IQueryable<int> roomsQuery = from m in _context.Inmueble
                                            orderby m.Rooms
                                            select m.Rooms;
            IQueryable<string> operacionesQuery = from m in _context.Inmueble
                                         orderby m.Operacion
                                         select m.Operacion;
            var inmuebles = from m in _context.Inmueble
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

        // GET: Inmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmueble = await _context.Inmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inmueble == null)
            {
                return NotFound();
            }

            return View(inmueble);
        }

        // GET: Inmuebles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ubicación,Descripcion,FechaDePublicación,Superficie,Baths,Rooms,Operacion,Precio")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inmueble);
        }

        // GET: Inmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmueble = await _context.Inmueble.FindAsync(id);
            if (inmueble == null)
            {
                return NotFound();
            }
            return View(inmueble);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ubicación,Descripcion,FechaDePublicación,Superficie,Baths,Rooms,Operacion,Precio")] Inmueble inmueble)
        {
            if (id != inmueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InmuebleExists(inmueble.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inmueble);
        }

        // GET: Inmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmueble = await _context.Inmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inmueble == null)
            {
                return NotFound();
            }

            return View(inmueble);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inmueble = await _context.Inmueble.FindAsync(id);
            _context.Inmueble.Remove(inmueble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InmuebleExists(int id)
        {
            return _context.Inmueble.Any(e => e.Id == id);
        }
    }
}
