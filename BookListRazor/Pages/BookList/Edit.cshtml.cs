using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }
        public Category Category { get; set; }

        public CategoryType CategoryType { get; set; }




        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // We pass Id as a parameter from Index page view when user clicks Edit
        public async Task OnGet(string id)
        {
            Book = await _db.Book.FindAsync(id);
            Category = await _db.Category.FindAsync(id);
            CategoryType = await _db.CategoryType.FindAsync(id);
        }
        

        
            


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Book bookFromDb = await _db.Book.FindAsync(Book.ISBN);
                bookFromDb.Tittle = Book.Tittle;
                bookFromDb.Author = Book.Author;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.CateGory = Book.CateGory;

                Category categoryFromDb = await _db.Category.FindAsync(Category.NameToken);
                categoryFromDb.NameToken = Category.NameToken;
                categoryFromDb.Type = Category.Type;
                categoryFromDb.Discription = Category.Discription;


                CategoryType categoryTypeFromDb = await _db.CategoryType.FindAsync(CategoryType.Type);
                categoryTypeFromDb.Name = CategoryType.Name;
                categoryTypeFromDb.Type = CategoryType.Type;


                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}

