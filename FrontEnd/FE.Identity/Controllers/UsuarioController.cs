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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly IDepartamentoService departamentoService;
        private readonly IJobService2 jobService;
        private readonly IRolService rolService;


        public UsuarioController(IUsuarioService _usuarioService, IDepartamentoService _departamentoService, IJobService2 _jobService, IRolService _rolService)
        {
            usuarioService = _usuarioService;
            departamentoService = _departamentoService;
            jobService = _jobService;
            rolService = _rolService;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await usuarioService.GetAllAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await usuarioService.GetOneByIdAsync((int)id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(departamentoService.GetAll(), "IdDepartamento", "DescripcionDepartamento");
            ViewData["IdJob"] = new SelectList(jobService.GetAll(), "IdJob", "DescripcionJob");
            ViewData["IdRol"] = new SelectList(rolService.GetAll(), "IdRol", "DescRol");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdRol,Usuario1,Contrasenna,Email,Telefono,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,IdJob,IdDepartamento,FechaContratacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioService.Insert(usuario);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(departamentoService.GetAll(), "IdDepartamento", "DescripcionDepartamento", usuario.IdDepartamento);
            ViewData["IdJob"] = new SelectList(jobService.GetAll(), "IdJob", "DescripcionJob", usuario.IdJob);
            ViewData["IdRol"] = new SelectList(rolService.GetAll(), "IdRol", "DescRol", usuario.IdRol);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await usuarioService.GetOneByIdAsync((int)id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(departamentoService.GetAll(), "IdDepartamento", "DescripcionDepartamento", usuario.IdDepartamento);
            ViewData["IdJob"] = new SelectList(jobService.GetAll(), "IdJob", "DescripcionJob", usuario.IdJob);
            ViewData["IdRol"] = new SelectList(rolService.GetAll(), "IdRol", "DescRol", usuario.IdRol);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdRol,Usuario1,Contrasenna,Email,Telefono,NombreUsuario,PrimerApellidoUsuario,SegundoApellidoUsuario,IdJob,IdDepartamento,FechaContratacion")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuarioService.Update(usuario);
                }
                catch (Exception ee)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdDepartamento"] = new SelectList(departamentoService.GetAll(), "IdDepartamento", "DescripcionDepartamento", usuario.IdDepartamento);
            ViewData["IdJob"] = new SelectList(jobService.GetAll(), "IdJob", "DescripcionJob", usuario.IdJob);
            ViewData["IdRol"] = new SelectList(rolService.GetAll(), "IdRol", "DescRol", usuario.IdRol);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await usuarioService.GetOneByIdAsync((int)id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await usuarioService.GetOneByIdAsync((int)id);
            usuarioService.Delete(usuario);
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (usuarioService.GetOneByIdAsync((int)id) != null);
        }
    }
}
