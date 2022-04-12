using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Identity.Models;
using FE.Identity.Servicios;

namespace FE.Identity.Controllers
{
    public class RolContactoController : Controller
    {
        private readonly IRolContactoService rolcontactoService;

        public RolContactoController(IRolContactoService _rolcontactoService)
        {
            rolcontactoService = _rolcontactoService;
        }

        // GET: RolContacto
        public async Task<IActionResult> Index()
        {
            return View(rolcontactoService.GetAll());
        }

        // GET: RolContacto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolContacto = rolcontactoService.GetOneById((int)id);
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
                rolcontactoService.Insert(rolContacto);
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

            var rolContacto = rolcontactoService.GetOneById((int)id);
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
                    rolcontactoService.Update(rolContacto);
                }
                catch (Exception ee)
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

            var rolContacto = rolcontactoService.GetOneById((int)id);
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
            var rolContacto = rolcontactoService.GetOneById((int)id);
            rolcontactoService.Delete(rolContacto);
            return RedirectToAction(nameof(Index));
        }

        private bool RolContactoExists(int id)
        {
            return (rolcontactoService.GetOneById((int)id) != null);
        }
    }
}
