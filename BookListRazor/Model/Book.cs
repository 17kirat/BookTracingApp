using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    // Models represent any table we want in the database

    public class Book
    {
        // This will create an Id value automatically, we do not need to pass a value
        [Key]
        public string ISBN { get; set; }

        // This means Name cannot be null
        [Required]
        public string Tittle  { get; set; }

        public string Author { get; set; }
        public string CateGory { get; set; }

    }
}
