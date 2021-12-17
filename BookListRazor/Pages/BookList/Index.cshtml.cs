using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<CategoryType> CategoryType { get; set; }


        // We are getting db using dependency injection
        // Extracting ApplicationDbContext inside the dependency injection container and injecting onto this page
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // When using async and await, instead of void we use async Task
        public async Task OnGet()
        {
            // Assigning all books from database to Books
            Books = await _db.Book.ToListAsync();
            Category = await _db.Category.ToListAsync();
            CategoryType = await _db.CategoryType.ToListAsync();
        }

        // It will be a post handler because it is a button
        // Name is OnPost + handler name that we defined
        public async Task<IActionResult> OnPostDelete(string id)
        {
            Book book = await _db.Book.FindAsync(id);
            Category category = await _db.Category.FindAsync(id);
            CategoryType categoryType = await _db.CategoryType.FindAsync(id);
            // Book does not exist based on the id
            if (book == null)
            {
                return NotFound();
            }
            else if(category== null)
            {
                return NotFound();
            }
            else if(categoryType== null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            _db.Category.Remove(category);
            _db.CategoryType.Remove(categoryType);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
