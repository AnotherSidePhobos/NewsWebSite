using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsApp.Domain;
using NewsApp.Domain.Entities;

namespace NewsApp.Controllers
{
    public class ArticleItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArticleItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticleItems.ToListAsync());
        }

        // GET: ArticleItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleItem = await _context.ArticleItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleItem == null)
            {
                return NotFound();
            }

            return View(articleItem);
        }

        // GET: ArticleItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Subtitle,FullText,ShortText,Id,TitleImagePath,Author,DateAdded")] ArticleItem articleItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleItem);
        }

        // GET: ArticleItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleItem = await _context.ArticleItems.FindAsync(id);
            if (articleItem == null)
            {
                return NotFound();
            }
            return View(articleItem);
        }

        // POST: ArticleItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Subtitle,FullText,ShortText,Id,TitleImagePath,Author,DateAdded")] ArticleItem articleItem)
        {
            if (id != articleItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleItemExists(articleItem.Id))
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
            return View(articleItem);
        }

        // GET: ArticleItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleItem = await _context.ArticleItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleItem == null)
            {
                return NotFound();
            }

            return View(articleItem);
        }

        // POST: ArticleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articleItem = await _context.ArticleItems.FindAsync(id);
            _context.ArticleItems.Remove(articleItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleItemExists(int id)
        {
            return _context.ArticleItems.Any(e => e.Id == id);
        }
    }
}
