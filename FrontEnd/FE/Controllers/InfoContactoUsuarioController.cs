using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Models;
using FE.Servicios;

namespace FE.Controllers
{
    public class InfoContactoUsuarioController : Controller
    {
        private readonly IInfoContactoUsuarioService infoContactoUsuarioService;
        private readonly IRolContactoService rolcontactoService;

        public InfoContactoUsuarioController(IInfoContactoUsuarioService _infoContactoUsuarioService, IRolContactoService _rolcontactoService)
        {
            infoContactoUsuarioService = _infoContactoUsuarioService;
            rolcontactoService = _rolcontactoService;
        }

        // GET: InfoContactoUsuario
        public async Task<IActionResult> Index()
        {
            return View(await infoContactoUsuarioService.GetAllAsync());
        }

        // GET: InfoContactoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContactoUsuario = await infoContactoUsuarioService.GetOneByIdAsync((int)id);
            if (infoContactoUsuario == null)
            {
                return NotFound();
            }

            return View(infoContactoUsuario);
        }

        // GET: InfoContactoUsuario/Create
        public IActionResult Create()
        {
            ViewData["IdRolCont"] = new SelectList(rolcontactoService.GetAll(), "IdRolCont", "DescRolCont");
            ViewData["IdUsuario"] = new SelectList(infoContactoUsuarioService.GetAll(), "IdUsuario", "Contrasenna");
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
                infoContactoUsuarioService.Insert(infoContactoUsuario);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRolCont"] = new SelectList(rolcontactoService.GetAll(), "IdRolCont", "DescRolCont", infoContactoUsuario.IdRolCont);
            ViewData["IdUsuario"] = new SelectList(infoContactoUsuarioService.GetAll(), "IdUsuario", "Contrasenna", infoContactoUsuario.IdUsuario);
            return View(infoContactoUsuario);
        }

        // GET: InfoContactoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContactoUsuario = await infoContactoUsuarioService.GetOneByIdAsync((int)id);
            if (infoContactoUsuario == null)
            {
                return NotFound();
            }

            ViewData["IdRolCont"] = new SelectList(rolcontactoService.GetAll(), "IdRolCont", "DescRolCont", infoContactoUsuario.IdRolCont);
            ViewData["IdUsuario"] = new SelectList(infoContactoUsuarioService.GetAll(), "IdUsuario", "Contrasenna", infoContactoUsuario.IdUsuario);
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
                    infoContactoUsuarioService.Update(infoContactoUsuario);
                }
                catch (Exception ee)
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
            ViewData["IdRolCont"] = new SelectList(rolcontactoService.GetAll(), "IdRolCont", "DescRolCont", infoContactoUsuario.IdRolCont);
            ViewData["IdUsuario"] = new SelectList(infoContactoUsuarioService.GetAll(), "IdUsuario", "Contrasenna", infoContactoUsuario.IdUsuario);
            return View(infoContactoUsuario);
        }

        // GET: InfoContactoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContactoUsuario = await infoContactoUsuarioService.GetOneByIdAsync((int)id);
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
            var infoContactoUsuario = await infoContactoUsuarioService.GetOneByIdAsync((int)id);
            infoContactoUsuarioService.Delete(infoContactoUsuario);
            return RedirectToAction(nameof(Index));
        }

        private bool InfoContactoUsuarioExists(int id)
        {
            return (infoContactoUsuarioService.GetOneByIdAsync((int)id) != null);
        }
    }
}
