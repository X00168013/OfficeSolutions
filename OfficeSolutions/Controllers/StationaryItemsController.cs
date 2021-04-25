using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeSolutions.Models;

namespace OfficeSolutions.Controllers
{
    public class StationaryItemsController : Controller
    {
        private readonly OfficeSolutionsContext _context;

        public StationaryItemsController(OfficeSolutionsContext context)
        {
            _context = context;
        }

        // GET: StationaryItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.StationaryItems.ToListAsync());
        }

        // GET: StationaryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.StationaryItems
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (stationaryItem == null)
            {
                return NotFound();
            }

            return View(stationaryItem);
        }

        // GET: StationaryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StationaryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,ProductType,Brand,Color")] StationaryItem stationaryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stationaryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stationaryItem);
        }

        // GET: StationaryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.StationaryItems.FindAsync(id);
            if (stationaryItem == null)
            {
                return NotFound();
            }
            return View(stationaryItem);
        }

        // POST: StationaryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,ProductType,Brand,Color")] StationaryItem stationaryItem)
        {
            if (id != stationaryItem.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stationaryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationaryItemExists(stationaryItem.ProductID))
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
            return View(stationaryItem);
        }

        // GET: StationaryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationaryItem = await _context.StationaryItems
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (stationaryItem == null)
            {
                return NotFound();
            }

            return View(stationaryItem);
        }

        // POST: StationaryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stationaryItem = await _context.StationaryItems.FindAsync(id);
            _context.StationaryItems.Remove(stationaryItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationaryItemExists(int id)
        {
            return _context.StationaryItems.Any(e => e.ProductID == id);
        }
    }
}
