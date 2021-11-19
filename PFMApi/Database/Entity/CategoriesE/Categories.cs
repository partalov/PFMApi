using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFMApi.Database.Entity.CategoriesE
{
    public class Categories
    {
        [Key]
        public string Code { get; set; }
        public string? ParentCode { get; set; }
        public string Name { get; set; }
    }
}
