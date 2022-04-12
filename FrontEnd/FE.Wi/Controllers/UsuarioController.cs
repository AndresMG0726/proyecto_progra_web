﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Wi.Models;

namespace FE.Wi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ProyectoContext _context;

        public UsuarioController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var proyectoContext = _context.Usuario.Include(u => u.IdDepartamentoNavigation).Include(u => u.IdJobNavigation).Include(u => u.IdRolNavigation);
            return View(await proyectoContext.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.IdDepartamentoNavigation)
                .Include(u => u.IdJobNavigation)
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "DescripcionDepartamento");
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "DescripcionJob");
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "DescRol");
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
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "DescripcionDepartamento", usuario.IdDepartamento);
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "DescripcionJob", usuario.IdJob);
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "DescRol", usuario.IdRol);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "DescripcionDepartamento", usuario.IdDepartamento);
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "DescripcionJob", usuario.IdJob);
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "DescRol", usuario.IdRol);
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
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamento, "IdDepartamento", "DescripcionDepartamento", usuario.IdDepartamento);
            ViewData["IdJob"] = new SelectList(_context.Job, "IdJob", "DescripcionJob", usuario.IdJob);
            ViewData["IdRol"] = new SelectList(_context.Rol, "IdRol", "DescRol", usuario.IdRol);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.IdDepartamentoNavigation)
                .Include(u => u.IdJobNavigation)
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
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
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
