using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PFMApi.Database.Entity.TransactionsE;
using PFMApi.Database.Entity.CategoriesE;

namespace PFMApi.Database.Entity.SplitTransactionsE
{
    public class SplitTransactions
    {  
        [Key]
        public int Id { get; set; }

        [ForeignKey("Transactions")]
        public string TransactionId { get; set; }
        public Categories Categories { get; set; }

        [ForeignKey("Categories")]
        public string CategoriesCode { get; set; }
        public Transactions Transactions { get; set; }
    }
}
