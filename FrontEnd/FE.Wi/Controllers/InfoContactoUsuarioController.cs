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
    public class InfoContactoUsuarioController : Controller
    {
        private readonly ProyectoContext _context;

        public InfoContactoUsuarioController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: InfoContactoUsuario
        public async Task<IActionResult> Index()
        {
            var proyectoContext = _context.InfoContactoUsuario.Include(i => i.IdRolContNavigation).Include(i => i.IdUsuarioNavigation);
            return View(await proyectoContext.ToListAsync());
        }

        // GET: InfoContactoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContactoUsuario = await _context.InfoContactoUsuario
                .Include(i => i.IdRolContNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdInfo == id);
            if (infoContactoUsuario == null)
            {
                return NotFound();
            }

            return View(infoContactoUsuario);
        }

        // GET: InfoContactoUsuario/Create
        public IActionResult Create()
        {
            ViewData["IdRolCont"] = new SelectList(_context.RolContacto, "IdRolCont", "DescRolCont");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna");
            return View();
        }

        // POST: InfoContactoUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInfo,IdUsuario,NombreCompletoContacto,IdRolCont,TelefonoContacto")] InfoContactoUsuario infoContactoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoContactoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRolCont"] = new SelectList(_context.RolContacto, "IdRolCont", "DescRolCont", infoContactoUsuario.IdRolCont);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", infoContactoUsuario.IdUsuario);
            return View(infoContactoUsuario);
        }

        // GET: InfoContactoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContactoUsuario = await _context.InfoContactoUsuario.FindAsync(id);
            if (infoContactoUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdRolCont"] = new SelectList(_context.RolContacto, "IdRolCont", "DescRolCont", infoContactoUsuario.IdRolCont);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", infoContactoUsuario.IdUsuario);
            return View(infoContactoUsuario);
        }

        // POST: InfoContactoUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInfo,IdUsuario,NombreCompletoContacto,IdRolCont,TelefonoContacto")] InfoContactoUsuario infoContactoUsuario)
        {
            if (id != infoContactoUsuario.IdInfo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoContactoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoContactoUsuarioExists(infoContactoUsuario.IdInfo))
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
            ViewData["IdRolCont"] = new SelectList(_context.RolContacto, "IdRolCont", "DescRolCont", infoContactoUsuario.IdRolCont);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", infoContactoUsuario.IdUsuario);
            return View(infoContactoUsuario);
        }

        // GET: InfoContactoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContactoUsuario = await _context.InfoContactoUsuario
                .Include(i => i.IdRolContNavigation)
                .Include(i => i.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdInfo == id);
            if (infoContactoUsuario == null)
            {
                return NotFound();
            }

            return View(infoContactoUsuario);
        }

        // POST: InfoContactoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoContactoUsuario = await _context.InfoContactoUsuario.FindAsync(id);
            _context.InfoContactoUsuario.Remove(infoContactoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoContactoUsuarioExists(int id)
        {
            return _context.InfoContactoUsuario.Any(e => e.IdInfo == id);
        }
    }
}
