using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Category
    {
        [Key]
        public string NameToken { get; set; }

        // This means Name cannot be null
        [Required]
        public string Type { get; set; }

        public string Discription { get; set; }
    }
}
