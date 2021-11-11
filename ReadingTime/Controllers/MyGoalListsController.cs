using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReadingTime.Data;
using ReadingTime.Models;

namespace ReadingTime.Controllers
{
    public class MyGoalListsController : Controller
    {
        private readonly ReadingTimeContext _context;

        public MyGoalListsController(ReadingTimeContext context)
        {
            _context = context;
        }

        // GET: MyGoalLists
        public async Task<IActionResult> Index()
        {
            var readingTimeContext = _context.MyGoalList.Include(m => m.User);
            return View(await readingTimeContext.ToListAsync());
        }

        // GET: MyGoalLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGoalList = await _context.MyGoalList
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myGoalList == null)
            {
                return NotFound();
            }

            return View(myGoalList);
        }

        // GET: MyGoalLists/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id","Username");
            return View();
        }

        // POST: MyGoalLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId")] MyGoalList myGoalList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myGoalList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", myGoalList.UserId);
            return View(myGoalList);
        }

        // GET: MyGoalLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGoalList = await _context.MyGoalList.FindAsync(id);
            if (myGoalList == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", myGoalList.UserId);
            return View(myGoalList);
        }

        // POST: MyGoalLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId")] MyGoalList myGoalList)
        {
            if (id != myGoalList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myGoalList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyGoalListExists(myGoalList.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", myGoalList.UserId);
            return View(myGoalList);
        }

        // GET: MyGoalLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGoalList = await _context.MyGoalList
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myGoalList == null)
            {
                return NotFound();
            }

            return View(myGoalList);
        }

        // POST: MyGoalLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myGoalList = await _context.MyGoalList.FindAsync(id);
            _context.MyGoalList.Remove(myGoalList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyGoalListExists(int id)
        {
            return _context.MyGoalList.Any(e => e.Id == id);
        }
    }
}
