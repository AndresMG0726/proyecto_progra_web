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
    public class SolicitudController : Controller
    {
        private readonly ISolicitudService solicitudService;
        private readonly IUsuarioService usuarioService;
        private readonly ITipoService tipoService;
        private readonly IEstadoService estadoService;

        public SolicitudController(ISolicitudService _solicitudService, IUsuarioService _usuarioService, ITipoService _tipoService, IEstadoService _estadoService)
        {
            solicitudService = _solicitudService;
            usuarioService = _usuarioService;
            tipoService = _tipoService;
            estadoService = _estadoService;
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
            ViewData["IdEstado"] = new SelectList(estadoService.GetAll(), "IdEstado", "DescripcionEstado");
            ViewData["IdTipo"] = new SelectList(tipoService.GetAll(), "IdTipo", "DescripcionTipo");
            ViewData["IdUsuario"] = new SelectList(usuarioService.GetAll(), "IdUsuario", "Contrasenna");
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
            ViewData["IdEstado"] = new SelectList(estadoService.GetAll(), "IdEstado", "DescripcionEstado", solicitud.IdEstado);
            ViewData["IdTipo"] = new SelectList(tipoService.GetAll(), "IdTipo", "DescripcionTipo", solicitud.IdTipo);
            ViewData["IdUsuario"] = new SelectList(usuarioService.GetAll(), "IdUsuario", "Contrasenna", solicitud.IdUsuario);
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
            ViewData["IdEstado"] = new SelectList(estadoService.GetAll(), "IdEstado", "DescripcionEstado", solicitud.IdEstado);
            ViewData["IdTipo"] = new SelectList(tipoService.GetAll(), "IdTipo", "DescripcionTipo", solicitud.IdTipo);
            ViewData["IdUsuario"] = new SelectList(usuarioService.GetAll(), "IdUsuario", "Contrasenna", solicitud.IdUsuario);
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
            ViewData["IdEstado"] = new SelectList(estadoService.GetAll(), "IdEstado", "DescripcionEstado", solicitud.IdEstado);
            ViewData["IdTipo"] = new SelectList(tipoService.GetAll(), "IdTipo", "DescripcionTipo", solicitud.IdTipo);
            ViewData["IdUsuario"] = new SelectList(usuarioService.GetAll(), "IdUsuario", "Contrasenna", solicitud.IdUsuario);
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
