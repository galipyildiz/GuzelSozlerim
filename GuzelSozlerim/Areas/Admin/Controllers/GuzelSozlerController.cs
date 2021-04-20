using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuzelSozlerim.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GuzelSozlerim.Areas.Admin.Controllers
{
    public class GuzelSozlerController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;

        public GuzelSozlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GuzelSozler
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.GuzelSozler.ToListAsync());
        }

        // GET: Admin/GuzelSozler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guzelSoz = await _context.GuzelSozler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guzelSoz == null)
            {
                return NotFound();
            }

            return View(guzelSoz);
        }

        // GET: Admin/GuzelSozler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GuzelSozler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Soz")] GuzelSoz guzelSoz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guzelSoz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guzelSoz);
        }

        // GET: Admin/GuzelSozler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guzelSoz = await _context.GuzelSozler.FindAsync(id);
            if (guzelSoz == null)
            {
                return NotFound();
            }
            return View(guzelSoz);
        }

        // POST: Admin/GuzelSozler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Soz")] GuzelSoz guzelSoz)
        {
            if (id != guzelSoz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guzelSoz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuzelSozExists(guzelSoz.Id))
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
            return View(guzelSoz);
        }

        // GET: Admin/GuzelSozler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guzelSoz = await _context.GuzelSozler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guzelSoz == null)
            {
                return NotFound();
            }

            return View(guzelSoz);
        }

        // POST: Admin/GuzelSozler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guzelSoz = await _context.GuzelSozler.FindAsync(id);
            _context.GuzelSozler.Remove(guzelSoz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuzelSozExists(int id)
        {
            return _context.GuzelSozler.Any(e => e.Id == id);
        }
    }
}
