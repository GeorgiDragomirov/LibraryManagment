﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagment.Data;
using LibraryManagment.Models;

namespace LibraryManagment.Controllers
{
    public class LendingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LendingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lendings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lending.Include(l => l.Book).Include(l => l.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lendings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // GET: Lendings/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id");
            return View();
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MemberId,BookId,LendingDate,ReturnDate,AmountPaid")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", lending.MemberId);
            return View(lending);
        }

        // GET: Lendings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending.FindAsync(id);
            if (lending == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", lending.MemberId);
            return View(lending);
        }

        // POST: Lendings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MemberId,BookId,LendingDate,ReturnDate,AmountPaid")] Lending lending)
        {
            if (id != lending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingExists(lending.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", lending.BookId);
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", lending.MemberId);
            return View(lending);
        }

        // GET: Lendings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // POST: Lendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lending = await _context.Lending.FindAsync(id);
            _context.Lending.Remove(lending);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendingExists(int id)
        {
            return _context.Lending.Any(e => e.Id == id);
        }
    }
}
