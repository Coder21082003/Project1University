using CommonDataLayer.Untilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataLayer.Entities
{
    public class BaseModel 
    {
        [Column("created_at")]
        public DateTime? created_at { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? updated_at { get; set; } = DateTime.Now;


        //public int? DeletedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }
    }
}
