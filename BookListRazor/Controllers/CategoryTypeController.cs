using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryTypeController
    {


        private readonly ApplicationDbContext _db;

        public CategoryTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Category.ToListAsync() });
        }

        private IActionResult Json(object p)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(string id)
        {
            var categoryTypeFromDb = await _db.CategoryType.FirstOrDefaultAsync(b => b.Type == id);

            if (categoryTypeFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _db.CategoryType.Remove(categoryTypeFromDb);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
