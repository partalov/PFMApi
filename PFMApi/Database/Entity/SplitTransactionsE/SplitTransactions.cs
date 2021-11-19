using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFMApi.Database.Entity.SplitTransactionsE
{
    public class SplitTransactions
    {  
        [Key]
        public int Id { get; set; }

        [ForeignKey("Transactions")]
        public string TransactionId { get; set; }

        [ForeignKey("Categories")]
        public string CategoriesCode { get; set; }
    }
}
