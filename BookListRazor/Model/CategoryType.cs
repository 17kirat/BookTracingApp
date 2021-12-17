using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class CategoryType
    {
        [Key]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
