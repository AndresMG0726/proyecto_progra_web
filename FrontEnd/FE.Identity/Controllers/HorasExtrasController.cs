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
    public class HorasExtrasController : Controller
    {
        private readonly IHorasExtraService horasExtraService;
        private readonly IUsuarioService usuarioService;

        public HorasExtrasController(IHorasExtraService _horasExtraService, IUsuarioService _usuarioService)
        {
            horasExtraService = _horasExtraService;
            usuarioService = _usuarioService;
        }

        // GET: HorasExtras
        public async Task<IActionResult> Index()
        {
            return View(await horasExtraService.GetAllAsync());
        }

        // GET: HorasExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtra = await horasExtraService.GetOneByIdAsync((int)id);
            if (horasExtra == null)
            {
                return NotFound();
            }

            return View(horasExtra);
        }

        // GET: HorasExtras/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(horasExtraService.GetAll(), "CategoryId", "CategoryName");
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
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
                horasExtraService.Insert(horasExtra);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(horasExtraService.GetAll(), "IdUsuario", "Contrasenna", horasExtra.IdUsuario);
            return View(horasExtra);
        }

        // GET: HorasExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtra = await horasExtraService.GetOneByIdAsync((int)id);
            if (horasExtra == null)
            {
                return NotFound();
            }

            ViewData["IdUsuario"] = new SelectList(horasExtraService.GetAll(), "IdUsuario", "Contrasenna", horasExtra.IdUsuario);
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
                    horasExtraService.Update(horasExtra);
                }
                catch (Exception ee)
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
            ViewData["IdUsuario"] = new SelectList(horasExtraService.GetAll(), "IdUsuario", "Contrasenna", horasExtra.IdUsuario);        
            return View(horasExtra);
        }

        // GET: HorasExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horasExtra = await horasExtraService.GetOneByIdAsync((int)id);
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
            var horasExtra = await horasExtraService.GetOneByIdAsync((int)id);
            horasExtraService.Delete(horasExtra);
            return RedirectToAction(nameof(Index));
        }

        private bool HorasExtraExists(int id)
        {
            return (horasExtraService.GetOneByIdAsync((int)id) != null);
        }
    }
}
