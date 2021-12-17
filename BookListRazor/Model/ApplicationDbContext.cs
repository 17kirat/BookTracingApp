using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    // Whenever we are dealing with database, we need ApplicationDbContext

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // In order to add any model to the database, we need an entry here
        public DbSet<Book> Book { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryType> CategoryType { get; set; }

       
    }

}