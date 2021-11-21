using PFMApi.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace PFMApi.Helpers
{
    public class MmcMappingModel : CsvMapping<MmcCodes>
    {
        public MmcMappingModel()
       : base()
        {
            MapProperty(0, m => m.Coder);
            MapProperty(1, m => m.MerchantType);

        }
    }
}