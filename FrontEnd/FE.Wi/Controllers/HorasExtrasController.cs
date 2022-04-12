using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Wi.Models;

namespace FE.Wi.Controllers
{
    public class HorasExtrasController : Controller
    {
        private readonly ProyectoContext _context;

        public HorasExtrasController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: HorasExtras
        public async Task<IActionResult> Index()
        {
            var proyectoContext = _context.HorasExtra.Include(h => h.IdUsuarioNavigation);
            return View(await proyectoContext.ToListAsync());
        }

        // GET: HorasExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtra = await _context.HorasExtra
                .Include(h => h.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdHE == id);
            if (horasExtra == null)
            {
                return NotFound();
            }

            return View(horasExtra);
        }

        // GET: HorasExtras/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna");
            return View();
        }

        // POST: HorasExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHE,IdUsuario,Dia,HoraInicio,HoraFin")] HorasExtra horasExtra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horasExtra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", horasExtra.IdUsuario);
            return View(horasExtra);
        }

        // GET: HorasExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtra = await _context.HorasExtra.FindAsync(id);
            if (horasExtra == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", horasExtra.IdUsuario);
            return View(horasExtra);
        }

        // POST: HorasExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHE,IdUsuario,Dia,HoraInicio,HoraFin")] HorasExtra horasExtra)
        {
            if (id != horasExtra.IdHE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horasExtra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorasExtraExists(horasExtra.IdHE))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", horasExtra.IdUsuario);
            return View(horasExtra);
        }

        // GET: HorasExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtra = await _context.HorasExtra
                .Include(h => h.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdHE == id);
            if (horasExtra == null)
            {
                return NotFound();
            }

            return View(horasExtra);
        }

        // POST: HorasExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horasExtra = await _context.HorasExtra.FindAsync(id);
            _context.HorasExtra.Remove(horasExtra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorasExtraExists(int id)
        {
            return _context.HorasExtra.Any(e => e.IdHE == id);
        }
    }
}
