using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.Models;
using FE.Servicios;
using FE.Servicios;

namespace FE.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService departamentoService;

        public DepartamentoController(IDepartamentoService _departamentoService)
        {
            departamentoService = _departamentoService;
        }

        // GET: Departamento
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Departamento.ToListAsync());
                        return View(departamentoService.GetAll());
        }

        // GET: Departamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var departamento = await _context.Departamento
            //  .FirstOrDefaultAsync(m => m.IdDepartamento == id);
            //if (departamento == null)
            var departamento = departamentoService.GetOneById((int)id);
            if (departamento == null)
            {
                return NotFound();
            }
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDepartamento,DescripcionDepartamento")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(departamento);
                // await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                departamentoService.Insert(departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = departamentoService.GetOneById((int)id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var categories = DepartamentoService.GetOneById((int)id);
            //if (categories == null)
            //{
            //    return NotFound();
            //}
            //return View(departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDepartamento,DescripcionDepartamento")] Departamento departamento)
        {
            //if (id != departamento.IdDepartamento)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(departamento);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!DepartamentoExists(departamento.IdDepartamento))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(departamento);
            if (id != departamento.IdDepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    departamentoService.Update(departamento);
                }
                catch (Exception ee)
                {
                    if (!Exists(departamento.IdDepartamento))
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
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = departamentoService.GetOneById((int)id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var departamento = await _context.Departamento.FindAsync(id);
            //_context.Departamento.Remove(departamento);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            var categories = departamentoService.GetOneById((int)id);
            departamentoService.Delete(categories);
            return RedirectToAction(nameof(Index));
        }

        private bool Exists(int id)
        {
            //return _context.Departamento.Any(e => e.IdDepartamento == id);
            return (departamentoService.GetOneById((int)id) != null);
        }
    }
}
