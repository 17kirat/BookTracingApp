using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        // Binding means, on post we get the property that is here
        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        public Category Category { get; set; }
        [BindProperty]
        public CategoryType CategoryType { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // We don't have to pass the empty Book object, it does that automatically
            // We will be able to access this Book inside the Create view
        }

        // Task is IActionResult because we are redirecting to a new page
        public async Task<IActionResult> OnPost()
        {
            // ModelState.IsValid checks required areas in the model etc.
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.Category.AddAsync(Category);
                await _db.CategoryType.AddAsync(CategoryType);

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            
            else
            {
                return Page();
            }
        }
    }
}