﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShafiuddinSarkariSchool.Context;
using ShafiuddinSarkariSchool.Models;

namespace ShafiuddinSarkariSchool.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SchoolDbContext _context;

        public SubjectController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblSubject.ToListAsync());
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubject = await _context.tblSubject
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (tblSubject == null)
            {
                return NotFound();
            }

            return View(tblSubject);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,Name")] tblSubject tblSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSubject);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubject = await _context.tblSubject.FindAsync(id);
            if (tblSubject == null)
            {
                return NotFound();
            }
            return View(tblSubject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,Name")] tblSubject tblSubject)
        {
            if (id != tblSubject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblSubjectExists(tblSubject.SubjectId))
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
            return View(tblSubject);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubject = await _context.tblSubject
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (tblSubject == null)
            {
                return NotFound();
            }

            return View(tblSubject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSubject = await _context.tblSubject.FindAsync(id);
            _context.tblSubject.Remove(tblSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblSubjectExists(int id)
        {
            return _context.tblSubject.Any(e => e.SubjectId == id);
        }
    }
}
