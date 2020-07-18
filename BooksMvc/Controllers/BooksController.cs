using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BooksMvc.Controllers {
    public class BooksController : Controller {

        private readonly AppDbContext _db;
        public BooksController(AppDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            List<Book> list = _db.Book.ToList();
            return View(list);
        }

        public IActionResult Create() {
            return View();
        }

        public async Task<IActionResult> Edit(int? id) {
            if(id == null) {
                return NotFound();
            }
            var bookEdit = await _db.Book.FindAsync(id);
            return View(bookEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book, int id) {
            if (ModelState.IsValid) {
                try {
                    _db.Book.Update(book);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException) {
                    if(!_db.Book.Any(x => x.Id == id)) {
                        return NotFound();
                    }
                }
            }
            return View(book);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Book book) {
            if (ModelState.IsValid) {
                _db.Book.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id) {
            var toDelete = _db.Book.Find(id);
            _db.Remove(toDelete);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
