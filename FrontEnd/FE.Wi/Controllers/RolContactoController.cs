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
    public class RolContactoController : Controller
    {
        private readonly ProyectoContext _context;

        public RolContactoController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: RolContacto
        public async Task<IActionResult> Index()
        {
            return View(await _context.RolContacto.ToListAsync());
        }

        // GET: RolContacto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolContacto = await _context.RolContacto
                .FirstOrDefaultAsync(m => m.IdRolCont == id);
            if (rolContacto == null)
            {
                return NotFound();
            }

            return View(rolContacto);
        }

        // GET: RolContacto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolContacto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRolCont,DescRolCont")] RolContacto rolContacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolContacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolContacto);
        }

        // GET: RolContacto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolContacto = await _context.RolContacto.FindAsync(id);
            if (rolContacto == null)
            {
                return NotFound();
            }
            return View(rolContacto);
        }

        // POST: RolContacto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRolCont,DescRolCont")] RolContacto rolContacto)
        {
            if (id != rolContacto.IdRolCont)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolContacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolContactoExists(rolContacto.IdRolCont))
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
            return View(rolContacto);
        }

        // GET: RolContacto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolContacto = await _context.RolContacto
                .FirstOrDefaultAsync(m => m.IdRolCont == id);
            if (rolContacto == null)
            {
                return NotFound();
            }

            return View(rolContacto);
        }

        // POST: RolContacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolContacto = await _context.RolContacto.FindAsync(id);
            _context.RolContacto.Remove(rolContacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolContactoExists(int id)
        {
            return _context.RolContacto.Any(e => e.IdRolCont == id);
        }
    }
}
