﻿using System;
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
    public class JobController : Controller
    {
        private readonly IJobService2 jobService;

        public JobController(IJobService2 _jobService)
        {
            jobService = _jobService;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            return View(jobService.GetAll());
        }

        // GET: Job/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = jobService.GetOneById((int)id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJob,DescripcionJob")] Job job)
        {
            if (ModelState.IsValid)
            {
                jobService.Insert(job);
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = jobService.GetOneById((int)id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJob,DescripcionJob")] Job job)
        {
            if (id != job.IdJob)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    jobService.Update(job);
                }
                catch (Exception ee)
                {
                    if (!JobExists(job.IdJob))
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
            return View(job);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = jobService.GetOneById((int)id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = jobService.GetOneById((int)id);
            jobService.Delete(job);
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return (jobService.GetOneById((int)id) != null);
        }
    }
}
