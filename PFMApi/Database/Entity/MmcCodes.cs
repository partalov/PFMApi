using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFMApi.Database.Entity
{
    public class MmcCodes
    {
        [Key]
        public int Coder { get; set; }
        public string MerchantType { get; set; }
    }
}