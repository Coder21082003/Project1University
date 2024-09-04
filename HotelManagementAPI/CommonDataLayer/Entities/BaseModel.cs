using CommonDataLayer.Untilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataLayer.Entities
{
    public class BaseModel 
    {
        public int? DeletedDate { get; set; }
        public int CreatedDate { get; set; } = EntityUntilities.GetNowTimestamp();
        public string CreatedBy { get; set; }
        public int ModifiedDate { get; set; } = EntityUntilities.GetNowTimestamp();
        public string ModifiedBy { get; set; }
    }
}
