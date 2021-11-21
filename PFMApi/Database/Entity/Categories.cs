using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFMApi.Database.Entity
{
    public class Categories
    {
        [Key]
        public string Code { get; set; }
        [Required]
        public string ParentCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
