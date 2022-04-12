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
    public class SolicitudController : Controller
    {
        private readonly ISolicitudService solicitudService;
        private readonly ICategoriesService solicitudService;

        public SolicitudController(ISolicitudService _solicitudService, ICategoriesService _categoriesService)
        {
            solicitudService = _solicitudService;
            solicitudService = _categoriesService;
        }

        // GET: Solicitud
        public async Task<IActionResult> Index()
        {
            return View(await solicitudService.GetAllAsync());
        }

        // GET: Solicitud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await solicitudService.GetOneByIdAsync((int)id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "DescripcionEstado");
            ViewData["IdTipo"] = new SelectList(_context.Tipo, "IdTipo", "DescripcionTipo");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna");
            return View();

            ViewData["CategoryId"] = new SelectList(solicitudService.GetAll(), "CategoryId", "CategoryName");
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSolicitud,IdUsuario,IdEstado,IdTipo,ComentarioSolicitante,ComentarioEncargado,FechaEmicion")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                solicitudService.Insert(solicitud);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "DescripcionEstado", solicitud.IdEstado);
            ViewData["IdTipo"] = new SelectList(_context.Tipo, "IdTipo", "DescripcionTipo", solicitud.IdTipo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", solicitud.IdUsuario);
            return View(solicitud);

            ViewData["CategoryId"] = new SelectList(solicitudService.GetAll(), "CategoryId", "CategoryName", solicitud.CategoryId);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", solicitud.SupplierId);
            return View(solicitud);
        }

        // GET: Solicitud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await solicitudService.GetOneByIdAsync((int)id);
            if (solicitud == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "DescripcionEstado", solicitud.IdEstado);
            ViewData["IdTipo"] = new SelectList(_context.Tipo, "IdTipo", "DescripcionTipo", solicitud.IdTipo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", solicitud.IdUsuario);
            return View(solicitud);

            ViewData["CategoryId"] = new SelectList(solicitudService.GetAll(), "CategoryId", "CategoryName", solicitud.CategoryId);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", solicitud.SupplierId);
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSolicitud,IdUsuario,IdEstado,IdTipo,ComentarioSolicitante,ComentarioEncargado,FechaEmicion")] Solicitud solicitud)
        {
            if (id != solicitud.IdSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    solicitudService.Update(solicitud);
                }
                catch (Exception ee)
                {
                    if (!SolicitudExists(solicitud.IdSolicitud))
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
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "DescripcionEstado", solicitud.IdEstado);
            ViewData["IdTipo"] = new SelectList(_context.Tipo, "IdTipo", "DescripcionTipo", solicitud.IdTipo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "Contrasenna", solicitud.IdUsuario);
            return View(solicitud);

            ViewData["IdUsuario"] = new SelectList(solicitudService.GetAll(), "IdUsuario", "Contrasenna", horasExtra.IdUsuario);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await solicitudService.GetOneByIdAsync((int)id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await solicitudService.GetOneByIdAsync((int)id);
            solicitudService.Delete(solicitud);
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return (solicitudService.GetOneByIdAsync((int)id) != null);
        }
    }
}
